namespace lesson_6_2
{
    using System;
    using System.ComponentModel.Design;

    //Определяем перечисление курятников с курами
    public enum Coop { coop1, coop2, coop3 }
    class Program
    {
        static void Main()
        {
            bool live = true;//переменная условия выполнения программы
            int Egg = 0;
            void ChooseCoop()
            {
                Console.WriteLine("В какой курятник пойдем?");
                foreach (Coop coop in Enum.GetValues(typeof(Coop)))
                {
                    Console.WriteLine($"Курятник: {Enum.GetName(typeof(Coop), coop)}");
                }

                string input = Console.ReadLine();//запрашиваем у пользователя значение из перечисления
                if (Enum.TryParse(input, out Coop selectedCoop))
                {
                    Console.WriteLine($"Вы выбрали: {selectedCoop}");
                    Doing();
                }
                else
                {
                    DisplayRedMessage("Неверный ввод.");
                    live = false;
                }
            }
            ChooseCoop();
            void Doing()//метод взаимодействия с курицей в курятнике
            {
                while (live)//выполняем действия с курицей
                {

                    Console.WriteLine($"Что будем делать?:\nПокормить курицу - 1 \nЗабрать яйцо - 2\nНичего не делать - 3\nВыбрать курятник - 4");
                    string? input1 = Console.ReadLine();
                    int MenusPoint;
                    if (int.TryParse(input1, out MenusPoint))
                    {
                        switch (MenusPoint)
                        {
                            case 1:
                                Feed();
                                break;
                            case 2:
                                TakeEgg();
                                break;
                            case 3:
                                DoNothing();
                                break;
                            case 4:
                                ChooseCoop();
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Неверный ввод.");
                        live = false;
                    }
                    if (!live)//подводим итог, если курица умерла и выходим из курятника
                    {
                        DisplayRedMessage("WASTED");
                        Console.WriteLine("Курица умерла...");
                        Console.WriteLine($"Яиц: {Egg}");
                        ChooseCoop();
                    }

                }
            }
            void TakeEgg()//метод взятия яйца
            {
                Console.WriteLine("Забираем яйцо...");
                Egg--;
                live = false;
            }

            void DoNothing()//метод ничегонеделания
            {
                Console.WriteLine("Ничего не делаем");
                live = false;
            }
            void Feed()//метод кормления курицы
            {
                Console.WriteLine("Введите количество зерен:");
                int cereal = Convert.ToInt32(Console.ReadLine());
                if (cereal < 3)
                {
                    live = false;
                }
                else
                {
                    Egg++;
                }
            }
            void DisplayRedMessage(string message)//метод вывода цветного сообщения
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(message);
                Console.ResetColor();
            }
        }
    }

}