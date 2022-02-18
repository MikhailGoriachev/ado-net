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
        #region Задание 1. Книги

        /*
         * •	Задача 1. Даны две связанные коллекции – описание книг и авторов книг. Объект класса 
         *      Книга имеет следующие поля: идентификатор, идентификатор автора, название книги, год 
         *      издания, цена. Поля объекта класса Автор: идентификатор, фамилия и инициалы, год рождения. 
         *      
         *      Требуется реализовать запросы к коллекциям, использовать два варианта – синтаксис запросов и
         *      синтаксис расширяющих функций.  
         *      
         *      o	Вывести все книги коллекции, выводить фамилии и инициалы автора
         *      o	Вывести книги авторов, год рождения которых принадлежит заданном диапазону 
         *      o	Вывести книги, в названии которых содержится заданная подстрока и цена не превышает 
         *          заданного значения
         *      o	Список авторов и количество их книг в коллекции
         *      o	Средняя цена книг по годам издания
         *      o	Список авторов по убыванию количества их книг в коллекции 
         *      o	Средний возраст книг по авторам, выводить список с упорядочиванием фамилий и инициалов
         *          авторов по алфавиту
         */

        // Задание 1. Книги
        public void Task1()
        {
            #region Меню

            // пункты меню 
            string[] points =
            {
                "1. Вывод всех книг",
                "2. Книги авторов, год рождения которых принадлежит заданном диапазону",
                "3. Книги, с заданной подстрокой в названии и с ценой меньше заданного значения",
                "4. Список авторов и количество их книг в коллекции",
                "5. Средняя цена книг по годам издания",
                "6. Список авторов по убыванию количества их книг в коллекции",
                "7. Средний возраст книг по авторам, по убыванию фамилии и инициалов"
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
                Console.SetCursorPosition(x + 3, y); WriteColor($"{"    Задание 1. Книги"}", ConsoleColor.Blue);

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

                        // 1. Вывод всех книг
                        case ConsoleKey.NumPad1:
                            goto case ConsoleKey.D1;
                        case ConsoleKey.D1:
                            Console.Clear();
                            // запуск задания 
                            Point1();
                            break;

                        // 2. Книги авторов, год рождения которых принадлежит заданном диапазону
                        case ConsoleKey.NumPad2:
                            goto case ConsoleKey.D2;
                        case ConsoleKey.D2:
                            Console.Clear();
                            // запуск задания 
                            Point2();
                            break;

                        // 3. Книги, с заданной подстрокой в названии и с ценой меньше заданного значения
                        case ConsoleKey.NumPad3:
                            goto case ConsoleKey.D3;
                        case ConsoleKey.D3:
                            Console.Clear();
                            // запуск задания 
                            Point3();
                            break;

                        // 4. Список авторов и количество их книг в коллекции
                        case ConsoleKey.NumPad4:
                            goto case ConsoleKey.D4;
                        case ConsoleKey.D4:
                            Console.Clear();
                            // запуск задания 
                            Point4();
                            break;

                        // 5. Средняя цена книг по годам издания
                        case ConsoleKey.NumPad5:
                            goto case ConsoleKey.D5;
                        case ConsoleKey.D5:
                            Console.Clear();
                            // запуск задания 
                            Point5();
                            break;

                        // 6. Список авторов по убыванию количества их книг в коллекции
                        case ConsoleKey.NumPad6:
                            goto case ConsoleKey.D6;
                        case ConsoleKey.D6:
                            Console.Clear();
                            // запуск задания 
                            Point6();
                            break;

                        // 7. Средний возраст книг по авторам, по убыванию фамилии и инициалов
                        case ConsoleKey.NumPad7:
                            goto case ConsoleKey.D7;
                        case ConsoleKey.D7:
                            Console.Clear();
                            // запуск задания 
                            Point7();
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


            #region 1. Вывод всех книг

            // 1. Вывод всех книг
            void Point1()
            {
                ShowNavBarMessage("1. Вывод всех книг");

                // вывод результата LINQ запроса
                ShowInfoLine("LINQ запрос");
                _task1Controller.ShowProc1Linq();

                Console.WriteLine();

                // вывод рузультата расширяющих методов
                ShowInfoLine("Расширяющие методы");
                _task1Controller.ShowProc1Extended();

            } // Point1

            #endregion


            #region 2. Книги авторов, год рождения которых принадлежит заданном диапазону

            // 2. Книги авторов, год рождения которых принадлежит заданном диапазону
            void Point2()
            {
                ShowNavBarMessage("2. Книги авторов, год рождения которых принадлежит заданном диапазону");

                // получение дапазона года рождения автора
                int lo = rand.Next(3, 7) * 10 + 1900, hi = lo + rand.Next(1, 3) * 10;

                // вывод условий запроса
                ShowInfoLines("Параметры запроса", new[] { $"Дипазон значений года рождения автора: {lo} - {hi}" });


                // вывод результата LINQ запроса
                ShowInfoLine("LINQ запрос");
                _task1Controller.ShowProc2Linq(lo, hi);

                Console.WriteLine();

                // вывод рузультата расширяющих методов
                ShowInfoLine("Расширяющие методы");
                _task1Controller.ShowProc2Extended(lo, hi);


            } // Point2

            #endregion


            #region 3. Книги, с заданной подстрокой в названии и с ценой меньше заданного значения

            // 3. Книги, с заданной подстрокой в названии и с ценой меньше заданного значения
            void Point3()
            {
                ShowNavBarMessage("3. Книги, с заданной подстрокой в названии и с ценой меньше заданного значения");

                // подстрока
                string str = GetSubstringTitle();

                // цена
                int price = rand.Next(3, 6) * 1000;

                // вывод условий запроса
                ShowInfoLines("Параметры запроса", new[] { $"Подстрока для поиска: {str}", $"Максимальная цена: {price}" });

                // вывод результата LINQ запроса
                ShowInfoLine("LINQ запрос");
                _task1Controller.ShowProc3Linq(str, price);

                Console.WriteLine();

                // вывод рузультата расширяющих методов
                ShowInfoLine("Расширяющие методы");
                _task1Controller.ShowProc3Extended(str, price);
            }

            #endregion


            #region 4. Список авторов и количество их книг в коллекции

            // 4. Список авторов и количество их книг в коллекции
            void Point4()
            {
                ShowNavBarMessage("4. Список авторов и количество их книг в коллекции");

                // вывод результата LINQ запроса
                ShowInfoLine("LINQ запрос");
                _task1Controller.ShowProc4Linq();

                Console.WriteLine();

                // вывод рузультата расширяющих методов
                ShowInfoLine("Расширяющие методы");
                _task1Controller.ShowProc4Extended();
            }

            #endregion


            #region 5. Средняя цена книг по годам издания

            // 5. Средняя цена книг по годам издания
            void Point5()
            {
                ShowNavBarMessage("5. Средняя цена книг по годам издания");

                // вывод результата LINQ запроса
                ShowInfoLine("LINQ запрос");
                _task1Controller.ShowProc5Linq();

                Console.WriteLine();

                // вывод рузультата расширяющих методов
                ShowInfoLine("Расширяющие методы");
                _task1Controller.ShowProc5Extended();
            }

            #endregion


            #region 6. Список авторов по убыванию количества их книг в коллекции

            // 6. Список авторов по убыванию количества их книг в коллекции
            void Point6()
            {
                ShowNavBarMessage("6. Список авторов по убыванию количества их книг в коллекции");

                // вывод результата LINQ запроса
                ShowInfoLine("LINQ запрос");
                _task1Controller.ShowProc6Linq();

                Console.WriteLine();

                // вывод рузультата расширяющих методов
                ShowInfoLine("Расширяющие методы");
                _task1Controller.ShowProc6Extended();
            }

            #endregion


            #region 7. Средний возраст книг по авторам, по убыванию фамилии и инициалов

            // 7. Средний возраст книг по авторам, по убыванию фамилии и инициалов
            void Point7()
            {
                ShowNavBarMessage("7. Средний возраст книг по авторам, по убыванию фамилии и инициалов");

                // вывод результата LINQ запроса
                ShowInfoLine("LINQ запрос");
                _task1Controller.ShowProc7Linq();

                Console.WriteLine();

                // вывод рузультата расширяющих методов
                ShowInfoLine("Расширяющие методы");
                _task1Controller.ShowProc7Extended();
            }

            #endregion
        }

        #endregion
    }
}
