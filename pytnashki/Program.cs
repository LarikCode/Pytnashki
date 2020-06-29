using System;


namespace pytnashki
{

    class Program
    {
        static void Main(string[] args)
        {
            Pole pole;
            Player player;
            AntiPlayer antiPlayer;
            int Size, LevelCount, Bot;

            Console.WriteLine("Игра Пятнашки! Для управления используйте стрелки, для отмены клавишу Backspace");
            Console.WriteLine();

            EnterSettings(out Size, out LevelCount, out Bot);   //Считываем настройки игры

            pole = Pole.getInstance();                          //Создать новое поле

            pole.NewState(Size);                                //Установить размер игрового поля

            antiPlayer = new AntiPlayer();                      //Создать антиигрока

            if (Bot == 1) antiPlayer.playOrNo = true;           //Активировать антиигрока

            antiPlayer.Randomize(LevelCount * 10);              //Антиигрок перемешиват поле

            player = Player.getInstance();                      //Создать игрока

            pole.Show();                                        

            while (!pole.Fin())
            {
                if (!player.Move(Console.ReadKey().Key))        //Игрок делает ходы 
                {
                    Console.Beep();
                };
                pole.Show();                                    //Отображаем поле игры
                antiPlayer.Action();
            }
                                    
            Console.ReadKey();
        }

        static void EnterSettings(out int Size, out int Level, out int Bot)
        {
            bool end;
            
            do
            {
                end = false;            

                Console.WriteLine("Введите размерность поля 3..9");
                if (!Int32.TryParse(Console.ReadLine(), out Size) || Size < 3 || Size > 9 )
                {
                    end = true;
                    Console.WriteLine("Введено неверно!");                    
                }

                Console.WriteLine("Введите уровень сложности от 1 до 10");
                if (!Int32.TryParse(Console.ReadLine(), out Level) || Level < 1 || Level > 10)
                {
                    end = true;
                    Console.WriteLine("Введено неверно!");                    
                }

                Console.WriteLine("Включить бота противника? Введите 1/0 для включения/отключения.");
                if (!Int32.TryParse(Console.ReadLine(), out Bot) || Bot < 0 || Bot > 1)
                {
                    end = true;
                    Console.WriteLine("Введено неверно!");
                }
                    if (end) Console.WriteLine("Была допущена ошибка при вводе, попробуйте снова)");    
            } while (end);
        }        
    }
}
