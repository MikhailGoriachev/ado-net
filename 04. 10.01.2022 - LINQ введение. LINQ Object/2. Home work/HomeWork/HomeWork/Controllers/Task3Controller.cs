using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork.Models;      // модели

using static HomeWork.Application.App.Utils;      // утилиты

/*
* •	Задача 3. Для коллекции товаров из задачи 1 выполнить следующие LINQ-запросы (создавайте 2 варианта
*   запросов – в синтаксисе LINQ и в синтаксисе расширяющих методов):
*   o	товары с заданным диапазоном цен
*   o	сумма товаров с заданным годом выпуска
*   o	сумма товаров с заданным наименованием (суммируем произведение цены на количество, наименование 
*       товара может быть задано частично, но без маски типа %, _)
*   o	наименование и год выпуска товаров с максимальным количеством
*   o	все товары, для которых произведение цены на количество находится в заданном диапазоне
*/


namespace HomeWork.Controllers
{
    // Класс Контроллер обработки по заданию 3
    public class Task3Controller
    {
        // коллекция товаров
        private List<Goods> _goodsList;

        public List<Goods> GoodsList
        {
            get => _goodsList;
            set => _goodsList = value;
        }

        #region Конструкторы

        // конструктор по умолчанию
        public Task3Controller() : this(new List<Goods>().Initialization(15)) { }


        // конструктор инициализирующий
        public Task3Controller(List<Goods> goodsList)
        {
            // установка значений
            _goodsList = goodsList;
        }

        #endregion

        #region Методы
        
        // товары с заданным диапазоном цен                                             (LINQ)
        public List<Goods> Proc1Linq(int loPrice, int hiPrice) =>
            (from goods in _goodsList
            where goods.Price >= loPrice && goods.Price <= hiPrice
            select goods)
            .ToList();


        // товары с заданным диапазоном цен                                             (Extended Methods)
        public List<Goods> Proc1Extended(int loPrice, int hiPrice) =>
            _goodsList
                .Where(g => g.Price >= loPrice && g.Price <= hiPrice)
                .ToList();



        // сумма товаров с заданным годом выпуска                                       (LINQ)
        public int Proc2Linq(int year) =>
            (from goods in _goodsList
             where goods.Year == year
             select goods.Amount * goods.Price)
            .Sum();


        // сумма товаров с заданным годом выпуска                                       (Extended Methods)
        public int Proc2Extended(int year) =>
            _goodsList
                .Where(g => g.Year == year)
                .Sum(g => g.Amount * g.Price);


        // сумма товаров с заданным наименованием                                       (LINQ)
        public int Proc3Linq(string title) =>
            (from goods in _goodsList
             where goods.Title.Contains(title)
             select goods.Price * goods.Amount)
            .Sum();


        // сумма товаров с заданным наименованием                                       (Extended Methods)
        public int Proc3Extended(string title) =>
            _goodsList
                .Where(g => g.Title.Contains(title))
                .Sum(g => g.Price * g.Amount);


        // наименование и год выпуска товаров с максимальным количеством                (LINQ)
        public List<(string title, int year, int amount)> Proc4Linq() =>
            (from goods in _goodsList
             let max = _goodsList.Max(g => g.Amount)
             where goods.Amount == max
             select (goods.Title, goods.Year, goods.Amount)).ToList();


        // наименование и год выпуска товаров с максимальным количеством                (Extended Methods)
        public List<(string title, int year, int amount)> Proc4Extended()
        {
            var max = _goodsList.Max(g => g.Amount);

            return _goodsList
                    .Where(g => g.Amount == max)
                    .Select(g => (g.Title, g.Year, g.Amount))
                    .ToList();
        }


        // все товары, для которых произведение цены на количество находится в заданном диапазоне       (LINQ)
        public List<Goods> Proc5Linq(int loProd, int hiProd) =>
            (from goods in _goodsList
             where goods.Amount * goods.Price >= loProd && goods.Amount * goods.Price <= hiProd
             select goods)
            .ToList();


        // все товары, для которых произведение цены на количество находится в заданном диапазоне       (Extended Methods)
        public List<Goods> Proc5Extended(int loProd, int hiProd) =>
            _goodsList
                .Where(g => g.Amount * g.Price >= loProd && g.Amount * g.Price <= hiProd)
                .ToList();


