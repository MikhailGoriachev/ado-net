using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using static HomeWork.Application.App.Utils;       // для использования утилит

/*
 * Условия заданий
*/

namespace HomeWork.Application
{
    public partial class App
    {
        #region Меню задания 2

        // меню задания 2
        public void Task2Menu()
        {
            // пункты меню 
            string[] points =
            {
                "1. Просмотр содержимого таблиц",
                "2. Обработки по заданию"
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
                Console.SetCursorPosition(x + 3, y); WriteColor($"{"    Прокат автомобилей"}", ConsoleColor.Blue);

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

                    // 1. Просмотр содержимого таблиц
                    case ConsoleKey.NumPad1:
                        goto case ConsoleKey.D1;
                    case ConsoleKey.D1:
                        // запуск задания 
                        Task2ShowTables();
                        break;

                    // 2. Обработки по заданию
                    case ConsoleKey.NumPad2:
                        goto case ConsoleKey.D2;
                    case ConsoleKey.D2:
                        // запуск задания 
                        Task2Queries();
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
            }
        } // Menu

        #endregion

    }
}
