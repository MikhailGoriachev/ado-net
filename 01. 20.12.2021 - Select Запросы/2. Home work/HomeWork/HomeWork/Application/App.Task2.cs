using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;        // для работы с Sql
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HomeWork.Models;          // модели

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
        public void DemoTask()
        {
            #region Меню

            // пункты меню 
            string[] points =
            {
                "1. Запрос с параметрами",
                "2. Запрос с параметрами",
                "3. Запрос с параметрами",
                "4. Запрос с параметрами",
                "5. Запрос с параметрами",
                "6. Запрос с вычисляемыми полями",
                "7. Запрос на левое соединение",
                "8. Запрос на левое соединение",
                "9. Запрос на левое соединение"
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

                        // 1. Запрос с параметрами
                        case ConsoleKey.NumPad1:
                            goto case ConsoleKey.D1;
                        case ConsoleKey.D1:
                            Console.Clear();
                            // запуск задания 
                            Point1();
                            break;

                        // 2. Запрос с параметрами
                        case ConsoleKey.NumPad2:
                            goto case ConsoleKey.D2;
                        case ConsoleKey.D2:
                            Console.Clear();
                            // запуск задания 
                            Point2();
                            break;

                        // 3. Запрос с параметрами
                        case ConsoleKey.NumPad3:
                            goto case ConsoleKey.D3;
                        case ConsoleKey.D3:
                            Console.Clear();
                            // запуск задания 
                            Point3();
                            break;

                        // 4. Запрос с параметрами
                        case ConsoleKey.NumPad4:
                            goto case ConsoleKey.D4;
                        case ConsoleKey.D4:
                            Console.Clear();
                            // запуск задания 
                            Point4();
                            break;

                        // 5. Запрос с параметрами
                        case ConsoleKey.NumPad5:
                            goto case ConsoleKey.D5;
                        case ConsoleKey.D5:
                            Console.Clear();
                            // запуск задания 
                            Point5();
                            break;

                        // 6. Запрос с вычисляемыми полями
                        case ConsoleKey.NumPad6:
                            goto case ConsoleKey.D6;
                        case ConsoleKey.D6:
                            Console.Clear();
                            // запуск задания 
                            Point6();
                            break;

                        // 7. Запрос на левое соединение
                        case ConsoleKey.NumPad7:
                            goto case ConsoleKey.D7;
                        case ConsoleKey.D7:
                            Console.Clear();
                            // запуск задания 
                            Point7();
                            break;

                        // 8. Запрос на левое соединение
                        case ConsoleKey.NumPad8:
                            goto case ConsoleKey.D8;
                        case ConsoleKey.D8:
                            Console.Clear();
                            // запуск задания 
                            Point8();
                            break;

                        // 9. Запрос на левое соединение
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

            #region 1. Запрос с параметрами

            // 1. Запрос с параметрами
            void Point1()
            {
                /* 1	Запрос с параметрами	
                 * Выбирает из таблицы КВАРТИРЫ информацию о 3-комнатных квартирах, расположенных
                 * на улице «Садовая». Значения задавать параметрами запроса
                */

                ShowNavBarMessage("1. Запрос с параметрами");

                // вывод информации о запросе
                ShowInfoQuery("1. Запрос с параметрами",
                    new[] { "Выбирает из таблицы КВАРТИРЫ информацию о 3-комнатных квартирах, расположенных",
                            "на улице «Садовая». Значения задавать параметрами запроса" });

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    // открытие соединения
                    connection.Open();

                    // создание комманды
                    SqlCommand command = new SqlCommand(
                        @"select
                          	   *
                          from
                          	   ViewImmovables
                          where
                          	   Street = @street and AmountRooms = @countRooms;"
                        );

                    // добавление параметров
                    command.Parameters.Add("@countRooms", 3);
                    command.Parameters.Add("@street", "Садовая");

                    // установка соединения
                    command.Connection = connection;

                    // получение результата
                    SqlDataReader dataReader = command.ExecuteReader();

                    // вывод результата
                    new ShowModelViewImmovables(dataReader).ShowData();
                }
            }

            #endregion

            #region 2. Запрос с параметрами

            // 2. Запрос с параметрами
            void Point2()
            {
                /* 2	Запрос с параметрами	
                 * Выбирает из таблицы РИЭЛТОРЫ информацию о риэлторах, фамилия которых начинается 
                 * с буквы «И» и процент вознаграждения больше 10%. Значения задавать параметрами 
                 * запроса
                */

                ShowNavBarMessage("2. Запрос с параметрами");

                // вывод информации о запросе
                ShowInfoQuery("2. Запрос с параметрами",
                    new[] { "Выбирает из таблицы РИЭЛТОРЫ информацию о риэлторах, фамилия которых начинается",
                            "с буквы «И» и процент вознаграждения больше 10%. Значения задавать параметрами",
                            "запроса" });

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    // открытие соединения
                    connection.Open();

                    // создание команды
                    SqlCommand command = new SqlCommand(
                        @"select
                          	   *
                          from
                          	   ViewRealtors
                          where
                          	   RealtorLastName in (select Persons.LastName from Persons where Persons.LastName like (@lastName + N'%'))
                          		    and RemunPercent > @percent;"
                        );

                    // добавление параметров
                    command.Parameters.Add("@lastName", "И");
                    command.Parameters.Add("@percent", 10d);

                    // установка соединения
                    command.Connection = connection;

                    // получение результата
                    SqlDataReader dataReader = command.ExecuteReader();

                    // вывод результата
                    new ShowModelViewRealtors(dataReader).ShowData();
                }
            }

            #endregion

            #region 3. Запрос с параметрами

            // 3. Запрос с параметрами
            void Point3()
            {
                /* 3	Запрос с параметрами	
                 * Выбирает из таблицы КВАРТИРЫ информацию об 1-комнатных квартирах, цена на которые 
                 * находится в диапазоне от 900 000 руб. до 1000 000 руб. Значения задавать 
                 * параметрами запроса
                */


                ShowNavBarMessage("3. Запрос с параметрами");

                // вывод информации о запросе
                ShowInfoQuery("3. Запрос с параметрами",
                    new[] { "Выбирает из таблицы КВАРТИРЫ информацию об 1-комнатных квартирах, цена на которые",
                            "находится в диапазоне от 900 000 руб. до 1000 000 руб. Значения задавать",
                            "параметрами запроса" });


                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    // открытие соединения
                    connection.Open();

                    // создание команды
                    SqlCommand command = new SqlCommand(
                        @"select
                          	   *
                          from
                          	   ViewImmovables
                          where
                          	   AmountRooms = @countRooms and Price between @priceLo and @priceHi;"
                        );

                    // добавление параметров
                    command.Parameters.Add("@countRooms", 1);
                    command.Parameters.Add("@priceLo", 900000);
                    command.Parameters.Add("@priceHi", 1000000);

                    // установка соединения
                    command.Connection = connection;

                    // получение результата
                    SqlDataReader dataReader = command.ExecuteReader();

                    // вывод результата
                    new ShowModelViewImmovables(dataReader).ShowData();
                }
            }

            #endregion

            #region 4. Запрос с параметрами

            // 4. Запрос с параметрами
            void Point4()
            {
                /* 4	Запрос с параметрами	
                 * Выбирает из таблицы КВАРТИРЫ информацию о квартирах с заданным числом комнат. 
                 * Значения задавать параметрами запроса
                */


                ShowNavBarMessage("4. Запрос с параметрами");

                // вывод информации о запросе
                ShowInfoQuery("4. Запрос с параметрами",
                    new[] { "Выбирает из таблицы КВАРТИРЫ информацию о квартирах с заданным числом комнат.",
                            "Значения задавать параметрами запроса" });

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    // открытие соединения
                    connection.Open();

                    // создание команды
                    SqlCommand command = new SqlCommand(
                        @"select
                          	   *
                          from	
                           	   ViewImmovables 
                          where
                          	   AmountRooms = @countRooms;"
                        );

                    // добавлени параметров
                    command.Parameters.Add("@countRooms", 2);

                    // установка соеднинения
                    command.Connection = connection;

                    // получение результата
                    SqlDataReader dataReader = command.ExecuteReader();

                    // вывод результата
                    new ShowModelViewImmovables(dataReader).ShowData();
                }
            }

            #endregion

            #region 5. Запрос с параметрами

            // 5. Запрос с параметрами
            void Point5()
            {
                /* 5	Запрос с параметрами	
                 * Выбирает из таблицы КВАРТИРЫ информацию обо всех 2-комнатных квартирах, площадь
                 * которых есть значение из некоторого диапазона. Значения задавать параметрами запроса
                */


                ShowNavBarMessage("5. Запрос с параметрами");

                // вывод информации о запросе
                ShowInfoQuery("5. Запрос с параметрами",
                    new[] { "Выбирает из таблицы КВАРТИРЫ информацию обо всех 2-комнатных квартирах, площадь",
                            "которых есть значение из некоторого диапазона. Значения задавать параметрами запроса" });

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    // открытие соединения
                    connection.Open();

                    // создание команды
                    SqlCommand command = new SqlCommand(
                        @"select
                               *
                          from
                               ViewImmovables 
                          where	
                               AmountRooms = @countRooms and Area between @areaLo and @areaHi;"
                        );

                    // добавление параметров
                    command.Parameters.Add("@countRooms", 2);
                    command.Parameters.Add("@areaLo", 40d);
                    command.Parameters.Add("@areaHi", 55d);

                    // установка соединения
                    command.Connection = connection;

                    // получение результата
                    SqlDataReader dataReader = command.ExecuteReader();

                    // вывод результата
                    new ShowModelViewImmovables(dataReader).ShowData();
                }
            }

            #endregion

            #region 6. Запрос с вычисляемыми полями

            // 6. Запрос с вычисляемыми полями
            void Point6()
            {
                /* 6	Запрос с вычисляемыми полями	
                 * Вычисляет для каждой оформленной сделки размер комиссионного вознаграждения риэлтора.
                 * Включает поля Фамилия риэлтора, Имя риэлтора, Отчество риэлтора, Дата сделки, Цена 
                 * квартиры, Комиссионные. Сортировка по полю Дата сделки
                */


                ShowNavBarMessage("6. Запрос с вычисляемыми полями");

                // вывод информации о запросе
                ShowInfoQuery("6. Запрос с вычисляемыми полями",
                    new[] { "Вычисляет для каждой оформленной сделки размер комиссионного вознаграждения риэлтора.",
                            "Включает поля Фамилия риэлтора, Имя риэлтора, Отчество риэлтора, Дата сделки, Цена",
                            "квартиры, Комиссионные. Сортировка по полю Дата сделки" });

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    // открытие соединения
                    connection.Open();

                    // создание команды
                    SqlCommand command = new SqlCommand(
                        @"select
                               Id
                               , RealtorLastName
                               , RealtorFirstName
                               , RealtorPatronymic
                               , DateTrans
                               , Price
                               , RemunPercent
                               , Price * (RemunPercent / 100) as Commission
                          from 
                               ViewTransactions 
                          order by
                               ViewTransactions.DateTrans;"
                        );

                    // установка соединения
                    command.Connection = connection;

                    // получение результата
                    SqlDataReader dataReader = command.ExecuteReader();

                    // вывод результата
                    new ShowModelViewTransactionQuery6(dataReader).ShowData();
                }
            }

            #endregion

            #region 7. Запрос на левое соединение

            // 7. Запрос на левое соединение
            void Point7()
            {
                /* 7	Запрос на левое соединение	
                 * Выбрать всех риэлторов, количество клиентов, оформивших с ним сделки и сумму сделок 
                 * риэлтора. Упорядочить выборку по убыванию суммы сделок.
                */

                ShowNavBarMessage("7. Запрос на левое соединение");

                // вывод информации о запросе
                ShowInfoQuery("7. Запрос на левое соединение",
                    new[] { "Выбрать всех риэлторов, количество клиентов, оформивших с ним сделки и сумму сделок",
                            "риэлтора. Упорядочить выборку по убыванию суммы сделок."});

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    // открытие соединения
                    connection.Open();

                    // создание команды
                    SqlCommand command = new SqlCommand(
                        @"select
                          	   ViewRealtors.Id
                          	   , ViewRealtors.RealtorLastName
                          	   , ViewRealtors.RealtorFirstName
                          	   , ViewRealtors.RealtorPatronymic
                          	   , COUNT (Transactions.Id) as CountTransactions			
                          	   , ISNULL(SUM (Immovables.Price), 0) as SumTransactions				
                          from
                          	   ViewRealtors left join (Transactions inner join Immovables on Transactions.IdImmovables = Immovables.Id) 
                          		    on Transactions.IdRealtors = ViewRealtors.Id 
                          group by
                          	   ViewRealtors.Id, ViewRealtors.RealtorLastName, ViewRealtors.RealtorFirstName, ViewRealtors.RealtorPatronymic
                          order by
                          	   SumTransactions desc;"
                        );

                    // установка соединения
                    command.Connection = connection;

                    // получение результата
                    SqlDataReader dataReader = command.ExecuteReader();

                    // вывод результата
                    new ShowModelViewRealtorsQuery7(dataReader).ShowData();
                }
            }

            #endregion

            #region 8. Запрос на левое соединение

            // 8. Запрос на левое соединение
            void Point8()
            {
                /* 8	Запрос на левое соединение	
                 * Для всех улиц вывести сумму сделок, упорядочить выборку по убыванию суммы сделки
                */

                ShowNavBarMessage("8. Запрос на левое соединение");

                // вывод информации о запросе
                ShowInfoQuery("8. Запрос на левое соединение",
                    new[] { "Для всех улиц вывести сумму сделок, упорядочить выборку по убыванию суммы сделки",
                            "риэлтора. Упорядочить выборку по убыванию суммы сделок." });

                using (SqlConnection connection = new SqlConnection(_connectionString)) 
                {
                    // открытие соединения
                    connection.Open();

                    // создание команды
                    SqlCommand command = new SqlCommand(
                        @"select
                          	   Streets.Id
                          	   , Streets.Street
                          	   , COUNT(Immovables.Id) as CountTransactions					-- количество сделок
                          	   , ISNULL(SUM(Immovables.Price), 0) as SumTransactions		-- сумма сделок
                          from
                               Streets left join (Immovables inner join Transactions on Immovables.Id = Transactions.IdImmovables)
                               	   on Immovables.IdStreets = Streets.Id
                          group by
                          	   Streets.Street, Streets.Id
                          order by
                          	   SumTransactions desc;"
                        );

                    // установка соединения
                    command.Connection = connection;

                    // получение результата
                    SqlDataReader dataReader = command.ExecuteReader();

                    // вывод результата
                    new ShowModelStreetsQuery8And9(dataReader).ShowData();
                }
            }

            #endregion

            #region 9. Запрос на левое соединение

            // 9. Запрос на левое соединение
            void Point9()
            {
                /* 9	Запрос на левое соединение	
                 * Для всех улиц вывести сумму сделок за заданный период, упорядочить выборку по убыванию 
                 * суммы сделки. Диапазон задавать параметрами запроса
                */

                ShowNavBarMessage("9. Запрос на левое соединение");

                // вывод информации о запросе
                ShowInfoQuery("9. Запрос на левое соединение",
                    new[] { "Для всех улиц вывести сумму сделок за заданный период, упорядочить выборку по убыванию",
                            "суммы сделки. Диапазон задавать параметрами запроса"});

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    // открытие соединения
                    connection.Open();

                    // создание команды
                    SqlCommand command = new SqlCommand(
                        @"select
                          	   Streets.Id
                          	   , Streets.Street
                          	   , COUNT(results.IdStreets) as CountTransactions		-- количество сделок
                          	   , ISNULL(SUM(results.Price), 0) as SumTransactions				-- сумма сделок
                          from
                          	   Streets left join (select Immovables.Price, Immovables.IdStreets, Transactions.Id, Transactions.DateTrans 
                          		   from Immovables inner join Transactions on Immovables.Id = Transactions.IdImmovables
                          		   where Transactions.DateTrans between @minDate and @maxDate) results
                          		   on results.IdStreets = Streets.Id
                          group by
                          	   Streets.Id, Streets.Street
                          order by
                          	   SumTransactions desc;"
                        );

                    // добавление параметров
                    command.Parameters.Add("@minDate", "2021/01/01");
                    command.Parameters.Add("@maxDate", "2021/05/01");

                    // установка соединения
                    command.Connection = connection;

                    // получение результата
                    SqlDataReader dataReader = command.ExecuteReader();

                    // вывод результата
                    new ShowModelStreetsQuery8And9(dataReader).ShowData();
                }
            }

            #endregion

        }

        #region Общие методы

        // вывод информации о запросе
        public void ShowInfoQuery(string label, string[] content)
        {
            // вывод шапки
            //                                                                  100
            WriteColorXY("     ╔══════════════════════════════════════════════════════════════════════════════════════════════════════╗\n", textColor: ConsoleColor.DarkMagenta);
            WriteColorXY("     ║                                                                                                      ║", textColor: ConsoleColor.DarkMagenta);
            WriteColorXY($"{label, -100}", 7, textColor: ConsoleColor.Green);
            Console.WriteLine();

            WriteColorXY("     ╠══════════════════════════════════════════════════════════════════════════════════════════════════════╣\n", textColor: ConsoleColor.DarkMagenta);

            // вывод строк
            Array.ForEach(content, line =>
            {
                WriteColorXY("     ║                                                                                                      ║", textColor: ConsoleColor.DarkMagenta);
                WriteColorXY($"{line, -100}", 7, textColor: ConsoleColor.Cyan);
                Console.WriteLine();
            });

            // вывод подвала
            WriteColorXY("     ╚══════════════════════════════════════════════════════════════════════════════════════════════════════╝\n\n", textColor: ConsoleColor.DarkMagenta);
        }

        #endregion

        #endregion

    }
}
