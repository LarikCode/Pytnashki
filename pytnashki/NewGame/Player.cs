using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pytnashki
{
    public class Player
    {
        private static Player instance;

        private Stack<ICommand> History { get; set; }

        internal CommandRight CommandRight
        {
            get => new CommandRight();
            set
            {
            }
        }

        internal CommandUP CommandUP
        {
            get => new CommandUP();
            set
            {
            }
        }

        internal CommandDown CommandDown
        {
            get => new CommandDown();
            set
            {
            }
        }

        internal CommandLeft CommandLeft
        {
            get => new CommandLeft();
            set
            {
            }
        }

        internal Pole Pole
        {
            get => Pole.getInstance();
            set
            {
            }
        }

        protected Player()
        {
            History = new Stack<ICommand>();
        }

        public static Player getInstance()           //Метод возвращающий ссылку на один и тот же обьект (Синглтон)
        {
            if (instance == null)
                instance = new Player();
            return instance;
        }

        public void HistoryClear()
        {
            History.Clear();
        }

        public int HistoryCount()
        {
            return History.Count;
        }

        public bool Move(ConsoleKey key)
        {
            
            Pole = Pole.getInstance();     
            
            if (key == ConsoleKey.UpArrow && CommandUP.Execute()) { History.Push(CommandUP); return true; }
            if (key == ConsoleKey.DownArrow && CommandDown.Execute()) { History.Push(CommandDown); return true; }
            if (key == ConsoleKey.RightArrow && CommandRight.Execute()) { History.Push(CommandRight); return true; }
            if (key == ConsoleKey.LeftArrow && CommandLeft.Execute()) { History.Push(CommandLeft); return true; }
            if (key == ConsoleKey.Backspace && History.Count > 0) { History.Pop().Undo(); return true; }
            return false;
        }
    }
}
