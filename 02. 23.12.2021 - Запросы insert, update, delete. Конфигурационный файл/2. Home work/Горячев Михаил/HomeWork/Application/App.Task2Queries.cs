using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;        // для работы с Sql
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HomeWork.Models.Task2;          // модели
using System.Data;

using static HomeWork.Application.App.Utils;       // для использования утилит

namespace HomeWork.Application
{
    public partial class App
    {
        #region 2. Обработки по заданию 2

        /*
        * 2. Обработки по заданию 2
        */

        // 2. Обработки по заданию 2
        public void Task2Queries()
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
                 * Выбирает информацию обо всех фактах проката автомобиля с заданным госномером
                */

                ShowNavBarMessage("1. Хранимая процедура");

                // получение номера
                string number = Utils.GetNumber();

                // вывод информации о запросе
                ShowInfoQuery("1. Хранимая процедура",
                    new[] { "Выбирает информацию обо всех фактах проката автомобиля с заданным госномером",
                            "",
                            $"Заданный номер {number}"});

                using (SqlConnection connection = new SqlConnection(_connectionStringTask2))
                {
                    // открытие соединения
                    connection.Open();

                    // создание комманды
                    SqlCommand command = new SqlCommand("Proc1");

                    // добавление параметров
                    command.Parameters.AddWithValue("@plate", number);

                    // установка соединения
                    command.Connection = connection;

                    // установка типа запроса
                    command.CommandType = CommandType.StoredProcedure;

                    // получение результата
                    SqlDataReader dataReader = command.ExecuteReader();

                    // вывод результата
                    new ShowModelRentals(dataReader).ShowData();
                }
            }

            #endregion

            #region 2. Хранимая процедура

            // 2. Хранимая процедура
            void Point2()
            {
                /* 2	Хранимая процедура	
                 * Выбирает информацию обо всех фактах проката автомобиля с заданной моделью/брендом
                */

                ShowNavBarMessage("2. Хранимая процедура");

                // получение бренда-модели автомобиля
                string brand = Utils.GetBrand();

                // вывод информации о запросе
                ShowInfoQuery("2. Хранимая процедура",
                    new[] { "Выбирает информацию обо всех фактах проката автомобиля с заданной моделью/брендом",
                            "",
                            $"Выбранный бренд-модель: {brand}"});

                using (SqlConnection connection = new SqlConnection(_connectionStringTask2))
                {
                    // открытие соединения
                    connection.Open();

                    // создание команды
                    SqlCommand command = new SqlCommand("Proc2");

                    // добавление параметров
                    command.Parameters.AddWithValue("@brand", brand);

                    // установка соединения
                    command.Connection = connection;

                    // установка типа запроса
                    command.CommandType = CommandType.StoredProcedure;

                    // получение результата
                    SqlDataReader dataReader = command.ExecuteReader();

                    // вывод результата
                    new ShowModelRentals(dataReader).ShowData();
                }
            }

            #endregion

            #region 3. Хранимая процедура

            // 3. Хранимая процедура
            void Point3()
            {
                /* 3	Хранимая процедура	
                 * Выбирает информацию об автомобиле с заданным госномером
                */


                ShowNavBarMessage("3. Хранимая процедура");

                // номер
                string number = Utils.GetNumber();

                // вывод информации о запросе
                ShowInfoQuery("3. Хранимая процедура",
                    new[] { "Выбирает информацию об автомобиле с заданным госномером",
                            "",
                            $"Выбранный госномер: {number}"});


                using (SqlConnection connection = new SqlConnection(_connectionStringTask2))
                {
                    // открытие соединения
                    connection.Open();

                    // создание команды
                    SqlCommand command = new SqlCommand("Proc3");

                    // добавление параметров
                    command.Parameters.AddWithValue("@plate", number);

                    // установка соединения
                    command.Connection = connection;

                    // установка типа запроса
                    command.CommandType = CommandType.StoredProcedure;

                    // получение результата
                    SqlDataReader dataReader = command.ExecuteReader();

                    // вывод результата
                    new ShowModelCars(dataReader).ShowData();
                }
            }

            #endregion

            #region 4. Хранимая процедура

