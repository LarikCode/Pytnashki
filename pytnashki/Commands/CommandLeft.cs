using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pytnashki
{
    class CommandLeft : ICommand
    {
        Pole pole;
        public CommandLeft()
        {
            pole = Pole.getInstance();
        }
        public bool Execute()
        {
            return pole.Left();
        }
        public bool Undo()
        {
            return pole.Right();
        }
    }
}
