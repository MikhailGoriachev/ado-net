using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

            // получение случайного целого числа в диапазоне (min, max]
            public static int GetRand(int min, int max) => rand.Next(min, max);

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
            public static void ShowInfoQuery(string label, string[] content)
            {
                // вывод шапки
                //                                                                  100
                WriteColorXY("     ╔══════════════════════════════════════════════════════════════════════════════════════════════════════╗\n", textColor: ConsoleColor.DarkMagenta);
                WriteColorXY("     ║                                                                                                      ║", textColor: ConsoleColor.DarkMagenta);
                WriteColorXY($"{label,-100}", 7, textColor: ConsoleColor.Green);
                Console.WriteLine();

                WriteColorXY("     ╠══════════════════════════════════════════════════════════════════════════════════════════════════════╣\n", textColor: ConsoleColor.DarkMagenta);

                // вывод строк
                Array.ForEach(content, line =>
                {
                    WriteColorXY("     ║                                                                                                      ║", textColor: ConsoleColor.DarkMagenta);
                    WriteColorXY($"{line,-100}", 7, textColor: ConsoleColor.Cyan);
                    Console.WriteLine();
                });

                // вывод подвала
                WriteColorXY("     ╚══════════════════════════════════════════════════════════════════════════════════════════════════════╝\n\n", textColor: ConsoleColor.DarkMagenta);
            }


            // получение номера автомобиля
            public static string GetNumber()
            {
                string[] numbers = new[] {
                    "АН4841ТС",
                    "НО7985ВТ",
                    "АС2194СН",
                    "СН9155ТС",
                    "АС9549ВТ",
                    "НО2315СН", 
                };

                return numbers[GetRand(0, numbers.Length)];
            }


            // получение номера автомобиля
            public static string GetBrand()
            {
                string[] brands = new[] {
                    "BMW X6",
                    "BMW E81",
                    "Mercedes-Benz W124AMG",
                    "Mercedes-Benz W906",
                    "Mercedes-Benz W221", 
                };

                return brands[GetRand(0, brands.Length)];
            }


            // получение номера паспорта
            public static string GetPassport()
            {
                string[] passports = new[] {
                    "ЕС45718",
                    "АВ34524",
                    "АТ65423",
                    "ВО12312",
                    "СК67443",
                };

                return passports[GetRand(0, passports.Length)];
            }

            #endregion
        }
    }
}