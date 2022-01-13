using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;        // для работы в SQL
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HomeWork.Models;              // модели

using static HomeWork.Application.App.Utils;       // для использования утилит

namespace HomeWork.Application
{
    public partial class App
    {
        #region 1. Просмотр содержимого таблиц

        /*
         * 1. Просмотр содержимого таблиц
         */

        // 1. Просмотр содержимого таблиц
        public void ShowTables()
        {
            #region Меню

            // пункты меню 
            string[] points =
            {
                "1. Таблица - Transactions (Сделки)",
                "2. Таблица - Immovables   (Недвижимость)",
                "3. Таблица - Realtors     (Риэлторы)",
                "4. Таблица - Owners       (Владельцы)",
                "5. Таблица - Streets      (Улицы)",
                "6. Таблица - Persons      (Персоны)"
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
                Console.SetCursorPosition(x + 3, y); WriteColor($"{"    1. Просмотр содержимого таблиц"}", ConsoleColor.Blue);

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

                        // 1. Таблица - Transactions (Сделки)
                        case ConsoleKey.NumPad1:
                            goto case ConsoleKey.D1;
                        case ConsoleKey.D1:
                            Console.Clear();
                            // запуск задания 
                            Point1();
                            break;

                        // 2. Таблица - Immovables   (Недвижимость)
                        case ConsoleKey.NumPad2:
                            goto case ConsoleKey.D2;
                        case ConsoleKey.D2:
                            Console.Clear();
                            // запуск задания 
                            Point2();
                            break;

                        // 3. Таблица - Realtors     (Риэлторы)
                        case ConsoleKey.NumPad3:
                            goto case ConsoleKey.D3;
                        case ConsoleKey.D3:
                            Console.Clear();
                            // запуск задания 
                            Point3();
                            break;

                        // 4. Таблица - Owners       (Владельцы)
                        case ConsoleKey.NumPad4:
                            goto case ConsoleKey.D4;
                        case ConsoleKey.D4:
                            Console.Clear();
                            // запуск задания 
                            Point4();
                            break;

                        // 5. Таблица - Streets      (Улицы)
                        case ConsoleKey.NumPad5:
                            goto case ConsoleKey.D5;
                        case ConsoleKey.D5:
                            Console.Clear();
                            // запуск задания 
                            Point5();
                            break;

                        // 6. Таблица - Persons      (Персоны)
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

            #region 1. Таблица - Transactions (Сделки)

            // 1. Таблица - Transactions (Сделки)
            void Point1()
            {
                ShowNavBarMessage("1. Таблица - Transactions (Сделки)");

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    // подключение к серверу
                    connection.Open();

                    // запрос для выбора всех записей таблицы Transaction
                    SqlCommand cmd = new SqlCommand(
                        @"select
                            	Id
                            	, Street + ' ' + ltrim(str(HomeNumber)) + '/' + ltrim(str(ApartmentNumber))		as [Address] 
                            	, Price
                            	, RealtorLastName + ' ' + substring(RealtorFirstName, 1, 1) + '. ' + substring(RealtorPatronymic, 1, 1) + '.'	as Realtor
                            	, RemunPercent		as RealtorPercent
                            	, OwnerLastName + ' ' + substring(OwnerFirstName, 1, 1) + '. ' + substring(OwnerPatronymic, 1, 1) + '.'	as [Owner]
                            	, Passport
                            	, DateTrans
                            from
                            	ViewTransactions;"
                        );

                    
                    // установка соединения с базой данных
                    cmd.Connection = connection;

                    // получение результата
                    SqlDataReader dataReader = cmd.ExecuteReader();

                    // вывод результата
                    new ShowModelViewTransaction(dataReader).ShowData();
                }
            }

            #endregion

            #region 2. Таблица - Immovables   (Недвижимость)

            // 2. Таблица - Immovables   (Недвижимость)
            void Point2()
            {
                ShowNavBarMessage("2. Таблица - Immovables   (Недвижимость)");

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    // подключение к серверу
                    connection.Open();

                    // запрос для выбора всех записей таблицы Transaction
                    SqlCommand cmd = new SqlCommand(
                        @"select
                            	*
                            from
                            	ViewImmovables;"
                        );


                    // установка соединения с базой данных
                    cmd.Connection = connection;

                    // получение результата
                    SqlDataReader dataReader = cmd.ExecuteReader();

                    // вывод результата
                    new ShowModelViewImmovables(dataReader).ShowData();
                }
            }

            #endregion

            #region 3. Таблица - Realtors     (Риэлторы)

            // 3. Таблица - Realtors     (Риэлторы)
            void Point3()
            {
                ShowNavBarMessage("3. Таблица - Realtors     (Риэлторы)");

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    // открыть подключение 
                    connection.Open();

                    // создание комманды
                    SqlCommand command = new SqlCommand(
                        @"select
                               *
                          from
                               ViewRealtors"
                        );

                    // установка соединения
                    command.Connection = connection;

                    // получение результата
                    SqlDataReader dataReader = command.ExecuteReader();

                    // вывод результата
                    new ShowModelViewRealtors(dataReader).ShowData();
                }
            }

            #endregion

            #region 4. Таблица - Owners       (Владельцы)

            // 4. Таблица - Owners       (Владельцы)
            void Point4()
            {
                ShowNavBarMessage("4. Таблица - Owners       (Владельцы)");

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    // открытие подключения
                    connection.Open();

                    // создание команды
                    SqlCommand command = new SqlCommand(
                        @"select
                               *
                          from
                               ViewOwners"
                        );

                    // установка соединения
                    command.Connection = connection;

                    // получение результата
                    SqlDataReader dataReader = command.ExecuteReader();

                    // вывод результата
                    new ShowModelViewOwners(dataReader).ShowData();
                }
            }

            #endregion

            #region 5. Таблица - Streets      (Улицы)

            // 5. Таблица - Streets      (Улицы)
            void Point5()
            {
                ShowNavBarMessage("5. Таблица - Streets      (Улицы)");

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    // открытие соединения
                    connection.Open();

                    // создание команды
                    SqlCommand command = new SqlCommand(
                        @"select
                               *
                          from
                               Streets"
                        );

                    // установка соединения
                    command.Connection = connection;

                    // получение результата
                    SqlDataReader dataReader = command.ExecuteReader();

                    // вывод результата
                    new ShowModelStreets(dataReader).ShowData(); 
                }
            }

            #endregion

            #region 6. Таблица - Persons      (Персоны)

            // 6. Таблица - Persons      (Персоны)
            void Point6()
            {
                ShowNavBarMessage("6. Таблица - Persons      (Персоны)");

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    // открытие соединения
                    connection.Open();

                    // создание команды
                    SqlCommand command = new SqlCommand(
                        @"select
                               *
                          from
                               Persons"
                        );

                    // установка соединения
                    command.Connection = connection;

                    // получение результата
                    SqlDataReader dataReader = command.ExecuteReader();

                    // вывод результата
                    new ShowModelPersons(dataReader).ShowData();
                }
            }

            #endregion
        }

        #endregion
    }
}
