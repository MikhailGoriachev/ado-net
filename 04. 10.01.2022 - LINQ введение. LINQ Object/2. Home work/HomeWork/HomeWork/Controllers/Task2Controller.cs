using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static HomeWork.Application.App.Utils;    // утилиты

/*
 * •	Задача 2. С использованием LINQ (создавайте 2 варианта запросов – в синтаксисе
 *      LINQ и в синтаксисе расширяющих методов) выполнить обработки для одномерного 
 *      массива из n вещественных элементов:
 *      o	Вычисление количества элементов массива, со значениями в диапазоне от A до B
 *      o	Вычисление количества элементов массива, равных 0
 *      o	Вычисление суммы элементов массива, расположенных после первого максимального
 *          элемента
 *      o	Вычисление суммы элементов массива, расположенных перед последним минимальным
 *          по модулю элементом
*/


namespace HomeWork.Controllers
{
    // Класс Контроллер обработки по заданию 2
    public class Task2Controller
    {
        // массив вещественных чисел
        private double[] _arrayDouble;

        public double[] ArrayDouble
        {
            get => _arrayDouble; 
            set => _arrayDouble = value; 
        }

        #region Конструкторы 

        // конструктор по умолчанию 
        public Task2Controller()
        {
            // создание массива
            _arrayDouble = new double[10];

            // заполнение массива
            for (int i = 0; i < _arrayDouble.Length; i++)
                _arrayDouble[i] = GetDouble(-10, 10);
        }

        #endregion


        #region Методы


        // вычисление количества элементов массива, со значениями в диапазоне от A до B         (LINQ)
        public int CountRangeLinq(double a, double b) =>
            (from item in _arrayDouble
             where item >= a && item <= b
             select item)
            .Count();

        // вычисление количества элементов массива, со значениями в диапазоне от A до B         (Extended Method)
        public int CountRangeExtended(double a, double b) =>
            _arrayDouble
                .Where(i => i >= a && i <= b)
                .Count();


        // вычисление количества элементов массива, равных 0                                    (LINQ)
        public int CountEqualsNullLinq() =>
            (from item in _arrayDouble
             where item.Equals(0d)
             select item)
            .Count();


        // вычисление количества элементов массива, равных 0                                    (Extended Method)
        public int CountEqualsNullExtended() =>
            _arrayDouble
                .Where(i => i.Equals(0d))
                .Count();


        // вычисление суммы элементов массива, расположенных после первого максимального        (Extended Method)
        // элемента
        public double SumAfterFirstMaxExtended()
        {
            double max = _arrayDouble.Max();

            return _arrayDouble
                    .SkipWhile(i => !i.Equals(max))
                    .Skip(1)
                    .Sum();
        }


        // получение индекса последнего минимального элемента
        public int GetFirstIndexMaxElem() => Array.IndexOf(_arrayDouble, _arrayDouble.Max());


        // вычисление суммы элементов массива, расположенных перед последним минимальным
        // по модулю элементом
        public double SumBeforeLastMinExtended()
        {
            // индекс минимального по модулю элемента 
            int index = GetLastIndexMinElem();

            return _arrayDouble
                        .Take(index)
                        .Sum();
        }



        // получение индекса последнего минимального элемента
        public int GetLastIndexMinElem()
        {
            // массив с абсолютными значениями
            var array = _arrayDouble.Select(item => Math.Abs(item)).ToArray();

            // индекс минимального по модулю элемента 
            return Array.LastIndexOf(array, array.Min(i => i));
        }



        #region Вывод массива

        // вывод массива
        static public void ShowTable<T>(double[] array, Action<double[], Predicate<(T item, int i)>> showElements, Predicate<(T item, int i)> predicate, string name = "Коллекция", string info = "Исходные данные")
        {
            // вывод шапки таблицы
            ShowHead(array.Length, name, info);

            // вывод рамки таблицы 
            ShowElemFrame(array.Length);

            // вывод элементов
            showElements(array, predicate);
        }

        // вывод шапки таблицы 
        static public void ShowHead(int size, string name = "Коллекция", string info = "Исходные данные")
        {
            //                  10                     30                                   33
            WriteColorXY("     ╔════════════╦═════════════════════════════════╦═════════════════════════════════╗\n", textColor: ConsoleColor.Magenta);
            WriteColorXY("     ║            ║                                 ║                                 ║", textColor: ConsoleColor.Magenta);
            WriteColorXY("Размер: ", 7, textColor: ConsoleColor.DarkYellow);
            WriteColorXY($"{size,2}", textColor: ConsoleColor.Green);
            WriteColorXY("Название: ", 20, textColor: ConsoleColor.DarkYellow);
            WriteColorXY($"{name,-20}", textColor: ConsoleColor.Green);
            WriteColorXY("Инфо: ", 54, textColor: ConsoleColor.DarkYellow);
            WriteColorXY($"{info,-25}", textColor: ConsoleColor.Green);
            Console.WriteLine();
            WriteColorXY("     ╚════════════╩═════════════════════════════════╩═════════════════════════════════╝\n", textColor: ConsoleColor.Magenta);
        }

