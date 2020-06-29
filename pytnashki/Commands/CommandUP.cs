using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pytnashki
{
    class CommandUP : ICommand
    {
        Pole pole;
        public CommandUP()
        {
            pole = Pole.getInstance();
        }
        public bool Execute()
        {
            return pole.Up();
        }
        public bool Undo()
        {
            return pole.Down();
        } 
    }
}
