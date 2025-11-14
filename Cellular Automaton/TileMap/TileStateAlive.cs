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
        Point point;
        public TileStateAlive(Tile tile, Point point) : base()
        {
            this.tile = tile;
            this.point = point;
        }
        public override void OnEnter()
        {
            //Game1.tileMap.ChangeType(point, Tile.TileType.ALIVE);
        }
        public override void OnExit()
        {
            // Logic to execute when exiting the Alive state
        }
        public override void OnUpdate(float seconds)
        {

        }
    }
}
