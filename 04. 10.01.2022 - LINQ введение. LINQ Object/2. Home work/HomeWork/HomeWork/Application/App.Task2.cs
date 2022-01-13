using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HomeWork.Controllers;     // контроллеры

using static HomeWork.Application.App.Utils;       // для использования утилит

namespace HomeWork.Application
{
    public partial class App
    {
        #region Задание 2. Массив

        /*
         * •	Задача 2. С использованием LINQ (создавайте 2 варианта запросов – в синтаксисе
         *      LINQ и в синтаксисе расширяющих методов) выполнить обработки для одномерного 
         *      массива из n вещественных элементов:
         *      o	Вычисление количества элементов массива, со значениями в диапазоне от A до B
         *      o	Вычисление количества элементов массива, равных 0
         *      o	Вычисление суммы элементов массива, расположенных после первого максимального
         *          элемента
         *      o	Вычисление суммы элементов массива, расположенных перед последним минимальным
         *          по модулю элементом
        */

        // Задание 2. Массив
        public void Task2()
        {
            #region Меню

            // пункты меню 
            string[] points =
            {
                "1. Вычисление количества элементов массива, со значениями в диапазоне от A до B",
                "2. Вычисление количества элементов массива, равных 0",
                "3. Вычисление суммы элементов массива, расположенных после первого максимального элемента",
                "4. Вычисление суммы элементов массива, расположенных перед последним минимальным по модулю элементом",
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
                Console.SetCursorPosition(x + 3, y); WriteColor($"{"    Задание 2. Массив"}", ConsoleColor.Blue);

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

                        // 1. Вычисление количества элементов массива, со значениями в диапазоне от A до B
                        case ConsoleKey.NumPad1:
                            goto case ConsoleKey.D1;
                        case ConsoleKey.D1:
                            Console.Clear();
                            // запуск задания 
                            Point1();
                            break;

                        // 2. Вычисление количества элементов массива, равных 0
                        case ConsoleKey.NumPad2:
                            goto case ConsoleKey.D2;
                        case ConsoleKey.D2:
                            Console.Clear();
                            // запуск задания 
                            Point2();
                            break;

                        // 3. Вычисление суммы элементов массива, расположенных после первого максимального элемента
                        case ConsoleKey.NumPad3:
                            goto case ConsoleKey.D3;
                        case ConsoleKey.D3:
                            Console.Clear();
                            // запуск задания 
                            Point3();
                            break;

                        // 4. Вычисление суммы элементов массива, расположенных перед последним минимальным по модулю элементом
                        case ConsoleKey.NumPad4:
                            goto case ConsoleKey.D4;
                        case ConsoleKey.D4:
                            Console.Clear();
                            // запуск задания 
                            Point4();
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

            #region 1. Вычисление количества элементов массива, со значениями в диапазоне от A до B

            // 1. Вычисление количества элементов массива, со значениями в диапазоне от A до B
            void Point1()
            {
                ShowNavBarMessage("1. Вычисление количества элементов массива, со значениями в диапазоне от A до B");

                // диапазон значений
                double a = GetDouble(2, 5), b = GetDouble(5, 10);
                

                Task2Controller.ShowTable<double>(_controllerTask2.ArrayDouble, Task2Controller.ShowDoubleArray, 
                        value => value.item >= a && value.item <= b, info: $"Элементы");

                ShowInfoLines("1.Вычисление количества элементов массива, со значениями в диапазоне от A до B", new[] { 
                                                        $"Диапазон {a:n2} - {b:n2}",
                                                        $"Количество элементов диапазона (LINQ)    : {_controllerTask2.CountRangeLinq(a, b)}",
                                                        $"Количество элементов диапазона (Extended): {_controllerTask2.CountRangeExtended(a, b)}"
                });
            }

            #endregion

            #region 2. Вычисление количества элементов массива, равных 0

            // 2. Вычисление количества элементов массива, равных 0
            void Point2()
            {
                ShowNavBarMessage("2. Вычисление количества элементов массива, равных 0");

                int n = rand.Next(1, 4);

                for (int i = 0; i < n; i++)
                {
                    _controllerTask2.ArrayDouble[rand.Next(0, _controllerTask2.ArrayDouble.Length)] = 0d;
                }

                Task2Controller.ShowTable<double>(_controllerTask2.ArrayDouble, Task2Controller.ShowDoubleArray, 
                                                    value => value.item == 0, info: $"Элементы");

                ShowInfoLines("2. Вычисление количества элементов массива, равных 0", new[] {
                                                        $"Количество элементов равных 0 (LINQ)    : {_controllerTask2.CountEqualsNullLinq()}",
                                                        $"Количество элементов равных 0 (Extended): {_controllerTask2.CountEqualsNullExtended()}"
                });
            }

            #endregion

            #region 3. Вычисление суммы элементов массива, расположенных после первого максимального элемента

            // 3. Вычисление суммы элементов массива, расположенных после первого максимального элемента
            void Point3()
            {
                ShowNavBarMessage("3. Вычисление суммы элементов массива, расположенных после первого максимального элемента");



                Task2Controller.ShowTable<double>(_controllerTask2.ArrayDouble, Task2Controller.ShowDoubleArray,
                                                value => value.i > _controllerTask2.GetFirstIndexMaxElem(), info: $"Элементы");

                ShowInfoLines("3. Вычисление суммы элементов массива, расположенных после первого максимального элемента", new[] {
                                                        $"Максимальный элемент - {_controllerTask2.ArrayDouble.Max():n2}",
                                                        $"Сумма (Extended): {_controllerTask2.SumAfterFirstMaxExtended():n2}"
                });
            }

            #endregion

            #region 4. Вычисление суммы элементов массива, расположенных перед последним минимальным по модулю элементом

            // 4. Вычисление суммы элементов массива, расположенных перед последним минимальным по модулю элементом
            void Point4()
            {
                ShowNavBarMessage("4. Вычисление суммы элементов массива, расположенных перед последним минимальным по модулю элементом");

                // индекс последнего минимального элемента
                int index = _controllerTask2.GetLastIndexMinElem();

                Task2Controller.ShowTable<double>(_controllerTask2.ArrayDouble, Task2Controller.ShowDoubleArray,
                                                value => value.i < index, info: $"Элементы");


                ShowInfoLines("4. Вычисление суммы элементов массива, расположенных перед последним минимальным по модулю элементом", new[] {
                                                        $"Минимальный элемент - {_controllerTask2.ArrayDouble.Min(i => Math.Abs(i)):n2}",
                                                        $"Сумма (Extended): {_controllerTask2.SumBeforeLastMinExtended():n2}"
                });
            }

            #endregion

        }

        #endregion

    }
}
