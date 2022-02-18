using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using static HomeWork.Application.App.Utils;       // для использования утилит

namespace HomeWork.Application
{
    public partial class App
    {
        #region Задание 2. Оптовый магазин. Учет продаж

        /*
        * •	Задача 2. Для базы данных учета продаж оптового магазина из задания на 
        *   24.11.2021 разработайте и выполните запросы LINQ to SQL. Реализуйте два 
        *   варианта – с использованием синтаксиса запросов и с использованием 
        *   расширяющих методов.
        *   
        *   База данных «Оптовый магазин. Учет продаж»
        *   
        *   Описание предметной области
        *   Оптовый магазин закупает товар по Цене закупки единицы товара и продает 
        *   товар по Цене продажи единицы товара. Разница между ценой продажи и ценой
        *   закупки составляет прибыль магазина от реализации единицы товара.
        *   
        *   Каждый продавец получает комиссионное вознаграждение за проданный товар. 
        *   Размер этого вознаграждения равен: Цена продажи единицы товара * Кол-во 
        *   проданных единиц товара * Процент комиссионных продавца.
        *   Прибыль от продажи партии товара вычисляется как (Цена продажи единицы 
        *   товара - Цена закупки единицы товара) * Кол-во проданных единиц товара.
        *   
        *   База данных должна включать как минимум таблицы ТОВАРЫ, ПРОДАВЦЫ, ПРОДАЖИ, 
        *   содержащие следующую информацию:
        *   Наименование товара
        *   Единица измерения товара
        *   Цена закупки единицы товара
        *   Дата продажи товара
        *   Цена продажи единицы товара
        *   Количество проданных единиц товара
        *   Фамилия продавца, оформившего продажу
        *   Имя продавца, оформившего продажу
        *   Отчество продавца, оформившего продажу
        *   Процент комиссионных продавца, оформившего продажу
        *   
        *   Разработайте скрипты:
        *   1.	создания таблиц 
        *   2.	заполнения таблиц начальным набором данных. Каждая таблица должна 
        *       содержать не менее 10 записей.
        *   3.	Запросы SQL по заданию
        *   
        *   Запросы: 
        *   1	Запрос с параметрами	Выбирает из таблицы ТОВАРЫ информацию о 
        *       товарах, единицей измерения которых является «шт» (штуки) и цена
        *       закупки составляет меньше 200 руб.
        *       
        *   2	Запрос с параметрами	Выбирает из таблицы ТОВАРЫ информацию о 
        *       товарах, цена закупки которых больше 500 руб. за единицу товара
        *   
        *   3	Запрос с параметрами	Выбирает из таблицы ТОВАРЫ информацию о 
        *       товарах с заданным наименованием (например, «чехол защитный»), для
        *       которых цена закупки меньше 1800 руб.
        *       
        *   4	Запрос с параметрами	Выбирает из таблицы ПРОДАВЦЫ информацию 
        *       о продавцах с заданным значением процента комиссионных. 
        *       
        *   5	Запрос с параметрами	Выбирает из таблиц ТОВАРЫ, ПРОДАВЦЫ и 
        *       ПРОДАЖИ информацию обо всех зафиксированных фактах продажи товаров
        *       (Наименование товара, Цена закупки, Цена продажи, дата продажи), для 
        *       которых Цена продажи оказалась в некоторых заданных границах. 
        *       
        *   6	Запрос с вычисляемыми полями	Вычисляет прибыль от продажи за 
        *       каждый проданный товар. Включает поля Дата продажи, Наименование 
        *       товара, Цена закупки, Цена продажи, Количество проданных единиц, 
        *       Прибыль. Сортировка по полю Наименование товара
        *       
        *   При помощи запросов LINQ to SQL также выведите все таблицы Вашей базы данных.
        */

