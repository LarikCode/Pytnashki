using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pytnashki
{
    abstract class DeveloperCell
    {
        public string Name { get; set; }
        
        public DeveloperCell(string n)
        {
            Name = n;
        }

        abstract public CellWithTitle Create(int X, int Y);                  //Фабричный метод
    }

    class CellWithTitleDeveloper : DeveloperCell
    {
        public CellWithTitleDeveloper(string n) : base(n)
        {  }

        internal CellWithTitle CellWithTitle
        {
            get => default(CellWithTitle);
            set
            {
            }
        }

        internal Pole Pole
        {
            get => default(Pole);
            set
            {
            }
        }

        public override CellWithTitle Create(int X, int Y)                   //Переопределение Фабричного метода
        {
            return new CellWithTitle(X, Y);                         
        }
    }    
}
