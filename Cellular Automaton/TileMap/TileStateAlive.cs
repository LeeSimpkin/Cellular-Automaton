using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Cellular_Automaton
{
    public class TileStateAlive : TileState
    {
        Tile tile;
        public TileStateAlive(Tile tile) : base()
        {
            this.tile = tile;
        }
        public override void OnEnter()
        {
            //tile.Type = Tile.TileType.ALIVE;
        }
        public override void OnExit()
        {
            // Logic to execute when exiting the Alive state
        }
        public override void OnUpdate(float seconds)
        {
            Point point = Mouse.GetState().Position;
            Tile t = TileMap.Tiles[point.X / TileMap.Size, point.Y / TileMap.Size];
            t.Type = Tile.TileType.ALIVE;
        }
    }
}
