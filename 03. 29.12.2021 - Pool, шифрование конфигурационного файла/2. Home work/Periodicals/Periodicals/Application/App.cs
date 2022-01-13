using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using static Periodicals.Application.App.Utils;       // для использования утилит

/*
 * Условия заданий
*/

namespace Periodicals.Application
{
    public partial class App
    {

        #region Меню заданий 

        // меню заданий
        public void Menu()
        {
            // пункты меню 
            string[] points =
            {
                "1. Просмотр содрежания таблиц",
                "2. Выполнение запросов по заданию",
                "3. Выполнить шифрование конфигурационного файла",
                "4. Выполнить расшифровывание конфигурационного файла",
            };

            // вывод меню
            while (true)
            {
                // отчистка консоли
                Console.Clear();

                // цвет 
                Console.ForegroundColor = ConsoleColor.Cyan;

                // координаты курсора
                int x = 5, y = Console.CursorTop + 3;

                // заголовок
                Console.SetCursorPosition(x + 3, y); WriteColor($"{"    Главное меню"}", ConsoleColor.Blue);

                y += 2;

                // вывод пунктов меню
                Array.ForEach(points, item => WriteColorXY(item, x, y++));

                // вывод пункта выхода из приложения
                Console.SetCursorPosition(x, ++y); Console.WriteLine("0. Выход");

                y += 4;

                // ввод номера задания
                Console.SetCursorPosition(x, y); Console.Write("Введите номер задания: ");
                ConsoleKey num = Console.ReadKey().Key;

                // обработка ввода 
                switch (num)
                {
                    // выход
                    case ConsoleKey.NumPad0:
                        goto case ConsoleKey.D0;
                    case ConsoleKey.Escape:
                        goto case ConsoleKey.D0;
                    case ConsoleKey.D0:
                        // позициониаровние курсора 
                        Console.SetCursorPosition(2, y + 5);
                        return;

                    // 1. Просмотр содрежания таблиц
                    case ConsoleKey.NumPad1:
                        goto case ConsoleKey.D1;
                    case ConsoleKey.D1:
                        // запуск задания 
                        ShowTables();
                        break;

                    // 2. Выполнение запросов по заданию
                    case ConsoleKey.NumPad2:
                        goto case ConsoleKey.D2;
                    case ConsoleKey.D2:
                        // запуск задания 
                        ShowQueries();
                        break;

                    // 3. Выполнить шифрование конфигурационного файла
                    case ConsoleKey.NumPad3:
                        goto case ConsoleKey.D3;
                    case ConsoleKey.D3:
                        // запуск задания 
                        ProtectConfig();
                        break;

                    // 4. Выполнить расшифровывание конфигурационного файла
                    case ConsoleKey.NumPad4:
                        goto case ConsoleKey.D4;
                    case ConsoleKey.D4:
                        // запуск задания 
                        UnProtectConfig();
                        break;

                    // если номер задания невалиден
                    default:

                        // установка цвета
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.ForegroundColor = ConsoleColor.Black;

                        // позиционирование курсора
                        Console.SetCursorPosition(x, y); Console.WriteLine("         Номер задания невалиден!         ");

                        // выключение курсора
                        Console.CursorVisible = false;

                        // задержка времени
                        Thread.Sleep(1000);

                        // возвращение цвета
                        Console.ResetColor();

                        // включение курсора
                        Console.CursorVisible = true;

                        break;
                } // switch

                // если пункт меню 0
                if (num != ConsoleKey.D0 && num != ConsoleKey.NumPad0 && num != ConsoleKey.Escape)
                {
                    // ввод клавиши для продолжения 
                    WriteColor("\n\n\tНажмите на [Enter] для продолжения...", ConsoleColor.Cyan);
                    Console.CursorVisible = false;
                    while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
                    Console.CursorVisible = true;
                }

            }
        } // Menu

        #endregion

        #region Методы

        // зашифровать конфигурационный файл
        public void ProtectConfig()
        {
            ShowNavBarMessage("3. Выполнить шифрование конфигурационного файла");

            // шифрование файла
            _controller.ConfigProtected(true);

            // вывод содержания файла
            ShowFileContent("Конфигурацонный файл \"Home Work.exe.Config\"", ".\\Home Work.exe.Config");
        }

        // расшифровать конфигурационный файл
        public void UnProtectConfig()
        {
            ShowNavBarMessage("4. Выполнить расшифровывание конфигурационного файла");

            // расшифровывание файла
            _controller.ConfigProtected(false);

            // вывод содержания файла
            ShowFileContent("Конфигурацонный файл \"Home Work.exe.Config\"", ".\\Home Work.exe.Config");
        }

        #endregion

    }
}
