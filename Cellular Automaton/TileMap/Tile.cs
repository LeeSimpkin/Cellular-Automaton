using Cellular_Automaton;
using Microsoft.Xna.Framework;
using System;

namespace Cellular_Automaton
{
    public class Tile : GameComponent
    {
        private FiniteStateMachine<TileState, IStateTransition> fsm;

        // Per-tile coordinates
        public int Column { get; set; }
        public int Row { get; set; }

        public static int Columns { get; set; } = 0;
        public static int Rows { get; set; } = 0;

        // Grid reference for neighbor lookups (set by TileMap)
        public static Tile[,] AllTiles { get; set; }

        public enum TileType
        {
            DEAD,
            ALIVE
        }

        public TileType Type { get; set; }

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

        // Parameterless constructor so TileMap can new Tile()
        public Tile() : base(null)
        {
            var aliveState = new TileStateAlive(this, Game1.point);
            var deadState = new TileStateDead(this, Game1.point);

            SparseGraph<TileState, IStateTransition> graph = new();
            graph.AddNode(aliveState);
            graph.AddNode(deadState);
            graph.AddEdge(aliveState, new DieTransition(this), deadState);
            graph.AddEdge(deadState, new BornTransition(this), aliveState);
            fsm = new FiniteStateMachine<TileState, IStateTransition>(graph, deadState);
            Type = TileType.DEAD;
        }

        // Optional: Update if you use the per-tile FSM update loop
        public override void Update(GameTime gameTime)
        {
            fsm.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
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

        public static bool InvalidTile(int col, int row)
        {
            return col < 0 || col >= Columns || row < 0 || row >= Rows;
        }

        public static bool ValidTile(int col, int row)
        {
            return !InvalidTile(col, row);
        }
    }
}
