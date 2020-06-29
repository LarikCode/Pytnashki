using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pytnashki
{
    public class CellWithTitle 
    {
        public int Title { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public CellWithTitle(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }    
}
