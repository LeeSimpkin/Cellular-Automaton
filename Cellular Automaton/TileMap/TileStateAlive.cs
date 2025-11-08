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
            tile.Type = Tile.TileType.ALIVE;
        }
        public override void OnExit()
        {
            // Logic to execute when exiting the Alive state
        }
        public override void OnUpdate(float seconds)
        {
            // Logic to execute during the update cycle while in the Alive state
        }
    }
}
