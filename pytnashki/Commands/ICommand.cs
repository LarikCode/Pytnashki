using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pytnashki
{
    interface ICommand
    {
        bool Execute();
        bool Undo();
    }
}
