using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cellular_Automaton
{
    public interface IStateTransition
    {
        public bool ToTransition();
    }
}
