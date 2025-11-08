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
        public bool ToTransition()
        {
            int aliveNeighbors = _tile.CountAliveNeighbors();
            if (aliveNeighbors == 3)
            {
                return false;
            }
            else
                return true;
        }
    }
}
