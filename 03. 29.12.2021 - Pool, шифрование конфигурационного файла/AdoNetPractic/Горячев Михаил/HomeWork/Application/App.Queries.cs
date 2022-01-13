using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;        // для работы с Sql
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HomeWork.Models.Task1;          // модели задания 1
using System.Data;

using static HomeWork.Application.App.Utils;       // для использования утилит

namespace HomeWork.Application
{
    public partial class App
    {
        #region 2. Обработки по заданию

        /*
        * 2. Обработки по заданию
        */

        // 2. Обработки по заданию
        public void Queries()
        {
            #region Меню

            // пункты меню 
            string[] points =
            {
                "1. Хранимая процедура",
                "2. Хранимая процедура",
                "3. Хранимая процедура",
                "4. Хранимая процедура",
                "5. Хранимая процедура",
                "6. Хранимая процедура",
                "7. Хранимая процедура",
                "8. Хранимая процедура",
                "9. Хранимая процедура"
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
                Console.SetCursorPosition(x + 3, y); WriteColor($"{"    2. Обработки по заданию"}", ConsoleColor.Blue);

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

                        // 1. Хранимая процедура
                        case ConsoleKey.NumPad1:
                            goto case ConsoleKey.D1;
                        case ConsoleKey.D1:
                            Console.Clear();
                            // запуск задания 
                            Point1();
                            break;

                        // 2. Хранимая процедура
                        case ConsoleKey.NumPad2:
                            goto case ConsoleKey.D2;
                        case ConsoleKey.D2:
                            Console.Clear();
                            // запуск задания 
                            Point2();
                            break;

                        // 3. Хранимая процедура
                        case ConsoleKey.NumPad3:
                            goto case ConsoleKey.D3;
                        case ConsoleKey.D3:
                            Console.Clear();
                            // запуск задания 
                            Point3();
                            break;

                        // 4. Хранимая процедура
                        case ConsoleKey.NumPad4:
                            goto case ConsoleKey.D4;
                        case ConsoleKey.D4:
                            Console.Clear();
                            // запуск задания 
                            Point4();
                            break;

                        // 5. Хранимая процедура
                        case ConsoleKey.NumPad5:
                            goto case ConsoleKey.D5;
                        case ConsoleKey.D5:
                            Console.Clear();
                            // запуск задания 
                            Point5();
                            break;

                        // 6. Хранимая процедура
                        case ConsoleKey.NumPad6:
                            goto case ConsoleKey.D6;
                        case ConsoleKey.D6:
                            Console.Clear();
                            // запуск задания 
                            Point6();
                            break;

                        // 7. Хранимая процедура
                        case ConsoleKey.NumPad7:
                            goto case ConsoleKey.D7;
                        case ConsoleKey.D7:
                            Console.Clear();
                            // запуск задания 
                            Point7();
                            break;

                        // 8. Хранимая процедура
                        case ConsoleKey.NumPad8:
                            goto case ConsoleKey.D8;
                        case ConsoleKey.D8:
                            Console.Clear();
                            // запуск задания 
                            Point8();
                            break;

                        // 9. Хранимая процедура
                        case ConsoleKey.NumPad9:
                            goto case ConsoleKey.D9;
                        case ConsoleKey.D9:
                            Console.Clear();
                            // запуск задания 
                            Point9();
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

            #region 1. Хранимая процедура

            // 1. Хранимая процедура
            void Point1()
            {
                /* 1	Хранимая процедура	
                 * Выбирает из таблицы КВАРТИРЫ информацию о 3-комнатных квартирах, расположенных
                 * на улице «Садовая». Значения задавать параметрами запроса
                */

                ShowNavBarMessage("1. Хранимая процедура");

                // вывод информации о запросе
                Utils.ShowInfoQuery("1. Хранимая процедура",
                    new[] { "Выбирает из таблицы КВАРТИРЫ информацию о 3-комнатных квартирах, расположенных",
                            "на улице «Садовая». Значения задавать параметрами запроса" });

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    // открытие соединения
                    connection.Open();

                    // создание комманды
                    SqlCommand command = new SqlCommand("Proc1");

                    // добавление параметров
                    command.Parameters.AddWithValue("@countRooms", 3);
                    command.Parameters.AddWithValue("@street", "Садовая");

                    // установка соединения
                    command.Connection = connection;

                    // установка типа запроса
                    command.CommandType = CommandType.StoredProcedure;

                    // получение результата
                    SqlDataReader dataReader = command.ExecuteReader();

                    // вывод результата
                    new ShowModelViewImmovables(dataReader).ShowData();
                }
            }

            #endregion

            #region 2. Хранимая процедура

            // 2. Хранимая процедура
            void Point2()
            {
                /* 2	Хранимая процедура	
                 * Выбирает из таблицы РИЭЛТОРЫ информацию о риэлторах, фамилия которых начинается 
                 * с буквы «И» и процент вознаграждения больше 10%. Значения задавать параметрами 
                 * запроса
                */

                ShowNavBarMessage("2. Хранимая процедура");

                // вывод информации о запросе
                Utils.ShowInfoQuery("2. Хранимая процедура",
                    new[] { "Выбирает из таблицы РИЭЛТОРЫ информацию о риэлторах, фамилия которых начинается",
                            "с буквы «И» и процент вознаграждения больше 10%. Значения задавать параметрами",
                            "запроса" });

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    // открытие соединения
                    connection.Open();

                    // создание команды
                    SqlCommand command = new SqlCommand("Proc2");

                    // добавление параметров
                    command.Parameters.AddWithValue("@lastName", "И");
                    command.Parameters.AddWithValue("@percent", 10d);

                    // установка соединения
                    command.Connection = connection;

                    // установка типа запроса
                    command.CommandType = CommandType.StoredProcedure;

                    // получение результата
                    SqlDataReader dataReader = command.ExecuteReader();

                    // вывод результата
                    new ShowModelViewRealtors(dataReader).ShowData();
                }
            }

