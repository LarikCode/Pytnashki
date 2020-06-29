using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pytnashki
{
    public class Pole
    {        
        private static Pole instance;

        public static int NullPositionX, NullPositionY;        

        public CellWithTitle[,] cellWhisTitles;

        public int Size { get; private set; }        

        protected Pole()                           //Приватный конструктор, использование паттерна Синглтон
        {            
                        
        }

        public static Pole getInstance()           //Метод возвращающий ссылку на один и тот же обьект (Синглтон)
        {
            if (instance == null)
                instance = new Pole();
            return instance;
        }

        public bool NewState(int newSize)         //Заполнение поля клетками в правильном порядке
        {            
            if(newSize > 2 && newSize < 10)
            {
                Size = newSize;

                cellWhisTitles = new CellWithTitle[Size, Size];
                CellWithTitleDeveloper cellWith = new CellWithTitleDeveloper("CellWith");
                for (int i = 0; i < Size; i++)
                    for (int j = 0; j < Size; j++)
                    {
                        cellWhisTitles[i, j] = (CellWithTitle)cellWith.Create(i, j);
                        cellWhisTitles[i, j].X = i;
                        cellWhisTitles[i, j].Y = j;
                        cellWhisTitles[i, j].Title = i * Size + j + 1;
                    }
                cellWhisTitles[Size - 1, Size - 1].Title = 0;
                NullPositionX = Size - 1;
                NullPositionY = Size - 1;
                return true;
            }
            else
            {
                return false;
            }    
            
        }
        
        public void Show()                               //Отображение поля на экране
        {
            Console.Clear();
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (cellWhisTitles[i, j].Title == 0) Console.BackgroundColor = ConsoleColor.White ;
                    Console.Write("{0,3}",cellWhisTitles[i, j].Title);
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }             

        public bool Up()                                 //Сдвигает пустую клетку вверх
        {
            if(NullPositionX -1 < 0)
            {
                return false;
            }
            else
            {
                CellWithTitle cellBuff;
                cellBuff = cellWhisTitles[NullPositionX, NullPositionY];
                cellWhisTitles[NullPositionX, NullPositionY] = cellWhisTitles[NullPositionX-1, NullPositionY];
                cellWhisTitles[NullPositionX - 1, NullPositionY] = cellBuff;
                NullPositionX--;
                
                return true;
            }
        }

        public bool Down()                              //Сдвигает пустую клетку вниз
        {
            if (NullPositionX + 1 >= Size)
            {
                return false;
            }
            else
            {
                CellWithTitle cellBuff;
                cellBuff = cellWhisTitles[NullPositionX, NullPositionY];
                cellWhisTitles[NullPositionX, NullPositionY] = cellWhisTitles[NullPositionX + 1, NullPositionY];
                cellWhisTitles[NullPositionX + 1, NullPositionY] = cellBuff;
                NullPositionX++;
                
                return true;
            }
        }

        public bool Right()                           //Сдвигает пустую клетку вправо
        {
            if (NullPositionY + 1 >= Size)
            {
                return false;
            }
            else
            {
                CellWithTitle cellBuff;
                cellBuff = cellWhisTitles[NullPositionX, NullPositionY];
                cellWhisTitles[NullPositionX, NullPositionY] = cellWhisTitles[NullPositionX, NullPositionY + 1];
                cellWhisTitles[NullPositionX, NullPositionY + 1] = cellBuff;
                NullPositionY++;
                
                return true;
            }
        }

        public bool Left()                          //Сдвигает пустую клетку влево 
        {
            if (NullPositionY - 1 < 0)
            {
                return false;
            }
            else
            {
                CellWithTitle cellBuff;
                cellBuff = cellWhisTitles[NullPositionX, NullPositionY];
                cellWhisTitles[NullPositionX, NullPositionY] = cellWhisTitles[NullPositionX, NullPositionY - 1];
                cellWhisTitles[NullPositionX, NullPositionY - 1] = cellBuff;
                NullPositionY--;
                
                return true;
            }
        }        

        public bool Fin()                           //Проверяет все ли клетки на месте, конец игры
        {
            bool final = true;
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                {
                    if (i != cellWhisTitles[i, j].X || j != cellWhisTitles[i, j].Y) final = false;                    
                }
            if (final) Console.WriteLine("You win!!!");
            return final;
        }        
    }
}
