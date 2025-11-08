using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cellular_Automaton
{
    public class TileStateDead : TileState
    {
        Tile tile;
        public TileStateDead(Tile tile) : base()
        {
            this.tile = tile;
        }
        public override void OnEnter()
        {
            //tile.Type = Tile.TileType.DEAD;
        }
        public override void OnExit()
        {
            // Logic to execute when exiting the Dead state
        }
        public override void OnUpdate(float seconds)
        {
            Point point = Mouse.GetState().Position;
            Tile t = TileMap.Tiles[point.X / TileMap.Size, point.Y / TileMap.Size];
            t.Type = Tile.TileType.DEAD;
        }
    }
}
