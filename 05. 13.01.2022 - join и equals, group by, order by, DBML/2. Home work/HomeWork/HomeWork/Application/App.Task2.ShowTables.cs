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

        // Задание 2. Оптовый магазин. Учет продаж. Содержание таблиц
        public void Task2ShowTables()
        {
            #region Меню

            // пункты меню 
            string[] points =
            {
                "1. Вывод всех записей таблицы Units            (Единицы_измерения)",
                "2. Вывод всех записей таблицы Goods            (Товары)",
                "3. Вывод всех записей таблицы Sellers          (Продавцы)",
                "4. Вывод всех записей таблицы Purchases        (Закупки)",
                "5. Вывод всех записей таблицы Sales            (Продажи)"
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
                Console.SetCursorPosition(x + 3, y); WriteColor($"{"    Задание 2. Оптовый магазин. Учет продаж. Содержание таблиц"}", ConsoleColor.Blue);

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

                        // 1. Вывод всех записей таблицы Units            (Единицы_измерения)
                        case ConsoleKey.NumPad1:
                            goto case ConsoleKey.D1;
                        case ConsoleKey.D1:
                            Console.Clear();
                            // запуск задания 
                            Point1();
                            break;

                        // 2. Вывод всех записей таблицы Goods            (Товары)
                        case ConsoleKey.NumPad2:
                            goto case ConsoleKey.D2;
                        case ConsoleKey.D2:
                            Console.Clear();
                            // запуск задания 
                            Point2();
                            break;

                        // 3. Вывод всех записей таблицы Sellers          (Продавцы)
                        case ConsoleKey.NumPad3:
                            goto case ConsoleKey.D3;
                        case ConsoleKey.D3:
                            Console.Clear();
                            // запуск задания 
                            Point3();
                            break;

                        // 4. Вывод всех записей таблицы Purchases        (Закупки)
                        case ConsoleKey.NumPad4:
                            goto case ConsoleKey.D4;
                        case ConsoleKey.D4:
                            Console.Clear();
                            // запуск задания 
                            Point4();
                            break;

                        // 5. Вывод всех записей таблицы Sales            (Продажи)
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

            #region 1. Вывод всех записей таблицы Units            (Единицы_измерения)

            // 1. Вывод всех записей таблицы Units            (Единицы_измерения)
            void Point1()
            {
                ShowNavBarMessage("1. Вывод всех записей таблицы Units            (Единицы_измерения)");

                // вывод данных
                _task2Controller.ShowUnits();
            }

            #endregion

            #region 2. Вывод всех записей таблицы Goods            (Товары)

            // 2. Вывод всех записей таблицы Goods            (Товары)
            void Point2()
            {
                ShowNavBarMessage("2. Вывод всех записей таблицы Goods            (Товары)");

                // вывод данных
                _task2Controller.ShowGoods();
            }

            #endregion

            #region 3. Вывод всех записей таблицы Sellers          (Продавцы)

            // 3. Вывод всех записей таблицы Sellers          (Продавцы)
            void Point3()
            {
                ShowNavBarMessage("3. Вывод всех записей таблицы Sellers          (Продавцы)");

                // вывод данных
                _task2Controller.ShowSellers();
            }

            #endregion

            #region 4. Вывод всех записей таблицы Purchases        (Закупки)

            // 4. Вывод всех записей таблицы Purchases        (Закупки)
            void Point4()
            {
                ShowNavBarMessage("4. Вывод всех записей таблицы Purchases        (Закупки)");

                // вывод данных
                _task2Controller.ShowPurchases();
            }

            #endregion

            #region 5. Вывод всех записей таблицы Sales            (Продажи)

            // 5. Вывод всех записей таблицы Sales            (Продажи)
            void Point5()
            {
                ShowNavBarMessage("5. Вывод всех записей таблицы Sales            (Продажи)");

                // вывод данных
                _task2Controller.ShowSales();
            }

            #endregion

        }

        #endregion

    }
}