            #endregion

            #region 3. Хранимая процедура

            // 3. Хранимая процедура
            void Point3()
            {
                /* 3	Хранимая процедура	
                 * Выбирает из таблицы КВАРТИРЫ информацию об 1-комнатных квартирах, цена на которые 
                 * находится в диапазоне от 900 000 руб. до 1000 000 руб. Значения задавать 
                 * параметрами запроса
                */


                ShowNavBarMessage("3. Хранимая процедура");

                // вывод информации о запросе
                Utils.ShowInfoQuery("3. Хранимая процедура",
                    new[] { "Выбирает из таблицы КВАРТИРЫ информацию об 1-комнатных квартирах, цена на которые",
                            "находится в диапазоне от 900 000 руб. до 1000 000 руб. Значения задавать",
                            "параметрами запроса" });


                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    // открытие соединения
                    connection.Open();

                    // создание команды
                    SqlCommand command = new SqlCommand("Proc3");

                    // добавление параметров
                    command.Parameters.AddWithValue("@countRooms", 1);
                    command.Parameters.AddWithValue("@priceLo", 900000);
                    command.Parameters.AddWithValue("@priceHi", 1000000);

                    // установка соединения
                    command.Connection = connection;

                    // установка типа запроса
                    command.CommandType = CommandType.StoredProcedure;

                    // получение результата
                    SqlDataReader dataReader = command.ExecuteReader();

                    // вывод результата
                    new ShowModelViewImmovables(dataReader).ShowData();
                }
            }

            #endregion

            #region 4. Хранимая процедура

