using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cellular_Automaton
{
    public class BornTransition : IStateTransition
    {
        private readonly Tile _tile;
        public BornTransition(Tile tile)
        {
            _tile = tile;
        }
        // Transition from Dead -> Alive when exactly 3 neighbors are alive.
        public bool ToTransition()
        {
            int aliveNeighbors = _tile.CountAliveNeighbors();
            return aliveNeighbors == 3;
        }
    }
}
