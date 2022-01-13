using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using static Periodicals.Application.App.Utils;       // для использования утилит

namespace Periodicals.Application
{
    public partial class App
    {
        #region 1. Просмотр содрежания таблиц

        /*
         * 1. Просмотр содрежания таблиц
         */

        // 1. Просмотр содрежания таблиц
        public void ShowTables()
        {
            #region Меню

            // пункты меню 
            string[] points =
            {
                "1. Таблица TypesOfEdition              (Виды изданий)",
                "2. Таблица Editions                    (Издания)",
                "3. Таблица Streets                     (Улицы)",
                "4. Таблица Subscribers                 (Подписчики)",
                "5. Таблица Delivery                    (Доставка)"
            };

            // нажатая клавиша
            ConsoleKey num;

            // вывод меню
            while (true)
            {
                // отчистка консоли
                Console.Clear();

                // цвет 
                Console.ForegroundColor = ConsoleColor.Cyan;

                int x = 5, y = Console.CursorTop + 3;

                // заголовок
                Console.SetCursorPosition(x + 3, y); WriteColor($"{"    1. Просмотр содрежания таблиц"}", ConsoleColor.Blue);

                y += 2;

                // вывод пунктов меню
                Array.ForEach(points, item => WriteColorXY(item, x, y++));

                // вывод пункта выхода из приложения
                Console.SetCursorPosition(x, ++y); Console.WriteLine("0. Выход");

                y += 4;

                // ввод номера задания
                Console.SetCursorPosition(x, y); Console.Write("Введите номер задания: ");
                num = Console.ReadKey().Key;

                try
                {

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

                        // 1. Таблица TypesOfEdition			  (Виды изданий)
                        case ConsoleKey.NumPad1:
                            goto case ConsoleKey.D1;
                        case ConsoleKey.D1:
                            Console.Clear();
                            // запуск задания 
                            Point1();
                            break;

                        // 2. Таблица Editions                  (Издания)
                        case ConsoleKey.NumPad2:
                            goto case ConsoleKey.D2;
                        case ConsoleKey.D2:
                            Console.Clear();
                            // запуск задания 
                            Point2();
                            break;

                        // 3. Таблица Streets                   (Улицы)
                        case ConsoleKey.NumPad3:
                            goto case ConsoleKey.D3;
                        case ConsoleKey.D3:
                            Console.Clear();
                            // запуск задания 
                            Point3();
                            break;

                        // 4. Таблица Subscribers               (Подписчики)
                        case ConsoleKey.NumPad4:
                            goto case ConsoleKey.D4;
                        case ConsoleKey.D4:
                            Console.Clear();
                            // запуск задания 
                            Point4();
                            break;

                        // 5. Таблица Delivery                  (Доставка)
                        case ConsoleKey.NumPad5:
                            goto case ConsoleKey.D5;
                        case ConsoleKey.D5:
                            Console.Clear();
                            // запуск задания 
                            Point5();
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
                } // try

                // стандартное исключение
                catch (Exception ex)
                {
                    Console.Clear();

                    // вывод сообщения об ошибке 
                    WriteColor(ex.Message, ConsoleColor.Red);
                    Console.WriteLine();
                    WriteColor(ex.StackTrace, ConsoleColor.Red);
                    Console.WriteLine();
                } // catch

                // обязательная часть
                finally
                {
                    // если пункт меню 0
                    if (num != ConsoleKey.D0 && num != ConsoleKey.NumPad0 && num != ConsoleKey.Escape)
                    {
                        // ввод клавиши для продолжения 
                        WriteColor("\n\n\tНажмите на [Enter] для продолжения...", ConsoleColor.Cyan);
                        Console.CursorVisible = false;
                        while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
                        Console.CursorVisible = true;
                    }
                } // finally
            } // while

            #endregion

            #region 1. Таблица TypesOfEdition			  (Виды изданий)

            // 1. Таблица TypesOfEdition			  (Виды изданий)
            void Point1()
            {
                ShowNavBarMessage("1. Таблица TypesOfEdition            (Виды изданий)");

                _controller.ShowTypesOfEdition();
            }

            #endregion

            #region 2. Таблица Editions                  (Издания)

            // 2. Таблица Editions                  (Издания)
            void Point2()
            {
                ShowNavBarMessage("2. Таблица Editions                  (Издания)");

                _controller.ShowEditions();
            }

            #endregion

            #region 3. Таблица Streets                   (Улицы)

            // 3. Таблица Streets                   (Улицы)
            void Point3()
            {                   
                ShowNavBarMessage("3. Таблица Streets                   (Улицы)");

                _controller.ShowStreets();
            }

            #endregion

            #region 4. Таблица Subscribers               (Подписчики)

            // 4. Таблица Subscribers               (Подписчики)
            void Point4()
            {
                ShowNavBarMessage("4. Таблица Subscribers               (Подписчики)");

                _controller.ShowSubscribers();
            }

            #endregion

            #region 5. Таблица Delivery                  (Доставка)

            // 5. Таблица Delivery                  (Доставка)
            void Point5()
            {
                ShowNavBarMessage("5. Таблица Delivery                  (Доставка)");

                _controller.ShowDelivery();
            }

            #endregion
        }

        #endregion
    }
}
