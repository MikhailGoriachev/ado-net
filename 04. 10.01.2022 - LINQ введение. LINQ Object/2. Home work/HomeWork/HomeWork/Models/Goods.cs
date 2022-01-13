using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static HomeWork.Application.App.Utils;        // утилиты


namespace HomeWork.Models
{
    // Класс Товар
    public class Goods
    {

        // наименование
        private string _title;

        public string Title
        {
            get => _title;
            set => _title = !String.IsNullOrWhiteSpace(value) ? value :
                throw new Exception("Goods: Поле Title не может быть пустым!");
        }


        // цена
        private int _price;

        public int Price
        {
            get => _price;
            set => _price = value > 0 ? value : 
                throw new Exception("Goods: Поле Price должно быть больше 0!");
        }


        // количество
        private int _amount;

        public int Amount
        {
            get => _amount;
            set => _amount = value >= 0 ? value : 
                throw new Exception("Goods: Поле Amount должо быть больше или равно 0!");
        }


        // год выпуска
        private int _year;

        public int Year
        {
            get => _year;
            set => _year = value >= 1990 ? value : 
                throw new Exception("Goods: Поле Year должно быть больше 1990!");
        }


        #region Методы 


        // вывод товаров в виде таблицы 
        static public void ShowTable(List<Goods> goods)
        {
            // вывод шапки таблицы 
            ShowHead();

            // порядковый номер элемента 
            int i = 1;

            // вывод элементов таблицы
            goods.ForEach(g => g.ShowElem(i++));

            // вывод подвала таблицы 
            ShowFooter();
        }


        // вывод шапки таблицы 
        static public void ShowHead()
        {
            WriteColorXY("     ╔════╦══════════════════════╦════════════╦════════════╦════════════╗\n", textColor: ConsoleColor.Magenta);
            WriteColorXY("     ║    ║                      ║            ║            ║            ║",   textColor: ConsoleColor.Magenta);
            WriteColorXY("N",               7, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Наименование",   12, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Цена",           35, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Количество",     48, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Год выпуск",     61, textColor: ConsoleColor.DarkYellow);
            Console.WriteLine();

            WriteColorXY("     ╠════╬══════════════════════╬════════════╬════════════╬════════════╣\n", textColor: ConsoleColor.Magenta);
        } // ShowHead


        // вывод элемента таблицы
        public void ShowElem(int num)
        {
            WriteColorXY("     ║    ║                      ║            ║            ║            ║", textColor: ConsoleColor.Magenta);
            WriteColorXY($"{num,2}",             7, textColor: ConsoleColor.DarkGray);
            WriteColorXY($"{_title}",           12, textColor: ConsoleColor.Green);
            WriteColorXY($"{_price, 10:n0}",    35, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{_amount, 10}",      48, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{_year,10:d}",       61, textColor: ConsoleColor.Green);
            Console.WriteLine();
        } // ShowElem


        // вывод подвала таблицы
        static public void ShowFooter() =>
            WriteColorXY("     ╚════╩══════════════════════╩════════════╩════════════╩════════════╝\n", textColor: ConsoleColor.Magenta);


        #region Вывод в табличном виде в выводом процента скидки


        // вывод шапки таблицы 
        static public void ShowHeadDisount()
        {
            WriteColorXY("     ╔════╦══════════════════════╦════════════╦════════════╦════════════╦════════════╗\n", textColor: ConsoleColor.Magenta);
            WriteColorXY("     ║    ║                      ║            ║            ║            ║            ║", textColor: ConsoleColor.Magenta);
            WriteColorXY("N",                    7, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Наименование",        12, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Цена",                35, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Количество",          48, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Год выпуск",          61, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Скидка (%)",          74, textColor: ConsoleColor.DarkYellow);
            Console.WriteLine();

            WriteColorXY("     ╠════╬══════════════════════╬════════════╬════════════╬════════════╬════════════╣\n", textColor: ConsoleColor.Magenta);
        } // ShowHead


        // вывод элемента таблицы
        public void ShowElemDisount(int num, int discount)
        {
            WriteColorXY("     ║    ║                      ║            ║            ║            ║            ║", textColor: ConsoleColor.Magenta);
            WriteColorXY($"{num, 2}",            7, textColor: ConsoleColor.DarkGray);
            WriteColorXY($"{_title}",           12, textColor: ConsoleColor.Green);
            WriteColorXY($"{_price,10:n0}",     35, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{_amount,10}",       48, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{_year,10:d}",       61, textColor: ConsoleColor.Green);
            WriteColorXY($"{discount, 8} %",    74, textColor: ConsoleColor.Green);
            Console.WriteLine();
        } // ShowElem


        // вывод подвала таблицы
        static public void ShowFooterDisount() =>
            WriteColorXY("     ╚════╩══════════════════════╩════════════╩════════════╩════════════╩════════════╝\n", textColor: ConsoleColor.Magenta);


        #endregion

        #endregion
    }
}
