using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using static HomeWork.Application.App.Utils;       // для использования утилит

/*
 * Разработайте, пожалуйста, консольное приложение C# для решения следующих задач (в 
 * объектном стиле – с созданием класса, объекта этого класса):
 * •	Задача 1. Для класса, представляющего товар (наименование, цена, количество,
 *      год выпуска) разработать расширяющий метод, возвращающий процент скидки в 
 *      зависимости от возраста товара – до 3х лет скидка не представляется, от 3х до 
 *      10 лет скидка 3%, свыше 10 лет – скидка 7%. Продемонстрировать работу метода 
 *      на коллекции из 12 товаров.
 * •	Задача 2. С использованием LINQ (создавайте 2 варианта запросов – в синтаксисе
 *      LINQ и в синтаксисе расширяющих методов) выполнить обработки для одномерного 
 *      массива из n вещественных элементов:
 *      o	Вычисление количества элементов массива, со значениями в диапазоне от A до B
 *      o	Вычисление количества элементов массива, равных 0
 *      o	Вычисление суммы элементов массива, расположенных после первого максимального
 *          элемента
 *      o	Вычисление суммы элементов массива, расположенных перед последним минимальным
 *          по модулю элементом
 * •	Задача 3. Для коллекции товаров из задачи 1 выполнить следующие LINQ-запросы 
 *      (создавайте 2 варианта запросов – в синтаксисе LINQ и в синтаксисе расширяющих 
 *      методов):
 *      o	товары с заданным диапазоном цен
 *      o	сумма товаров с заданным годом выпуска
 *      o	сумма товаров с заданным наименованием (суммируем произведение цены на 
 *          количество, наименование товара может быть задано частично, но без маски 
 *          типа %, _)
 *      o	наименование и год выпуска товаров с максимальным количеством
 *      o	все товары, для которых произведение цены на количество находится в заданном
 *          диапазоне
*/

namespace HomeWork.Application
{

    public partial class App
    {

        #region Меню заданий 

        // меню заданий
        public void Menu()
        {
            // пункты меню 
            string[] points =
            {
                "Задание 1. Скидка на товары",
                "Задание 2. Массив",
                "Задание 3. Товары"
            };

            // вывод меню
            while (true)
            {
                // отчистка консоли
                Console.Clear();

                // цвет 
                Console.ForegroundColor = ConsoleColor.Cyan;

                // координаты курсора
                int x = 5, y = Console.CursorTop + 3;

                // заголовок
                Console.SetCursorPosition(x + 3, y); WriteColor($"{"    Главное меню"}", ConsoleColor.Blue);

                y += 2;

                // вывод пунктов меню
                Array.ForEach(points, item => WriteColorXY(item, x, y++));

                // вывод пункта выхода из приложения
                Console.SetCursorPosition(x, ++y); Console.WriteLine("0. Выход");

                y += 4;

                // ввод номера задания
                Console.SetCursorPosition(x, y); Console.Write("Введите номер задания: ");
                ConsoleKey num = Console.ReadKey().Key;

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

                    // Задание 1. Скидка на товары
                    case ConsoleKey.NumPad1:
                        goto case ConsoleKey.D1;
                    case ConsoleKey.D1:
                        // запуск задания 
                        Task1();
                        break;

                    // Задание 2. Массив
                    case ConsoleKey.NumPad2:
                        goto case ConsoleKey.D2;
                    case ConsoleKey.D2:
                        // запуск задания 
                        Task2();
                        break;

                    // Задание 3. Товары
                    case ConsoleKey.NumPad3:
                        goto case ConsoleKey.D3;
                    case ConsoleKey.D3:
                        // запуск задания 
                        Task3();
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
            }
        } // Menu

        #endregion

    }
}
