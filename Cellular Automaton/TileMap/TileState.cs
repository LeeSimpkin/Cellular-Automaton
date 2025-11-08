using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cellular_Automaton
{
    public abstract class TileState : IState
    {
        protected readonly Tile _tile;
        public TileState()
        {
            
        }
        public abstract void OnEnter();
        public abstract void OnExit();
        public abstract void OnUpdate(float seconds);
    }
}