            // 4. Хранимая процедура
            void Point4()
            {
                /* 4	Хранимая процедура	
                 * Выбирает из таблицы КВАРТИРЫ информацию о квартирах с заданным числом комнат. 
                 * Значения задавать параметрами запроса
                */


                ShowNavBarMessage("4. Хранимая процедура");

                // количество комнат
                int countRooms = Utils.GetRand(1, 4);

                // вывод информации о запросе
                Utils.ShowInfoQuery("4. Хранимая процедура",
                    new[] { "Выбирает из таблицы КВАРТИРЫ информацию о квартирах с заданным числом комнат.",
                            "Значения задавать параметрами запроса",
                            "",
                            $"Установленное количество комнат: {countRooms}"});

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    // открытие соединения
                    connection.Open();

                    // создание команды
                    SqlCommand command = new SqlCommand("Proc4");

                    // добавлени параметров
                    command.Parameters.AddWithValue("@countRooms", countRooms);

                    // установка соеднинения
                    command.Connection = connection;

                    // установка типа запроса
                    command.CommandType = CommandType.StoredProcedure;

                    // получение результата
                    SqlDataReader dataReader = command.ExecuteReader();

                    // вывод результата
                    new ShowModelViewImmovables(dataReader).ShowData();
                }
            }

            #endregion

            #region 5. Хранимая процедура

            // 5. Хранимая процедура
            void Point5()
            {
                /* 5	Хранимая процедура	
                 * Выбирает из таблицы КВАРТИРЫ информацию обо всех 2-комнатных квартирах, площадь
                 * которых есть значение из некоторого диапазона. Значения задавать параметрами запроса
                */


                ShowNavBarMessage("5. Хранимая процедура");

                // количество комнат
                int countRooms = 2;

                // диапазон площади квартиры
                double areaLo = Utils.GetRand(40, 50), areaHi = Utils.GetRand(50, 60);

                // вывод информации о запросе
                Utils.ShowInfoQuery("5. Хранимая процедура",
                    new[] { "Выбирает из таблицы КВАРТИРЫ информацию обо всех 2-комнатных квартирах, площадь",
                            "которых есть значение из некоторого диапазона. Значения задавать параметрами запроса" ,
                            "",
                            $"Заданный диапазон площади: {areaLo} - {areaHi}"});

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    // открытие соединения
                    connection.Open();

                    // создание команды
                    SqlCommand command = new SqlCommand("Proc5");

                    // добавление параметров
                    command.Parameters.AddWithValue("@countRooms", countRooms);
                    command.Parameters.AddWithValue("@areaLo", areaLo);
                    command.Parameters.AddWithValue("@areaHi", areaHi);

                    // установка соединения
                    command.Connection = connection;

                    // установка типа запроса
                    command.CommandType = CommandType.StoredProcedure;

                    // получение результата
                    SqlDataReader dataReader = command.ExecuteReader();

                    // вывод результата
                    new ShowModelViewImmovables(dataReader).ShowData();
                }
            }

            #endregion

            #region 6. Хранимая процедура

            // 6. Хранимая процедура
            void Point6()
            {
                /* 6	Хранимая процедура	
                 * Вычисляет для каждой оформленной сделки размер комиссионного вознаграждения риэлтора.
                 * Включает поля Фамилия риэлтора, Имя риэлтора, Отчество риэлтора, Дата сделки, Цена 
                 * квартиры, Комиссионные. Сортировка по полю Дата сделки
                */


                ShowNavBarMessage("6. Хранимая процедура");

                // вывод информации о запросе
                Utils.ShowInfoQuery("6. Хранимая процедура",
                    new[] { "Вычисляет для каждой оформленной сделки размер комиссионного вознаграждения риэлтора.",
                            "Включает поля Фамилия риэлтора, Имя риэлтора, Отчество риэлтора, Дата сделки, Цена",
                            "квартиры, Комиссионные. Сортировка по полю Дата сделки" });

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    // открытие соединения
                    connection.Open();

                    // создание команды
                    SqlCommand command = new SqlCommand("Proc6");

                    // установка соединения
                    command.Connection = connection;

                    // установка типа запроса
                    command.CommandType = CommandType.StoredProcedure;

                    // получение результата
                    SqlDataReader dataReader = command.ExecuteReader();

                    // вывод результата
                    new ShowModelViewTransactionQuery6(dataReader).ShowData();
                }
            }

            #endregion

            #region 7. Хранимая процедура

            // 7. Хранимая процедура
            void Point7()
            {
                /* 7	Хранимая процедура	
                 * Выбрать всех риэлторов, количество клиентов, оформивших с ним сделки и сумму сделок 
                 * риэлтора. Упорядочить выборку по убыванию суммы сделок.
                */

                ShowNavBarMessage("7. Хранимая процедура");

                // вывод информации о запросе
                Utils.ShowInfoQuery("7. Хранимая процедура",
                    new[] { "Выбрать всех риэлторов, количество клиентов, оформивших с ним сделки и сумму сделок",
                            "риэлтора. Упорядочить выборку по убыванию суммы сделок."});

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    // открытие соединения
                    connection.Open();

                    // создание команды
                    SqlCommand command = new SqlCommand("Proc7");

                    // установка соединения
                    command.Connection = connection;

                    // установка типа запроса
                    command.CommandType = CommandType.StoredProcedure;

                    // получение результата
                    SqlDataReader dataReader = command.ExecuteReader();

                    // вывод результата
                    new ShowModelViewRealtorsQuery7(dataReader).ShowData();
                }
            }

            #endregion

            #region 8. Хранимая процедура

            // 8. Хранимая процедура
            void Point8()
            {
                /* 8	Хранимая процедура	
                 * Для всех улиц вывести сумму сделок, упорядочить выборку по убыванию суммы сделки
                */

                ShowNavBarMessage("8. Хранимая процедура");

                // вывод информации о запросе
                Utils.ShowInfoQuery("8. Хранимая процедура",
                    new[] { "Для всех улиц вывести сумму сделок, упорядочить выборку по убыванию суммы сделки",
                            "риэлтора. Упорядочить выборку по убыванию суммы сделок." });

                using (SqlConnection connection = new SqlConnection(_connectionString)) 
                {
                    // открытие соединения
                    connection.Open();

                    // создание команды
                    SqlCommand command = new SqlCommand("Proc8");

                    // установка соединения
                    command.Connection = connection;

                    // установка типа запроса
                    command.CommandType = CommandType.StoredProcedure;

                    // получение результата
                    SqlDataReader dataReader = command.ExecuteReader();

                    // вывод результата
                    new ShowModelStreetsQuery8And9(dataReader).ShowData();
                }
            }

            #endregion

            #region 9. Хранимая процедура

            // 9. Хранимая процедура
            void Point9()
            {
                /* 9	Хранимая процедура	
                 * Для всех улиц вывести сумму сделок за заданный период, упорядочить выборку по убыванию 
                 * суммы сделки. Диапазон задавать параметрами запроса
                */

                ShowNavBarMessage("9. Хранимая процедура");

                // диапазон дат
                string minDate = "2021/01/01", maxDate = "2021/05/01";

                // вывод информации о запросе
                Utils.ShowInfoQuery("9. Хранимая процедура",
                    new[] { "Для всех улиц вывести сумму сделок за заданный период, упорядочить выборку по убыванию",
                            "суммы сделки. Диапазон задавать параметрами запроса",
                            "",
                            $"Заданный диапазон дат: {minDate} - {maxDate}"});

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    // открытие соединения
                    connection.Open();

                    // создание команды
                    SqlCommand command = new SqlCommand("Proc9");

                    // добавление параметров
                    command.Parameters.AddWithValue("@minDate", minDate);
                    command.Parameters.AddWithValue("@maxDate", maxDate);

                    // установка соединения
                    command.Connection = connection;

                    // установка типа запроса
                    command.CommandType = CommandType.StoredProcedure;

                    // получение результата
                    SqlDataReader dataReader = command.ExecuteReader();

                    // вывод результата
                    new ShowModelStreetsQuery8And9(dataReader).ShowData();
                }
            }

            #endregion

        }

        #region Общие методы


        #endregion

        #endregion

    }
}
