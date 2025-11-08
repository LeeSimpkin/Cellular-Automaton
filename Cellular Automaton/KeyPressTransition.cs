using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cellular_Automaton
{
    public class KeyPressTransition : IStateTransition
    {
        public KeyPressTransition()
        {
        }
        public bool ToTransition()
        {
            if(Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                return true;
            }
            else
                return false;
        }
    }
}
