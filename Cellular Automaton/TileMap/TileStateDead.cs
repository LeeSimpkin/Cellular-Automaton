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
            tile.Type = Tile.TileType.DEAD;
        }
        public override void OnExit()
        {
            // Logic to execute when exiting the Dead state
        }
        public override void OnUpdate(float seconds)
        {
            // Logic to execute during the update cycle while in the Dead state
        }
    }
}
