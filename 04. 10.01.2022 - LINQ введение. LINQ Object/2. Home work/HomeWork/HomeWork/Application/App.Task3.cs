using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HomeWork.Models;          // модели
using HomeWork.Controllers;     // контроллеры

using static HomeWork.Application.App.Utils;       // для использования утилит

namespace HomeWork.Application
{
    public partial class App
    {
        #region Задание 3. Товары

        /*
        * •	Задача 3. Для коллекции товаров из задачи 1 выполнить следующие LINQ-запросы (создавайте 2
        *   варианта запросов – в синтаксисе LINQ и в синтаксисе расширяющих методов):
        *   o	товары с заданным диапазоном цен
        *   o	сумма товаров с заданным годом выпуска
        *   o	сумма товаров с заданным наименованием (суммируем произведение цены на количество, 
        *       наименование товара может быть задано частично, но без маски типа %, _)
        *   o	наименование и год выпуска товаров с максимальным количеством
        *   o	все товары, для которых произведение цены на количество находится в заданном диапазоне
        */

        // Задание 3. Товары
        public void Task3()
        {
            #region Меню

            // пункты меню 
            string[] points =
            {
                "1. Товары с заданным диапазоном цен",
                "2. Сумма товаров с заданным годом выпуска",
                "3. Сумма товаров с заданным наименованием",
                "4. Наименование и год выпуска товаров с максимальным количеством",
                "5. Все товары, для которых произведение цены на количество находится в заданном диапазоне"
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
                Console.SetCursorPosition(x + 3, y); WriteColor($"{"    Задание 3. Товары"}", ConsoleColor.Blue);

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

                        // 1. Товары с заданным диапазоном цен
                        case ConsoleKey.NumPad1:
                            goto case ConsoleKey.D1;
                        case ConsoleKey.D1:
                            Console.Clear();
                            // запуск задания 
                            Point1();
                            break;

                        // 2. Сумма товаров с заданным годом выпуска
                        case ConsoleKey.NumPad2:
                            goto case ConsoleKey.D2;
                        case ConsoleKey.D2:
                            Console.Clear();
                            // запуск задания 
                            Point2();
                            break;

                        // 3. Сумма товаров с заданным наименованием
                        case ConsoleKey.NumPad3:
                            goto case ConsoleKey.D3;
                        case ConsoleKey.D3:
                            Console.Clear();
                            // запуск задания 
                            Point3();
                            break;

                        // 4. Наименование и год выпуска товаров с максимальным количеством
                        case ConsoleKey.NumPad4:
                            goto case ConsoleKey.D4;
                        case ConsoleKey.D4:
                            Console.Clear();
                            // запуск задания 
                            Point4();
                            break;

                        // 5. Все товары, для которых произведение цены на количество находится в заданном диапазоне
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

            #region 1. Товары с заданным диапазоном цен

            // 1. Товары с заданным диапазоном цен
            void Point1()
            {
                ShowNavBarMessage("1. Товары с заданным диапазоном цен");

                // диапазон цен
                int lo = rand.Next(4, 15) * 100, hi = rand.Next(15, 30) * 100;

                // вывод инфорации о запросе
                ShowInfoLines("1. Товары с заданным диапазоном цен", new[] { $"Минимальная цена - {lo}", $"Максимальная цена - {hi}" });

                ShowInfo("Запрос LINQ");

                // запрос LINQ
                Goods.ShowTable(_controllerTask3.Proc1Linq(lo, hi));

                Console.WriteLine();

                ShowInfo("Запрос Extended Method");

                // запрос LINQ
                Goods.ShowTable(_controllerTask3.Proc1Extended(lo, hi));
            }

            #endregion

            #region 2. Сумма товаров с заданным годом выпуска

            // 2. Сумма товаров с заданным годом выпуска
            void Point2()
            {
                ShowNavBarMessage("2. Сумма товаров с заданным годом выпуска");

                // год выпуска
                int year = _controllerTask3.GoodsList[rand.Next(0, _controllerTask3.GoodsList.Count)].Year;

                // вывод инфорации о запросе
                ShowInfoLines("2. Сумма товаров с заданным годом выпуска", new[] { $"Заданный год выпуска - {year}" });

                // вывод товаров с заданным годом выпуска
                Goods.ShowTable(_controllerTask3.GoodsList.Where(g => g.Year == year).ToList());

                // вывод результата
                ShowInfoLines("Сумма товаров с заданным годом выпуска", new[] { $"Заданный год выпуска - {year}", 
                                                                                $"Сумма товаров (LINQ)    : {_controllerTask3.Proc2Linq(year)}",
                                                                                $"Сумма товаров (Extended): {_controllerTask3.Proc2Extended(year)}",
                                                                            });
            }

            #endregion

            #region 3. Сумма товаров с заданным наименованием

            // 3. Сумма товаров с заданным наименованием
            void Point3()
            {
                ShowNavBarMessage("3. Сумма товаров с заданным наименованием");

                // наименование
                string title = _controllerTask3.GoodsList[rand.Next(0, _controllerTask3.GoodsList.Count)].Title;

                // вывод инфорации о запросе
                ShowInfoLines("2. Сумма товаров с заданным наименованием", new[] { $"Заданное наименованием - {title}" });

                // вывод товаров с заданным наименованием
                Goods.ShowTable(_controllerTask3.GoodsList.Where(g => g.Title == title).ToList());

                // вывод результата
                ShowInfoLines("Сумма товаров с заданным годом выпуска", new[] { $"Заданное наименованием - {title}",
                                                                                $"Сумма товаров (LINQ)    : {_controllerTask3.Proc3Linq(title)}",
                                                                                $"Сумма товаров (Extended): {_controllerTask3.Proc3Extended(title)}",
                                                                            });
            }

            #endregion

            #region 4. Наименование и год выпуска товаров с максимальным количеством

            // 4. Наименование и год выпуска товаров с максимальным количеством
            void Point4()
            {
                ShowNavBarMessage("4. Наименование и год выпуска товаров с максимальным количеством");


                // вывод инфорации о запросе
                ShowInfo("4. Наименование и год выпуска товаров с максимальным количеством");

                ShowInfo("Запрос LINQ");

                // запрос LINQ
                Task3Controller.ShowTableProc4(_controllerTask3.Proc4Linq());

                Console.WriteLine();

                ShowInfo("Запрос Extended Method");

                // запрос LINQ
                Task3Controller.ShowTableProc4(_controllerTask3.Proc4Extended());

            }

            #endregion

            #region 5. Все товары, для которых произведение цены на количество находится в заданном диапазоне

            // 5. Все товары, для которых произведение цены на количество находится в заданном диапазоне
            void Point5()
            {
                ShowNavBarMessage("5. Все товары, для которых произведение цены на количество находится в заданном диапазоне");

                // диапазон цен
                (int lo, int hi) = GetRangeProdPriceAmountGoods(_controllerTask3.GoodsList);

                // вывод инфорации о запросе
                ShowInfoLines("5. Все товары, для которых произведение цены на количество находится в заданном диапазоне", 
                    new[] { $"Минимальное произведение  - {lo}", 
                            $"Максимальное произведение - {hi}" });

                ShowInfo("Запрос LINQ");

                // запрос LINQ
                Task3Controller.ShowTableProc5(_controllerTask3.Proc5Linq(lo, hi));

                Console.WriteLine();

                ShowInfo("Запрос Extended Method");

                // запрос LINQ
                Task3Controller.ShowTableProc5(_controllerTask3.Proc5Extended(lo, hi));

            }

            #endregion
        }

        #endregion

    }
}
