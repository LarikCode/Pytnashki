using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pytnashki
{
    class CommandRight : ICommand
    {
        Pole pole;
        public CommandRight()
        {
            pole = Pole.getInstance();
        }
        public bool Execute()
        {
            return pole.Right();
        }
        public bool Undo()
        {
            return pole.Left();
        }
    }
}
