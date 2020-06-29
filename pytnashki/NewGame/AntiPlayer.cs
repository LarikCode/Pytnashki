using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pytnashki
{
    public class AntiPlayer
    {
        public bool playOrNo = false;

        private Player player = Player.getInstance();               

        public AntiPlayer()
        {
            
        }

        internal Pole Pole
        {
            get => Pole.getInstance();
            set
            {
            }
        }

        public void Action()                            
        {
             if (playOrNo && DateTime.Now.Second % 20 == 0 && this.Randomize(15))
             {
                player.HistoryClear();
             }           
        }

        public bool Randomize(int quantity)
        {
            if (quantity < 0) { quantity = 0; return false; }
            Random random = new Random();
            for(int i = 0; i < quantity; i++)
            {
                switch (random.Next(0, 4))
                {
                    case 0: Pole.Up(); break;
                    case 1: Pole.Down(); break;
                    case 2: Pole.Left(); break;
                    case 3: Pole.Right(); break;
                }
            }
            return true;
        }
    }
}