        #region Вывод элементов для запроса 4


        // вывод товаров в виде таблицы 
        static public void ShowTableProc4(List<(string title, int year, int amount)> goods)
        {
            // вывод шапки таблицы 
            ShowHeadProc4();

            // порядковый номер элемента 
            int i = 1;

            // вывод элементов таблицы
            goods.ForEach(g => ShowElemProc4(g, i));

            // вывод подвала таблицы 
            ShowFooterProc4();
        }


        // вывод шапки таблицы 
        static public void ShowHeadProc4()
        {
            WriteColorXY("     ╔════╦══════════════════════╦════════════╦════════════╗\n", textColor: ConsoleColor.Magenta);
            WriteColorXY("     ║    ║                      ║            ║            ║", textColor: ConsoleColor.Magenta);
            WriteColorXY("N",                7, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Наименование",    12, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Количество",      35, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Год выпуск",      48, textColor: ConsoleColor.DarkYellow);
            Console.WriteLine();

            WriteColorXY("     ╠════╬══════════════════════╬════════════╬════════════╣\n", textColor: ConsoleColor.Magenta);
        } // ShowHead


        // вывод элемента таблицы
        static public void ShowElemProc4((string title, int year, int amount) goods, int num)
        {
            WriteColorXY("     ║    ║                      ║            ║            ║", textColor: ConsoleColor.Magenta);
            WriteColorXY($"{num, 2}",            7, textColor: ConsoleColor.DarkGray);
            WriteColorXY($"{goods.title}",      12, textColor: ConsoleColor.Green);
            WriteColorXY($"{goods.year,10:d}",  35, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{goods.amount:d}",   48, textColor: ConsoleColor.Green);
            Console.WriteLine();
        } // ShowElem


        // вывод подвала таблицы
        static public void ShowFooterProc4() =>
            WriteColorXY("     ╚════╩══════════════════════╩════════════╩════════════╝\n", textColor: ConsoleColor.Magenta);


        #endregion

        #region Вывод элементов для запроса 5


        // вывод товаров в виде таблицы 
        static public void ShowTableProc5(List<Goods> goods)
        {
            // вывод шапки таблицы 
            ShowHeadProc5();

            // порядковый номер элемента 
            int i = 1;

            // вывод элементов таблицы
            goods.ForEach(g => ShowElemProc5(g, i++));

            // вывод подвала таблицы 
            ShowFooterProc5();
        }


        // вывод шапки таблицы 
        static public void ShowHeadProc5()
        {
            WriteColorXY("     ╔════╦══════════════════════╦════════════╦════════════╦════════════╦════════════╗\n", textColor: ConsoleColor.Magenta);
            WriteColorXY("     ║    ║                      ║            ║            ║            ║            ║", textColor: ConsoleColor.Magenta);
            WriteColorXY("N",                7, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Наименование",    12, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Цена",            35, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Количество",      48, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Год выпуск",      61, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Произведен.",     74, textColor: ConsoleColor.DarkYellow);
            Console.WriteLine();

            WriteColorXY("     ╠════╬══════════════════════╬════════════╬════════════╬════════════╬════════════╣\n", textColor: ConsoleColor.Magenta);
        } // ShowHead


        // вывод элемента таблицы
        static public void ShowElemProc5(Goods goods, int num)
        {
            WriteColorXY("     ║    ║                      ║            ║            ║            ║            ║", textColor: ConsoleColor.Magenta);
            WriteColorXY($"{num, 2}",                            7, textColor: ConsoleColor.DarkGray);
            WriteColorXY($"{goods.Title}",                      12, textColor: ConsoleColor.Green);
            WriteColorXY($"{goods.Price,10:n0}",                35, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{goods.Amount,10}",                  48, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{goods.Year,10:d}",                  61, textColor: ConsoleColor.Green);
            WriteColorXY($"{goods.Price * goods.Amount,10}",    74, textColor: ConsoleColor.Cyan);
            Console.WriteLine();
        } // ShowElem


        // вывод подвала таблицы
        static public void ShowFooterProc5() =>
            WriteColorXY("     ╚════╩══════════════════════╩════════════╩════════════╩════════════╩════════════╝\n", textColor: ConsoleColor.Magenta);


        #endregion

        #endregion
    }
}
