using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HomeWork.Models;      // модели

namespace HomeWork.Application
{
    // Класс Приложение (Утилиты)
    public partial class App
    {
        // Утилиты
        public class Utils
        {
            #region Утилиты

            // объект Random для заполнения массивов
            public static Random rand = new Random();

            // получение случайного вещественного числа в диапазоне (min, max]
            public static double GetDouble(int min, int max) => rand.Next(min, max) + rand.NextDouble();

            // вывод сообщения в цвете 
            public static void WriteColor(string msg, ConsoleColor textColor, ConsoleColor backColor = ConsoleColor.Black)
            {
                // текущий цвет 
                ConsoleColor tempText = Console.ForegroundColor;
                ConsoleColor tempBack = Console.BackgroundColor;

                // установк цвета
                SetColor(textColor, backColor);

                // вывод сообщения 
                Console.Write(msg);

                // возвращение цвета 
                SetColor(tempText, tempBack);
            }

            // вывод сообщения в цвете и позиционированием 
            public static void WriteColorXY(string msg = "", int posX = -1, int posY = -1, ConsoleColor textColor = ConsoleColor.White, ConsoleColor backColor = ConsoleColor.Black)
            {
                // позиционирование курсора
                PosXY(posX == -1 ? Console.CursorLeft : posX, posY == -1 ? Console.CursorTop : posY);

                // вывод сообщения в цвете
                WriteColor(msg, textColor, backColor);
            }

            // вывод сообщения о неправильно введённых данных, с указанием позиции
            public static void MsgErrorData(int posX = 0, int posY = -1, string msg = "Данные неверны!")
            {
                // вывод сообщения 
                WriteColorXY(msg, posX, posY == -1 ? Console.CursorTop - 1 : posY, ConsoleColor.Black, ConsoleColor.Red);

                // задержка по времени
                Thread.Sleep(500);
            }

            // позиционирование курсора
            public static void PosXY(int posX, int posY) => Console.SetCursorPosition(posX, posY);

            // установка цвета текста 
            public static void SetColor(ConsoleColor color) => Console.ForegroundColor = color; // SetColor

            // установка цвета текста и фона 
            public static void SetColor(ConsoleColor textColor, ConsoleColor backColor)
            {
                Console.ForegroundColor = textColor;
                Console.BackgroundColor = backColor;
            } // SetColor

            // вывод сообщения в первой строке консоли
            public static void ShowNavBarMessage(string msg)
            {
                // установка цвета
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.DarkBlue;

                // позиционирование курсора
                Console.SetCursorPosition(0, 0);

                // заполенение первой строки цветом 
                Console.WriteLine($"{" ".PadLeft(Console.WindowWidth)}");

                // позиционирование курсора
                Console.SetCursorPosition(2, 0);

                // вывод сообщения 
                Console.WriteLine(msg);

                // позиционирование курсора
                Console.SetCursorPosition(0, 3);

                Console.ResetColor();
            } // ShowNavBarMessage


            // вывод информации о запросе
            public static void ShowInfoLines(string label, string[] content)
            {
                // вывод шапки
                //                                                                  100
                WriteColorXY("     ╔══════════════════════════════════════════════════════════════════════════════════════════════════════╗\n", textColor: ConsoleColor.Magenta);
                WriteColorXY("     ║                                                                                                      ║", textColor: ConsoleColor.Magenta);
                WriteColorXY($"{label,-100}", 7, textColor: ConsoleColor.Green);
                Console.WriteLine();

                WriteColorXY("     ╠══════════════════════════════════════════════════════════════════════════════════════════════════════╣\n", textColor: ConsoleColor.Magenta);

                // вывод строк
                Array.ForEach(content, line =>
                {
                    WriteColorXY("     ║                                                                                                      ║", textColor: ConsoleColor.Magenta);
                    WriteColorXY($"{line,-100}", 7, textColor: ConsoleColor.Cyan);
                    Console.WriteLine();
                });

                // вывод подвала
                WriteColorXY("     ╚══════════════════════════════════════════════════════════════════════════════════════════════════════╝\n\n", textColor: ConsoleColor.Magenta);
            }


            // вывод информации о запросе
            public static void ShowInfo(string label)
            {
                // вывод шапки
                //                                                                  100
                WriteColorXY("     ╔══════════════════════════════════════════════════════════════════════════════════════════════════════╗\n", textColor: ConsoleColor.Magenta);
                WriteColorXY("     ║                                                                                                      ║", textColor: ConsoleColor.Magenta);
                WriteColorXY($"{label,-100}", 7, textColor: ConsoleColor.Green);
                Console.WriteLine();

                // вывод подвала
                WriteColorXY("     ╚══════════════════════════════════════════════════════════════════════════════════════════════════════╝\n\n", textColor: ConsoleColor.Magenta);
            }


            // названия товаров и цена
            public static (string title, int price)[] GoodsTitlePrice => new [] { 
                                                        ("Стул кухонный",       3000),
                                                        ("Лампа настольная",    2200),
                                                        ("Духи Lacoste",        4500),
                                                        ("Обои Sky",            1600),
                                                        ("Теннисная ракетка",   2900),
                                                        ("Нож кухонный",         560),
                                                        ("Футбольный мяч",      1600),
                                                        ("Клавиатура",          2300),
                                                        ("Гель для душа",        250),
                                                        ("Шампунь",              230),
                                                    };


            // фабричный метод товара
            public static Goods GetGoods()
            {
                // названия товара и цена
                var goods = GoodsTitlePrice[rand.Next(0, GoodsTitlePrice.Length)];

                return new Goods { Title = goods.title, Price = goods.price, Amount = rand.Next(10, 40), Year = rand.Next(7, 22) + 2000 };
            }


            // получение диапазона произведения цены на количество товара
            public static (int lo, int hi) GetRangeProdPriceAmountGoods(List<Goods> list)
            {
                // диапазон
                (int lo, int hi) = (0, 0);

                // размер списка
                int count = list.Count;

                do
                {
                    // индексы элементов
                    int i = rand.Next(0, count), k = rand.Next(0, count);

                    // установка произведений
                    (lo, hi) = (list[i].Amount * list[i].Price, list[k].Amount * list[k].Price);
                } while (lo > hi);


                return (lo, hi);
            }


            #endregion
        }
    }
}