        // вывод рамки для вывода значений элементов с индексированием 
        static private void ShowElemFrame(int countElem)
        {
            // разделительная линия между полями заголовка
            string line = new string('═', 80);

            // координаты для позиционирования курсора
            int x = 5;
            int y = Console.CursorTop;

            // если количество элементов равно нулю
            if (countElem == 0)
            {
                // вывод сообщения 
                WriteColorXY($"╔{line}╗", x, y++, ConsoleColor.Magenta);
                WriteColorXY($"║{' ',80}║", x, y++, ConsoleColor.Magenta);
                WriteColorXY($"║{' ',80}║", x, y++, ConsoleColor.Magenta);
                WriteColorXY($"║{' ',80}║", x, y, ConsoleColor.Magenta);
                WriteColorXY($"{"Нет данных"}", x + 36, y++, ConsoleColor.Red);
                WriteColorXY($"║{' ',80}║", x, y++, ConsoleColor.Magenta);
                WriteColorXY($"║{' ',80}║", x, y++, ConsoleColor.Magenta);
                WriteColorXY($"╚{line}╝", x, y++, ConsoleColor.Magenta);

                // позиционирование 
                PosXY(0, y + 1);

                return;
            }

            // исходная позиция по y
            int yTemp = y;

            // чать разделительной линии 
            string partLine = new string('═', 20);

            // вывод рамки

            // вывод линии разделителя 
            WriteColorXY($"╔{partLine,-20}╦═════╦═════╦═════╦═════╦═════╦═════╦═════╦═════╦═════╦═════╗", x, y++, ConsoleColor.Magenta);

            // позиционирование 
            PosXY(x, y);

            // вывод 
            WriteColorXY($"║ ", textColor: ConsoleColor.Magenta);
            WriteColorXY($"      Индекс      ", textColor: ConsoleColor.Cyan);
            WriteColorXY($" ║ ", textColor: ConsoleColor.Magenta);

            // вывод индексов
            WriteColorXY(" ║     ║     ║     ║     ║     ║     ║     ║     ║     ║     ║\n\n",
            x + 20, y, ConsoleColor.Magenta);

            // вывод линии разделителя 
            WriteColorXY($"╠{partLine,-20}╬═════╬═════╬═════╬═════╬═════╬═════╬═════╬═════╬═════╬═════╣", x, ++y, ConsoleColor.Magenta);

            WriteColorXY($"║ ", x, ++y, textColor: ConsoleColor.Magenta);
            WriteColorXY($"     Значение    ", textColor: ConsoleColor.Cyan);

            // вывод полей для вывода элементов 
            WriteColorXY(" ║     ║     ║     ║     ║     ║     ║     ║     ║     ║     ║\n",
            x + 20, y, ConsoleColor.Magenta);

            // вывод линии разделителя подвала
            WriteColorXY($"╚{partLine,-20}╩═════╩═════╩═════╩═════╩═════╩═════╩═════╩═════╩═════╩═════╝", x, textColor: ConsoleColor.Magenta);

            y++;

            // установка курсора для вывода значения первого элемента 
            PosXY(x + 23, yTemp + 1);
        }

        // вывод элементв 
        static private void ShowElem<T>(int num, T value, ConsoleColor colorIndex = ConsoleColor.DarkYellow, ConsoleColor colorValue = ConsoleColor.Green)
        {
            // координаты для позиционирования 
            int x = Console.CursorLeft;
            int y = Console.CursorTop;

            // вывод индекса
            WriteColorXY($"{num,3}", x, y, textColor: colorIndex);

            // вывод элемента 
            WriteColorXY($"{value,5:n2}", x - 1, y + 2, textColor: colorValue);

            // смещение позиции по x
            PosXY(x + 6, y);
        }


        // вывод файла элементов типа double
        public static Action<double[], Predicate<(double item, int i)>> ShowDoubleArray = (array, predicate) =>
        {
            // вывод элементов массива
            for (int i = 0; i < array.Length; i++)
            {
                // вывод элемента
                ShowElem(i, array[i], colorValue: predicate((array[i], i)) ? ConsoleColor.Green : ConsoleColor.Blue);
            }

            // позиционирование курсора
            PosXY(0, Console.CursorTop + 4);
        };

        #endregion

        #endregion

    }
}
