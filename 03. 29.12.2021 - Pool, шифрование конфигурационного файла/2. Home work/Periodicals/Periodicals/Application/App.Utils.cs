using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace Periodicals.Application
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


            // вывод содержание файла 
            public static void ShowFileContent(string label, string fileName)
            {
                // вывод шапки
                //                                                                  100
                WriteColorXY("     ╔════╦══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗\n", textColor: ConsoleColor.DarkMagenta);
                WriteColorXY("     ║    ║                                                                                                                                              ║", textColor: ConsoleColor.DarkMagenta);
                WriteColorXY($"N",        7, textColor: ConsoleColor.DarkYellow);
                WriteColorXY($"{label}", 12, textColor: ConsoleColor.Green);
                Console.WriteLine();

                WriteColorXY("     ╠════╬══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╣\n", textColor: ConsoleColor.DarkMagenta);

                const int maxLength = 140;

                using (StreamReader reader = new StreamReader(fileName))
                {
                    // номер строки
                    int num = 1;

                    while (!reader.EndOfStream)
                    {
                        // считанная строка
                        string line = reader.ReadLine();

                        // количество подстрок на которые нужно поделить исходную строку
                        int n = line.Length / maxLength;

                        // позиция начала строки
                        int k = 0;

                        // разделение и вывода строки
                        for (int i = 0; i < n; i++, k += maxLength)
                            ShowLineFile(line.Substring(k, maxLength), num++);

                        ShowLineFile(line.Substring(k), num++);
                    }
                }

                // вывод подвала
                WriteColorXY("     ╚════╩══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝\n\n", textColor: ConsoleColor.DarkMagenta);
            }


            // вывод строки файла
            public static void ShowLineFile(string line, int num)
            {
                WriteColorXY("     ║    ║                                                                                                                                              ║", textColor: ConsoleColor.DarkMagenta);
                WriteColorXY($"{num, 2}",    7, textColor: ConsoleColor.DarkGray);
                WriteColorXY($"{line}",     12, textColor: ConsoleColor.Cyan);
                Console.WriteLine();
            }


            // получение типа издания
            public static string GetEditionType()
            {
                string[] types = new[] {
                    "газета",
                    "каталог",
                    "альманах",
                    "журнал" 
                };

                return types[rand.Next(0, types.Length)];
            }


            #region Вывод результата запроса 6

            // вывод шапки таблицы
            public static void ShowHeadProc6()
            {
                //                  ID 2    IndexEdition 10       Title 30            Price 10 DateStartSubscribe 10 SubscribePeriodMonths 10 SubscriptionCost 10
                WriteColorXY("     ╔════╦════════════╦══════════════════════╦════════════╦════════════╦════════════╦════════════╗\n", textColor: ConsoleColor.Magenta);
                WriteColorXY("     ║    ║            ║                      ║            ║            ║            ║            ║", textColor: ConsoleColor.Magenta);
                WriteColorXY("ID",                7, textColor: ConsoleColor.DarkYellow);
                WriteColorXY("Индекс",           12, textColor: ConsoleColor.DarkYellow);
                WriteColorXY("Название издания", 25, textColor: ConsoleColor.DarkYellow);
                WriteColorXY("Цена",             48, textColor: ConsoleColor.DarkYellow);
                WriteColorXY("   Дата   ",       61, textColor: ConsoleColor.DarkYellow);
                WriteColorXY("   Срок   ",       74, textColor: ConsoleColor.DarkYellow);
                WriteColorXY("Стоимость ",       87, textColor: ConsoleColor.DarkYellow);
                Console.WriteLine();

                WriteColorXY("     ║    ║            ║                      ║            ║            ║            ║            ║", textColor: ConsoleColor.Magenta);
                WriteColorXY(" подписки ",  61, textColor: ConsoleColor.DarkYellow);
                WriteColorXY(" подписки ",  74, textColor: ConsoleColor.DarkYellow);
                WriteColorXY(" без НДС  ",  87, textColor: ConsoleColor.DarkYellow);
                Console.WriteLine();

                WriteColorXY("     ╠════╬════════════╬══════════════════════╬════════════╬════════════╬════════════╬════════════╣\n", textColor: ConsoleColor.Magenta);
            }


            // вывод записей таблицы
            public static void ShowElemProc6(SqlDataReader reader)
            {
                WriteColorXY("     ║    ║            ║                      ║            ║            ║            ║            ║", textColor: ConsoleColor.Magenta);
                WriteColorXY($"{reader.GetInt32(0)}",        7, textColor: ConsoleColor.DarkGray);
                WriteColorXY($"{reader.GetString(1)}",      12, textColor: ConsoleColor.DarkCyan);
                WriteColorXY($"{reader.GetString(2)}",      25, textColor: ConsoleColor.Green);
                WriteColorXY($"{reader.GetInt32(3):n0}",    48, textColor: ConsoleColor.DarkCyan);
                WriteColorXY($"{reader.GetDateTime(4):d}",  61, textColor: ConsoleColor.DarkCyan);
                WriteColorXY($"{reader.GetInt32(5)}",       74, textColor: ConsoleColor.DarkCyan);
                WriteColorXY($"{reader.GetInt32(6)}",       87, textColor: ConsoleColor.DarkCyan);
                Console.WriteLine();

            }


            // вывод подвала таблицы
            public static void ShowLineProc6() =>
                WriteColorXY("     ╚════╩════════════╩══════════════════════╩════════════╩════════════╩════════════╩════════════╝\n", textColor: ConsoleColor.Magenta);


            #endregion


            #region Вывод результата запроса 7

            // вывод шапки таблицы
            public static void ShowHeadProc7()
            {
                WriteColorXY("     ╔════╦════════════╦════════════╦════════════╦════════════╦════════════╗\n", textColor: ConsoleColor.Magenta);
                WriteColorXY("     ║    ║            ║            ║            ║            ║            ║", textColor: ConsoleColor.Magenta);
                WriteColorXY("ID",                  7, textColor: ConsoleColor.DarkYellow);
                WriteColorXY("Тип издания",        12, textColor: ConsoleColor.DarkYellow);
                WriteColorXY("Количество",         25, textColor: ConsoleColor.DarkYellow);
                WriteColorXY("Мин. цена",          38, textColor: ConsoleColor.DarkYellow);
                WriteColorXY("Ср. цена",           51, textColor: ConsoleColor.DarkYellow);
                WriteColorXY("Макс. цена",         64, textColor: ConsoleColor.DarkYellow);
                Console.WriteLine();

                WriteColorXY("     ╠════╬════════════╬════════════╬════════════╬════════════╬════════════╣\n", textColor: ConsoleColor.Magenta);
            }


            // вывод записей таблицы
            public static void ShowElemProc7(SqlDataReader reader)
            {
                WriteColorXY("     ║    ║            ║            ║            ║            ║            ║", textColor: ConsoleColor.Magenta);
                WriteColorXY($"{reader.GetInt32(0)}",           7, textColor: ConsoleColor.DarkGray);
                WriteColorXY($"{reader.GetString(1)}",         12, textColor: ConsoleColor.DarkCyan);
                WriteColorXY($"{reader.GetInt32(2):n0}",       25, textColor: ConsoleColor.Green);
                WriteColorXY($"{reader.GetInt32(3):n0}",       38, textColor: ConsoleColor.DarkCyan);
                WriteColorXY($"{reader.GetInt32(4):n0}",       51, textColor: ConsoleColor.DarkCyan);
                WriteColorXY($"{reader.GetInt32(5):n0}",       64, textColor: ConsoleColor.DarkCyan);
                Console.WriteLine();

            }

            
            // вывод подвала таблицы
            public static void ShowLineProc7() =>
                WriteColorXY("     ╚════╩════════════╩════════════╩════════════╩════════════╩════════════╝\n", textColor: ConsoleColor.Magenta);


            #endregion


            #region Вывод результата запроса 8

            // вывод шапки таблицы
            public static void ShowHeadProc8()
            {
                WriteColorXY("     ╔════╦════════════════════════════════╦════════════╗\n", textColor: ConsoleColor.Magenta);
                WriteColorXY("     ║    ║                                ║            ║", textColor: ConsoleColor.Magenta);
                WriteColorXY("ID",                 7, textColor: ConsoleColor.DarkYellow);
                WriteColorXY("Индекс",            12, textColor: ConsoleColor.DarkYellow);
                WriteColorXY("Подписчики",        45, textColor: ConsoleColor.DarkYellow);
                Console.WriteLine();

                WriteColorXY("     ╠════╬════════════════════════════════╬════════════╣\n", textColor: ConsoleColor.Magenta);
            }


            // вывод записей таблицы
            public static void ShowElemProc8(SqlDataReader reader)
            {
                WriteColorXY("     ║    ║                                ║            ║", textColor: ConsoleColor.Magenta);
                WriteColorXY($"{reader.GetInt32(0)}",        7, textColor: ConsoleColor.DarkGray);
                WriteColorXY($"{reader.GetString(1)}",      12, textColor: ConsoleColor.DarkCyan);
                WriteColorXY($"{reader.GetInt32(2)}",       45, textColor: ConsoleColor.Green);
                Console.WriteLine();
            }

            // вывод подвала таблицы
            public static void ShowLineProc8() =>
                WriteColorXY("     ╚════╩════════════════════════════════╩════════════╝\n", textColor: ConsoleColor.Magenta);



            #endregion


            #region Вывод результата запроса 9

            // вывод шапки таблицы
            public static void ShowHeadProc9()
            {
                WriteColorXY("     ╔════╦════════════════════════════════╦════════════╗\n", textColor: ConsoleColor.Magenta);
                WriteColorXY("     ║    ║                                ║            ║", textColor: ConsoleColor.Magenta);
                WriteColorXY("ID",           7, textColor: ConsoleColor.DarkYellow);
                WriteColorXY("Индекс",      12, textColor: ConsoleColor.DarkYellow);
                WriteColorXY("Подписчики",  45, textColor: ConsoleColor.DarkYellow);
                Console.WriteLine();

                WriteColorXY("     ╠════╬════════════════════════════════╬════════════╣\n", textColor: ConsoleColor.Magenta);
            }


            // вывод записей таблицы
            public static void ShowElemProc9(SqlDataReader reader)
            {
                WriteColorXY("     ║    ║                                ║            ║", textColor: ConsoleColor.Magenta);
                WriteColorXY($"{reader.GetInt32(0)}",   7, textColor: ConsoleColor.DarkGray);
                WriteColorXY($"{reader.GetString(1)}", 12, textColor: ConsoleColor.DarkCyan);
                WriteColorXY($"{reader.GetInt32(2)}",  45, textColor: ConsoleColor.Green);
                Console.WriteLine();
            }

            // вывод подвала таблицы
            public static void ShowLineProc9() =>
                WriteColorXY("     ╚════╩════════════════════════════════╩════════════╝\n", textColor: ConsoleColor.Magenta);

            #endregion

            #endregion
        }
    }
}