        // Задание 2. Оптовый магазин. Учет продаж. Запросы
        public void Task2Queries()
        {
            #region Меню

            // пункты меню 
            string[] points =
            {
                "1. Товары с еденицей измерения \"шт\" и цена закупки меньше 200 руб.",
                "2. Товары цена закупки, которых больше 500 руб.",
                "3. Товары с заданным наименованием и цена закупки меньше 1800 руб.",
                "4. Продавцы с заданным значением процента комисионных",
                "5. Факты продажи товаров, для которых цена продажи в заданном диапазоне",
                "6. Прибыль от продажи за каждый проданный товар. Сортировка по полю наименование товара"
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
                Console.SetCursorPosition(x + 3, y); WriteColor($"{"    Задание 2. Оптовый магазин. Учет продаж. Запросы"}", ConsoleColor.Blue);

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

                        // 1. Товары с еденицей измерения \"шт\" и цена закупки меньше 200 руб.
                        case ConsoleKey.NumPad1:
                            goto case ConsoleKey.D1;
                        case ConsoleKey.D1:
                            Console.Clear();
                            // запуск задания 
                            Point1();
                            break;

                        // 2. Товары цена закупки, которых больше 500 руб.
                        case ConsoleKey.NumPad2:
                            goto case ConsoleKey.D2;
                        case ConsoleKey.D2:
                            Console.Clear();
                            // запуск задания 
                            Point2();
                            break;

                        // 3. Товары с заданным наименованием и цена закупки меньше 1800 руб.
                        case ConsoleKey.NumPad3:
                            goto case ConsoleKey.D3;
                        case ConsoleKey.D3:
                            Console.Clear();
                            // запуск задания 
                            Point3();
                            break;

                        // 4. Продавцы с заданным значением процента комисионных
                        case ConsoleKey.NumPad4:
                            goto case ConsoleKey.D4;
                        case ConsoleKey.D4:
                            Console.Clear();
                            // запуск задания 
                            Point4();
                            break;

                        // 5. Факты продажи товаров, для которых цена продажи в заданном диапазоне
                        case ConsoleKey.NumPad5:
                            goto case ConsoleKey.D5;
                        case ConsoleKey.D5:
                            Console.Clear();
                            // запуск задания 
                            Point5();
                            break;

                        // 6. Прибыль от продажи за каждый проданный товар. Сортировка по полю наименование товара
                        case ConsoleKey.NumPad6:
                            goto case ConsoleKey.D6;
                        case ConsoleKey.D6:
                            Console.Clear();
                            // запуск задания 
                            Point6();
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

            #region 1. Товары с еденицей измерения \"шт\" и цена закупки меньше 200 руб.

            // 1. Товары с еденицей измерения \"шт\" и цена закупки меньше 200 руб.
            void Point1()
            {
                ShowNavBarMessage("1. Товары с еденицей измерения \"шт\" и цена закупки меньше 200 руб.");

                // вывод результата LINQ запроса
                ShowInfoLine("LINQ запрос");
                _task2Controller.ShowProc1Linq();

                Console.WriteLine();

                // вывод рузультата расширяющих методов
                ShowInfoLine("Расширяющие методы");
                _task2Controller.ShowProc1Extended();
            }

            #endregion

            #region 2. Товары цена закупки, которых больше 500 руб.

            // 2. Товары цена закупки, которых больше 500 руб.
            void Point2()
            {
                ShowNavBarMessage("2. Товары цена закупки, которых больше 500 руб.");

                // вывод результата LINQ запроса
                ShowInfoLine("LINQ запрос");
                _task2Controller.ShowProc2Linq();

                Console.WriteLine();

                // вывод рузультата расширяющих методов
                ShowInfoLine("Расширяющие методы");
                _task2Controller.ShowProc2Extended();
            }

            #endregion

            #region 3. Товары с заданным наименованием и цена закупки меньше 1800 руб.

            // 3. Товары с заданным наименованием и цена закупки меньше 1800 руб.
            void Point3()
            {
                ShowNavBarMessage("3. Товары с заданным наименованием и цена закупки меньше 1800 руб.");

                // наименование товара 
                string name = GetNameGoods();

                // вывод условий запроса
                ShowInfoLines("Параметры запроса", new[] { $"Заданное наименование товара: {name}" });

                // вывод результата LINQ запроса
                ShowInfoLine("LINQ запрос");
                _task2Controller.ShowProc3Linq(name);

                Console.WriteLine();

                // вывод рузультата расширяющих методов
                ShowInfoLine("Расширяющие методы");
                _task2Controller.ShowProc3Extended(name);
            }

            #endregion

            #region 4. Продавцы с заданным значением процента комисионных

            // 4. Продавцы с заданным значением процента комисионных
            void Point4()
            {
                ShowNavBarMessage("4. Продавцы с заданным значением процента комисионных");

                // процент коммисионных
                double interest = GetInterestSeller();

                // вывод условий запроса
                ShowInfoLines("Параметры запроса", new[] { $"Заданный процент коммисионных: {interest:n1}" });

                // вывод результата LINQ запроса
                ShowInfoLine("LINQ запрос");
                _task2Controller.ShowProc4Linq(interest);

                Console.WriteLine();

                // вывод рузультата расширяющих методов
                ShowInfoLine("Расширяющие методы");
                _task2Controller.ShowProc4Extended(interest);

            }

            #endregion

            #region 5. Факты продажи товаров, для которых цена продажи в заданном диапазоне

            // 5. Факты продажи товаров, для которых цена продажи в заданном диапазоне
            void Point5()
            {
                ShowNavBarMessage("5. Факты продажи товаров, для которых цена продажи в заданном диапазоне");

                // диапазон цены продажи
                int lo = rand.Next(5, 10) * 100, hi = lo + rand.Next(2, 3) * 100;

                // вывод условий запроса
                ShowInfoLines("Параметры запроса", new[] { $"Заданный диапазон цены: {lo} - {hi}" });

                // вывод результата LINQ запроса
                ShowInfoLine("LINQ запрос");
                _task2Controller.ShowProc5Linq(lo, hi);

                Console.WriteLine();

                // вывод рузультата расширяющих методов
                ShowInfoLine("Расширяющие методы");
                _task2Controller.ShowProc5Extended(lo, hi);

            }

            #endregion

            #region 6. Прибыль от продажи за каждый проданный товар. Сортировка по полю наименование товара

            // 6. Прибыль от продажи за каждый проданный товар. Сортировка по полю наименование товара
            void Point6()
            {
                ShowNavBarMessage("6. Прибыль от продажи за каждый проданный товар. Сортировка по полю наименование товара");

                // вывод результата LINQ запроса
                ShowInfoLine("LINQ запрос");
                _task2Controller.ShowProc6Linq();

                Console.WriteLine();

                // вывод рузультата расширяющих методов
                ShowInfoLine("Расширяющие методы");
                _task2Controller.ShowProc6Extended();
            }

            #endregion
        }

        #endregion

    }
}
