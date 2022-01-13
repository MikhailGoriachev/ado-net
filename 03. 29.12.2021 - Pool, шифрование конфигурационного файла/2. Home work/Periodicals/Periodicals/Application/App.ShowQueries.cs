using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using static Periodicals.Application.App.Utils;       // для использования утилит

namespace Periodicals.Application
{
    public partial class App
    {
        #region 2. Выполнение запросов по заданию

        /*
        * 1	Хранимая процедура
        *   Выбирает из таблицы ИЗДАНИЯ информацию о доступных для подписки 
        *   изданиях заданного типа, стоимость 1 экземпляра для которых меньше 
        *   заданной.
        *   Требуется модель для вывода данных – данные выборки помещать в коллекцию
        * 2	Хранимая процедура	
        *   Выбирает из таблиц информацию о подписчиках, проживающих на заданной
        *   параметром улице и номере дома, которые оформили подписку на издание 
        *   с заданным параметром наименованием
        *   Требуется модель для вывода данных – данные выборки помещать в коллекцию
        * 3	Хранимая процедура	
        *   Выбирает из таблицы ИЗДАНИЯ информацию об изданиях, для которых значение
        *   в поле Цена 1 экземпляра находится в заданном диапазоне значений
        *   Требуется модель для вывода данных – данные выборки помещать в коллекцию
        * 4	Хранимая процедура	
        *   Выбирает из таблиц информацию о подписчиках, подписавшихся на заданный 
        *   параметром тип издания
        *   Требуется модель для вывода данных – данные выборки помещать в коллекцию
        * 5	Хранимая процедура	
        *   Выбирает из таблиц ИЗДАНИЯ и ДОСТАВКА информацию обо всех оформленных 
        *   подписках, для которых срок подписки есть значение из некоторого диапазона
        * 6	Хранимая процедура	
        *   Вычисляет для каждой оформленной подписки ее стоимость с доставкой и без 
        *   НДС. Включает поля Индекс издания, Наименование издания, Цена 1 экземпляра,
        *   Дата начала подписки, Срок подписки, Стоимость подписки без НДС. Сортировка 
        *   по полю Индекс издания
        *  	 	 
        * 7	Итоговый запрос     Хранимая процедура
        * 	Выполняет группировку по полю Вид издания. Для каждого вида вычисляет 
        * 	максимальную и минимальную цену 1 экземпляра
        * 8	Итоговый запрос с левым соединением         Хранимая процедура	
        *   Выполняет группировку по полю Улица. Для всех улиц вычисляет количество 
        *   подписчиков, проживающих на данной улице (итоги по полю Код получателя)
        * 9	Итоговый запрос с левым соединением     Хранимая процедура	
        *   Для всех изданий выводит количество оформленных подписок
        */

        // 2. Выполнение запросов по заданию
        public void ShowQueries()
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
                "7. Хранимая процедура      Итоговый запрос",
                "8. Хранимая процедура      Итоговый запрос с левым соединением",
                "9. Хранимая процедура      Итоговый запрос с левым соединением"
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
                Console.SetCursorPosition(x + 3, y); WriteColor($"{"    2. Выполнение запросов по заданию"}", ConsoleColor.Blue);

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

                        // 7. Хранимая процедура      Итоговый запрос
                        case ConsoleKey.NumPad7:
                            goto case ConsoleKey.D7;
                        case ConsoleKey.D7:
                            Console.Clear();
                            // запуск задания 
                            Point7();
                            break;

                        // 8. Хранимая процедура      Итоговый запрос с левым соединением
                        case ConsoleKey.NumPad8:
                            goto case ConsoleKey.D8;
                        case ConsoleKey.D8:
                            Console.Clear();
                            // запуск задания 
                            Point8();
                            break;

                        // 9. Хранимая процедура      Итоговый запрос с левым соединением
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
                ShowNavBarMessage("1. Хранимая процедура");

                // тип издания 
                string typeEdition = Utils.GetEditionType();

                // вывод информации о запросе
                ShowInfoQuery("1. Хранимая процедура", new[] { 
                        "Выбирает из таблицы ИЗДАНИЯ информацию о доступных для ",
                        "подписки изданиях заданного типа, стоимость 1 экземпляра ",
                        "для которых меньше заданной.",
                        "",
                        $"Выбранный тип издания: {typeEdition}"
                    });

                // вывод результата
                _controller.ShowProc1(typeEdition);
            }

            #endregion

            #region 2. Хранимая процедура

            // 2. Хранимая процедура
            void Point2()
            {
                ShowNavBarMessage("2. Хранимая процедура");

                // вывод информации о запросе
                ShowInfoQuery("1. Хранимая процедура", new[] {
                        "Выбирает из таблиц информацию о подписчиках, проживающих",
                        "на заданной параметром улице и номере дома, которые",
                        "оформили подписку на издание с заданным параметром",
                        "наименованием",
                        "",
                        "Выбранная улица и номер дома: Петровского 256",
                        "Выбранный наименование издания: Вечерняя Москва"
                    });

                // вывод результата
                _controller.ShowProc2("Петровского", "256", "Вечерняя Москва");
            }

