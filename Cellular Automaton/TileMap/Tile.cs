using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Cellular_Automaton.TileState;

namespace Cellular_Automaton
{
    public class Tile : GameComponent
    {
        public enum TileType { DEAD, ALIVE };
        public TileType Type { get; set; }
        private FiniteStateMachine<TileState, IStateTransition> fsm;
        public static int Column { get; set; } = 0;
        public static int Row { get; set; } = 0;
        public static Tile[,] AllTiles { get; set; }

        public Rectangle OutLineRectangle;
        public Color OutLineColour;
        public Rectangle InFillRectangle;
        public Color InFillColour
        {
            get
            {
                switch (Type)
                {
                    case TileType.ALIVE:
                        return Color.Black;
                    default:
                        return Color.White;
                }
            }
        }
        public Tile(Game game) : base(game)
        {
            TileStateAlive aliveState = new TileStateAlive(this);
            TileStateDead deadState = new TileStateDead(this);

            SparseGraph<TileState, IStateTransition> graph = new();
            graph.AddNode(aliveState);
            graph.AddNode(deadState);
            graph.AddEdge(aliveState, new DieTransition(this), deadState);
            graph.AddEdge(deadState, new BornTransition(this), aliveState);
            graph.AddEdge(deadState, new KeyPressTransition(), aliveState);

            fsm = new FiniteStateMachine<TileState, IStateTransition>(graph, deadState);
        }
        public override void Update(GameTime gameTime)
        {
            float seconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
            fsm.Update(seconds);
            base.Update(gameTime);
        }

        public int CountAliveNeighbors()
        {
            var grid = AllTiles;
            if (grid == null)
                return 0;

            int cols = grid.GetLength(0);
            int rows = grid.GetLength(1);

            int count = 0;
            for (int dx = -1; dx <= 1; dx++)
            {
                for (int dy = -1; dy <= 1; dy++)
                {
                    // Skip the tile itself
                    if (dx == 0 && dy == 0)
                        continue;

                    int c = Column + dx;
                    int r = Row + dy;

                    if (c >= 0 && c < cols && r >= 0 && r < rows)
                    {
                        Tile neighbor = grid[c, r];
                        if (neighbor != null && neighbor.Type == TileType.ALIVE)
                            count++;
                    }
                }
            }

            return count;
        }
    }
}
