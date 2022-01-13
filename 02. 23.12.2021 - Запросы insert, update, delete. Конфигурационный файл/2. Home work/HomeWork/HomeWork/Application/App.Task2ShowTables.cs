using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;        // для работы в SQL
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HomeWork.Models.Task2;        // модели задания 2
using HomeWork.Models;              // модели
using System.Data;

using static HomeWork.Application.App.Utils;       // для использования утилит

namespace HomeWork.Application
{
    public partial class App
    {
        #region 1. Просмотр содержимого таблиц задания 2

        /*
         * 1. Просмотр содержимого таблиц задания 2
         */

        // 1. Просмотр содержимого таблиц задания 2
        public void Task2ShowTables()
        {
            #region Меню

            // пункты меню 
            string[] points =
            {
                "1. Таблица - Rentals       (Факты_проката)",
                "2. Таблица - Cars	        (Машины)",
                "3. Таблица - Clients       (Клиенты)",
                "4. Таблица - Colors        (Цвета)",
                "5. Таблица - Brands        (Модели_автомобилей)",
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

                        // 1. Таблица - Rentals		(Факты_проката)
                        case ConsoleKey.NumPad1:
                            goto case ConsoleKey.D1;
                        case ConsoleKey.D1:
                            Console.Clear();
                            // запуск задания 
                            Point1();
                            break;

                        // 2. Таблица - Cars		(Машины)
                        case ConsoleKey.NumPad2:
                            goto case ConsoleKey.D2;
                        case ConsoleKey.D2:
                            Console.Clear();
                            // запуск задания 
                            Point2();
                            break;

                        // 3. Таблица - Clients		(Клиенты)
                        case ConsoleKey.NumPad3:
                            goto case ConsoleKey.D3;
                        case ConsoleKey.D3:
                            Console.Clear();
                            // запуск задания 
                            Point3();
                            break;

                        // 4. Таблица - Colors		(цвета)
                        case ConsoleKey.NumPad4:
                            goto case ConsoleKey.D4;
                        case ConsoleKey.D4:
                            Console.Clear();
                            // запуск задания 
                            Point4();
                            break;

                        // 5. Таблица - Brands		(Модели_автомобилей)
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

            #region 1. Таблица - Rentals		(Факты_проката)

            // 1. Таблица - Rentals		(Факты_проката)
            void Point1()
            {
                ShowNavBarMessage("1. Таблица - Rentals		(Факты_проката)");

                using (SqlConnection connection = new SqlConnection(_connectionStringTask2))
                {
                    // подключение к серверу
                    connection.Open();

                    // создание запроса
                    SqlCommand cmd = new SqlCommand(@"ShowRentals");

                    // установка соединения с базой данных
                    cmd.Connection = connection;

                    // установка типа запроса
                    cmd.CommandType = CommandType.StoredProcedure;

                    // получение результата
                    SqlDataReader dataReader = cmd.ExecuteReader();

                    // вывод результата
                    new ShowModelRentals(dataReader).ShowData();
                }
            }

            #endregion

            #region 2. Таблица - Cars		(Машины)

            // 2. Таблица - Cars		(Машины)
            void Point2()
            {
                ShowNavBarMessage("2. Таблица - Cars		(Машины)");

                using (SqlConnection connection = new SqlConnection(_connectionStringTask2))
                {
                    // подключение к серверу
                    connection.Open();

                    // создание запроса
                    SqlCommand cmd = new SqlCommand("ShowCars");

                    // установка соединения с базой данных
                    cmd.Connection = connection;

                    // установка типа запроса
                    cmd.CommandType = CommandType.StoredProcedure;

                    // получение результата
                    SqlDataReader dataReader = cmd.ExecuteReader();

                    // вывод результата
                    new ShowModelCars(dataReader).ShowData();
                }
            }

            #endregion

            #region 3. Таблица - Clients		(Клиенты)

            // 3. Таблица - Clients		(Клиенты)
            void Point3()
            {
                ShowNavBarMessage("3. Таблица - Clients		(Клиенты)");

                using (SqlConnection connection = new SqlConnection(_connectionStringTask2))
                {
                    // открыть подключение 
                    connection.Open();

                    // создание комманды
                    SqlCommand command = new SqlCommand("ShowClients");

                    // установка соединения
                    command.Connection = connection;

                    // установка типа запроса
                    command.CommandType = CommandType.StoredProcedure;

                    // получение результата
                    SqlDataReader dataReader = command.ExecuteReader();

                    // вывод результата
                    new ShowModelClients(dataReader).ShowData();
                }
            }

            #endregion

            #region 4. Таблица - Colors		(цвета)

            // 4. Таблица - Colors		(цвета)
            void Point4()
            {
                ShowNavBarMessage("4. Таблица - Colors		(цвета)");

                using (SqlConnection connection = new SqlConnection(_connectionStringTask2))
                {
                    // открытие подключения
                    connection.Open();

                    // создание команды
                    SqlCommand command = new SqlCommand("ShowColors");

                    // установка соединения
                    command.Connection = connection;

                    // устновка типа запроса
                    command.CommandType = CommandType.StoredProcedure;

                    // получение результата
                    SqlDataReader dataReader = command.ExecuteReader();

                    // вывод результата
                    new ShowModelColors(dataReader).ShowData();
                }
            }

            #endregion

            #region 5. Таблица - Brands		(Модели_автомобилей)

            // 5. Таблица - Brands		(Модели_автомобилей)
            void Point5()
            {
                ShowNavBarMessage("5. Таблица - Brands		(Модели_автомобилей)");

                using (SqlConnection connection = new SqlConnection(_connectionStringTask2))
                {
                    // открытие соединения
                    connection.Open();

                    // создание команды
                    SqlCommand command = new SqlCommand("ShowBrands");

                    // установка соединения
                    command.Connection = connection;

                    // устанвока типа запроса
                    command.CommandType = CommandType.StoredProcedure;

                    // получение результата
                    SqlDataReader dataReader = command.ExecuteReader();

                    // вывод результата
                    new ShowModelBrands(dataReader).ShowData(); 
                }
            }

            #endregion

        }

        #endregion
    }
}