            #endregion

            #region 3. Хранимая процедура

            // 3. Хранимая процедура
            void Point3()
            {
                ShowNavBarMessage("3. Хранимая процедура");

                // диапазон значений цены 1 экземпляра
                int loPrice = Utils.rand.Next(250, 500), hiPrice = Utils.rand.Next(1500, 2000);

                // вывод информации о запросе
                ShowInfoQuery("3. Хранимая процедура", new[] {
                        "Выбирает из таблицы ИЗДАНИЯ информацию об изданиях, для",
                        "которых значение в поле Цена 1 экземпляра находится в ",
                        "заданном диапазоне значений",
                        "",
                        $"Диапазон значений цены 1 экземпляра: {loPrice} - {hiPrice}",
                        "Выбранный наименование издания: Вечерняя Москва"
                    });

                // вывод результата
                _controller.ShowProc3(loPrice, hiPrice);
            }

            #endregion

            #region 4. Хранимая процедура

            // 4. Хранимая процедура
            void Point4()
            {
                ShowNavBarMessage("4. Хранимая процедура");

                // тип издания 
                string typeEdition = Utils.GetEditionType();

                // вывод информации о запросе
                ShowInfoQuery("4. Хранимая процедура", new[] {
                        "Выбирает из таблиц информацию о подписчиках, подписавшихся",
                        "на заданный параметром тип издания",
                        "",
                        $"Выбранный тип издания: {typeEdition}"
                    });

                // вывод результата
                _controller.ShowProc4(typeEdition);
            }

            #endregion

            #region 5. Хранимая процедура

            // 5. Хранимая процедура
            void Point5()
            {
                ShowNavBarMessage("5. Хранимая процедура");

                // диапазон срока подписки
                int loMonths = Utils.rand.Next(1, 3), hiMonth = Utils.rand.Next(5, 10);

                // вывод информации о запросе
                ShowInfoQuery("5. Хранимая процедура", new[] {
                        "Выбирает из таблиц ИЗДАНИЯ и ПОДПИСКА информацию обо всех",
                        "оформленных подписках, для которых срок подписки есть",
                        "значение из некоторого диапазона.",
                        "",
                        $"Диапазон срока подписки: {loMonths} - {hiMonth}"
                    });

                // вывод результата
                _controller.ShowProc5(loMonths, hiMonth);
            }

            #endregion

            #region 6. Хранимая процедура

            // 6. Хранимая процедура
            void Point6()
            {
                ShowNavBarMessage("6. Хранимая процедура");

                // вывод информации о запросе
                ShowInfoQuery("6. Хранимая процедура", new[] {
                        "Вычисляет для каждой оформленной подписки ее стоимость с",
                        "доставкой и без НДС. Включает поля Индекс издания,",
                        "Наименование издания, Цена 1 экземпляра, Дата начала",
                        "подписки, Срок подписки, Стоимость подписки без НДС.",
                        "Сортировка по полю Индекс издания"
                    });

                // вывод результата
                _controller.ShowProc6();
            }

            #endregion

            #region 7. Хранимая процедура      Итоговый запрос

            // 7. Хранимая процедура      Итоговый запрос
            void Point7()
            {
                ShowNavBarMessage("7. Хранимая процедура      Итоговый запрос");

                // вывод информации о запросе
                ShowInfoQuery("7. Хранимая процедура      Итоговый запрос", new[] {
                        "Выполняет группировку по полю Вид издания. Для каждого",
                        "вида вычисляет максимальную и минимальную цену 1 экземпляра"
                    });

                // вывод результата
                _controller.ShowProc7();
            }

            #endregion

            #region 8. Хранимая процедура      Итоговый запрос с левым соединением

            // 8. Хранимая процедура      Итоговый запрос с левым соединением
            void Point8()
            {
                ShowNavBarMessage("8. Хранимая процедура      Итоговый запрос с левым соединением");

                // вывод информации о запросе
                ShowInfoQuery("8. Хранимая процедура      Итоговый запрос с левым соединением", new[] {
                        "Выполняет группировку по полю Улица. Для всех улиц вычисляет ",
                        "количество подписчиков, проживающих на данной улице (итоги ",
                        "по полю Код получателя)"
                    });

                // вывод результата
                _controller.ShowProc8();
            }

            #endregion

            #region 9. Хранимая процедура      Итоговый запрос с левым соединением

            // 9. Хранимая процедура      Итоговый запрос с левым соединением
            void Point9()
            {
                ShowNavBarMessage("9. Хранимая процедура      Итоговый запрос с левым соединением");

                // вывод информации о запросе
                ShowInfoQuery("8. Хранимая процедура      Итоговый запрос с левым соединением", new[] {
                        "Для всех изданий выводит количество оформленных подписок",
                    });

                // вывод результата
                _controller.ShowProc9();
            }

            #endregion
        }

        #endregion

    }
}