            // 4. Хранимая процедура
            void Point4()
            {
                /* 4	Хранимая процедура	
                 * Выбирает информацию о клиентах по серии и номеру паспорта
                */


                ShowNavBarMessage("4. Хранимая процедура");

                // пасспорт
                string passport = Utils.GetPassport();

                // вывод информации о запросе
                ShowInfoQuery("4. Хранимая процедура",
                    new[] { "Выбирает информацию о клиентах по серии и номеру паспорта",
                            "",
                            $"Выбранный пасспорт: {passport}"});

                using (SqlConnection connection = new SqlConnection(_connectionStringTask2))
                {
                    // открытие соединения
                    connection.Open();

                    // создание команды
                    SqlCommand command = new SqlCommand("Proc4");

                    // добавлени параметров
                    command.Parameters.AddWithValue("@passport", passport);

                    // установка соеднинения
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

            #region 5. Хранимая процедура

            // 5. Хранимая процедура
            void Point5()
            {
                /* 5	Хранимая процедура	
                 * Выбирает информацию обо всех зафиксированных фактах проката 
                 * автомобилей в некоторый заданный интервал времени.
                */


                ShowNavBarMessage("5. Хранимая процедура");

                // интервал времени
                string dateLo = "2021/11/03", dateHi = "2021/11/05";

                // вывод информации о запросе
                ShowInfoQuery("5. Хранимая процедура",
                    new[] { "Выбирает информацию обо всех зафиксированных фактах проката",
                            "автомобилей в некоторый заданный интервал времени." ,
                            "",
                            $"Заданный интервал времени: {dateLo} - {dateHi}"});

                using (SqlConnection connection = new SqlConnection(_connectionStringTask2))
                {
                    // открытие соединения
                    connection.Open();

                    // создание команды
                    SqlCommand command = new SqlCommand("Proc5");

                    // добавление параметров
                    command.Parameters.AddWithValue("@dateLo", dateLo);
                    command.Parameters.AddWithValue("@dateHi", dateHi);

                    // установка соединения
                    command.Connection = connection;

                    // установка типа запроса
                    command.CommandType = CommandType.StoredProcedure;

                    // получение результата
                    SqlDataReader dataReader = command.ExecuteReader();

                    // вывод результата
                    new ShowModelRentals(dataReader).ShowData();
                }
            }

            #endregion

            #region 6. Хранимая процедура

            // 6. Хранимая процедура
            void Point6()
            {
                /* 6	Хранимая процедура	
                 * Вычисляет для каждого факта проката стоимость проката.
                 * Включает поля Дата проката, Госномер автомобиля, Модель 
                 * автомобиля, Стоимость проката. Сортировка по полю Дата проката
                */


                ShowNavBarMessage("6. Хранимая процедура");

                // вывод информации о запросе
                ShowInfoQuery("6. Хранимая процедура",
                    new[] { "Вычисляет для каждого факта проката стоимость проката.",
                            "Включает поля Дата проката, Госномер автомобиля, Модель",
                            "автомобиля, Стоимость проката. Сортировка по полю Дата проката" });

                using (SqlConnection connection = new SqlConnection(_connectionStringTask2))
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
                    new ShowModelRentalsProc6(dataReader).ShowData();
                }
            }

            #endregion

            #region 7. Хранимая процедура

            // 7. Хранимая процедура
            void Point7()
            {
                /* 7	Хранимая процедура	
                 * Для всех клиентов прокатной фирмы вычисляет количество фактов 
                 * проката, суммарное количество дней проката, упорядочивание по 
                 * убыванию суммарного количества дней проката
                */

                ShowNavBarMessage("7. Хранимая процедура");

                // вывод информации о запросе
                ShowInfoQuery("7. Хранимая процедура",
                    new[] { "Для всех клиентов прокатной фирмы вычисляет количество фактов ",
                            "проката, суммарное количество дней проката, упорядочивание по ",
                            "убыванию суммарного количества дней проката"});

                using (SqlConnection connection = new SqlConnection(_connectionStringTask2))
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
                    new ShowModelProc7(dataReader).ShowData();
                }
            }

            #endregion

            #region 8. Хранимая процедура

            // 8. Хранимая процедура
            void Point8()
            {
                /* 8	Хранимая процедура	
                 * Выбирает информацию о фактах проката автомобилей по госномеру: количество 
                 * фактов проката, сумма за прокаты, суммарная длительность прокатов
                */

                ShowNavBarMessage("8. Хранимая процедура");

                // номер 
                string number = Utils.GetNumber();

                // вывод информации о запросе
                ShowInfoQuery("8. Хранимая процедура",
                    new[] { "Выбирает информацию о фактах проката автомобилей по госномеру: количество ",
                            "фактов проката, сумма за прокаты, суммарная длительность прокатов",
                            "",
                            $"Выбранный госномер: {number}"
                    });

                using (SqlConnection connection = new SqlConnection(_connectionStringTask2)) 
                {
                    // открытие соединения
                    connection.Open();

                    // создание команды
                    SqlCommand command = new SqlCommand("Proc8");

                    // добавление параметров
                    command.Parameters.AddWithValue("@plate", number);

                    // установка соединения
                    command.Connection = connection;

                    // установка типа запроса
                    command.CommandType = CommandType.StoredProcedure;

                    // получение результата
                    SqlDataReader dataReader = command.ExecuteReader();

                    // вывод результата
                    new ShowModelProc8(dataReader).ShowData();
                }
            }

            #endregion

        }

        #region Общие методы

        #endregion

        #endregion

    }
}
