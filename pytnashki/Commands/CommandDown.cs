using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pytnashki
{
    class CommandDown : ICommand
    {
        Pole pole;
        public CommandDown()
        {
            pole = Pole.getInstance();
        }
        public bool Execute()
        {
            return pole.Down();
        }
        public bool Undo()
        {
            return pole.Up();
        }
    }
}
