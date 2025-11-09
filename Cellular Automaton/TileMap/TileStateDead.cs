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
        Point point;
        public TileStateDead(Tile tile, Point point) : base()
        {
            this.tile = tile;
            this.point = point;
        }
        public override void OnEnter()
        {
            Game1.tileMap.ChangeType(point, Tile.TileType.DEAD);
        }
        public override void OnExit()
        {
            // Logic to execute when exiting the Dead state
        }
        public override void OnUpdate(float seconds)
        {
        }
    }
}
