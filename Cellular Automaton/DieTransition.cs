using System;

namespace Cellular_Automaton
{
    public class DieTransition : IStateTransition
    {
        private readonly Tile _tile;
        public DieTransition(Tile tile)
        {
            _tile = tile;
        }
        // Transition from Alive -> Dead when <2 or >3 neighbors are alive.
        public bool ToTransition()
        {
            int aliveNeighbors = _tile.CountAliveNeighbors();
            return aliveNeighbors < 2 || aliveNeighbors > 3;
        }
    }
}
