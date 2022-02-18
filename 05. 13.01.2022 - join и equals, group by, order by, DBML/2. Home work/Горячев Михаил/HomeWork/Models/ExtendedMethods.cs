using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HomeWork.Models.Task1;                        // модели задания 1

using static HomeWork.Application.App.Utils;        // утилиты

namespace HomeWork.Models
{
    // Класс Расширенные методы
    static public class ExtendedMethods
    {
        #region Расширенные методы задания 1 (Книги)

        // вывод книг с расшифрованными полями в виде таблицы
        public static void ShowTable(this List<BookViewModel> books)
        {
            // вывод заголовка таблицы 
            BookViewModel.ShowHeadBooks();

            // вывод элементов 
            books.ForEach(b => b.ShowElem());

            // вывод подвала таблицы
            BookViewModel.ShowFooterBooks();
        }

        #endregion


        #region Расширенные методы задания 2 (Оптовый магазин. Учет продаж)


        #region Вывод всех записей Units                    (Единицы_измерения)

        // вывод таблицы
        public static void ShowTableUnits(this List<Unit> units)
        {
            // вывод заголовка таблицы 
            ShowHeadUnits();

            // вывод элементов 
            units.ForEach(u => u.ShowElem());

            // вывод подвала таблицы
            ShowFooterUnits();
        }


        // вывод заголовка таблицы 
        static public void ShowHeadUnits()
        {
            WriteColorXY("     ╔════╦══════════════════════╦════════════╗\n", textColor: ConsoleColor.Magenta);
            WriteColorXY("     ║    ║                      ║            ║", textColor: ConsoleColor.Magenta);
            WriteColorXY("ID",                   7, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Название",            12, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Сокращение",          35, textColor: ConsoleColor.DarkYellow);
            Console.WriteLine();

            WriteColorXY("     ╠════╬══════════════════════╬════════════╣\n", textColor: ConsoleColor.Magenta);

        } // ShowHeadUnits


        // вывод элемента 
        static public void ShowElem(this Unit unit)
        {
            WriteColorXY("     ║    ║                      ║            ║", textColor: ConsoleColor.Magenta);
            WriteColorXY($"{unit.Id,2}",     7, textColor: ConsoleColor.DarkGray);
            WriteColorXY($"{unit.Long}",    12, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{unit.Short}",   35, textColor: ConsoleColor.Green);
            Console.WriteLine();
        } // ShowElem


        // вывод подвала таблицы
        static public void ShowFooterUnits() =>
            WriteColorXY("     ╚════╩══════════════════════╩════════════╝\n", textColor: ConsoleColor.Magenta);


        #endregion


        #region Вывод всех записей Goods                    (Товары)


        // вывод таблицы
        public static void ShowTableGoods(this List<Good> goods)
        {
            // вывод заголовка таблицы 
            ShowHeadGoods();

            // вывод элементов 
            goods.ForEach(g => g.ShowElem());

            // вывод подвала таблицы
            ShowFooterGoods();
        }


        // вывод заголовка таблицы 
        static public void ShowHeadGoods()
        {
            WriteColorXY("     ╔════╦══════════════════════╗\n", textColor: ConsoleColor.Magenta);
            WriteColorXY("     ║    ║                      ║", textColor: ConsoleColor.Magenta);
            WriteColorXY("ID",           7, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Название",    12, textColor: ConsoleColor.DarkYellow);
            Console.WriteLine();

            WriteColorXY("     ╠════╬══════════════════════╣\n", textColor: ConsoleColor.Magenta);

        } // ShowHeadGoods


        // вывод элемента 
        static public void ShowElem(this Good goods)
        {
            WriteColorXY("     ║    ║                      ║", textColor: ConsoleColor.Magenta);
            WriteColorXY($"{goods.Id,2}",     7, textColor: ConsoleColor.DarkGray);
            WriteColorXY($"{goods.Name}",    12, textColor: ConsoleColor.Cyan);
            Console.WriteLine();
        } // ShowElem


        // вывод подвала таблицы
        static public void ShowFooterGoods() =>
            WriteColorXY("     ╚════╩══════════════════════╝\n", textColor: ConsoleColor.Magenta);


        #endregion


        #region Вывод всех записей Sellers                  (Продавцы)

        // вывод таблицы
        public static void ShowTableSellers(this List<Seller> sellers)
        {
            // вывод заголовка таблицы 
            ShowHeadSellers();

            // вывод элементов 
            sellers.ForEach(s => s.ShowElem());

            // вывод подвала таблицы
            ShowFooterSellers();
        }


        // вывод заголовка таблицы 
        static public void ShowHeadSellers()
        {
            WriteColorXY("     ╔════╦══════════════════════╦══════════════════════╦══════════════════════╦════════════╗\n", textColor: ConsoleColor.Magenta);
            WriteColorXY("     ║    ║                      ║                      ║                      ║            ║", textColor: ConsoleColor.Magenta);
            WriteColorXY("ID",           7, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Фамилия",     12, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Имя",         35, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Отчество",    58, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Процент",     81, textColor: ConsoleColor.DarkYellow);
            Console.WriteLine();

            WriteColorXY("     ╠════╬══════════════════════╬══════════════════════╬══════════════════════╬════════════╣\n", textColor: ConsoleColor.Magenta);

        } // ShowHeadSellers


        // вывод элемента 
        static public void ShowElem(this Seller seller)
        {
            WriteColorXY("     ║    ║                      ║                      ║                      ║            ║", textColor: ConsoleColor.Magenta);
            WriteColorXY($"{seller.Id,2}",               7, textColor: ConsoleColor.DarkGray);
            WriteColorXY($"{seller.Surname}",           12, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{seller.Name}",              35, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{seller.Patronymic,10}",     58, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{seller.Interest,10:n1}",    81, textColor: ConsoleColor.Green);
            Console.WriteLine();
        } // ShowElem


        // вывод подвала таблицы
        static public void ShowFooterSellers() =>
            WriteColorXY("     ╚════╩══════════════════════╩══════════════════════╩══════════════════════╩════════════╝\n", textColor: ConsoleColor.Magenta);


        #endregion


        #region Вывод всех записей Purchases                (Закупки)


        // вывод таблицы
        public static void ShowTablePurchases(this List<Purchase> purchases)
        {
            // вывод заголовка таблицы 
            ShowHeadPurchases();

            // вывод элементов 
            purchases.ForEach(p => p.ShowElem());

            // вывод подвала таблицы
            ShowFooterPurchases();
        }


        // вывод заголовка таблицы 
        static public void ShowHeadPurchases()
        {
            WriteColorXY("     ╔════╦══════════════════════╦════════════╦════════════╦════════════╦════════════╗\n", textColor: ConsoleColor.Magenta);
            WriteColorXY("     ║    ║                      ║            ║            ║            ║            ║", textColor: ConsoleColor.Magenta);
            WriteColorXY("ID",               7, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Название",        12, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Ед. измер.",      35, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Цена",            48, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Количество",      61, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Дата зак.",       74, textColor: ConsoleColor.DarkYellow);
            Console.WriteLine();

            WriteColorXY("     ╠════╬══════════════════════╬════════════╬════════════╬════════════╬════════════╣\n", textColor: ConsoleColor.Magenta);

        } // ShowHeadPurchases


        // вывод элемента 
        static public void ShowElem(this Purchase purchase)
        {
            WriteColorXY("     ║    ║                      ║            ║            ║            ║            ║", textColor: ConsoleColor.Magenta);
            WriteColorXY($"{purchase.Id,2}",             7, textColor: ConsoleColor.DarkGray);
            WriteColorXY($"{purchase.Good.Name}",       12, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{purchase.Unit.Short}",      35, textColor: ConsoleColor.Green);
            WriteColorXY($"{purchase.Price,10:n0}",     48, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{purchase.Amount,10:n0}",    61, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{purchase.DatePurchase:d}",  74, textColor: ConsoleColor.Green);
            Console.WriteLine();
        } // ShowElem


        // вывод подвала таблицы
        static public void ShowFooterPurchases() =>
            WriteColorXY("     ╚════╩══════════════════════╩════════════╩════════════╩════════════╩════════════╝\n", textColor: ConsoleColor.Magenta);



        #endregion


        #region Вывод всех записей Sales                    (Продажи)

        // вывод таблицы
        public static void ShowTableSales(this List<Sale> sales)
        {
            // вывод заголовка таблицы 
            ShowHeadSales();

            // вывод элементов 
            sales.ForEach(s => s.ShowElem());

            // вывод подвала таблицы
            ShowFooterSales();
        }


        // вывод заголовка таблицы 
        static public void ShowHeadSales()
        {
            WriteColorXY("     ╔════╦════════════╦══════════════════════╦══════════════════════╦════════════╦════════════╦════════════╗\n", textColor: ConsoleColor.Magenta);
            WriteColorXY("     ║    ║            ║                      ║                      ║            ║            ║            ║", textColor: ConsoleColor.Magenta);
            WriteColorXY("ID",           7, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Дата",        12, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Продавец",    25, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Товар",       48, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Количество",  71, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Цена",        84, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Ед. измер.",  97, textColor: ConsoleColor.DarkYellow);
            Console.WriteLine();

            WriteColorXY("     ╠════╬════════════╬══════════════════════╬══════════════════════╬════════════╬════════════╬════════════╣\n", textColor: ConsoleColor.Magenta);

        } // ShowHeadSales


        // вывод элемента 
        static public void ShowElem(this Sale sale)
        {
            WriteColorXY("     ║    ║            ║                      ║                      ║            ║            ║            ║", textColor: ConsoleColor.Magenta);
            WriteColorXY($"{sale.Id,2}",                 7, textColor: ConsoleColor.DarkGray);
            WriteColorXY($"{sale.DateSell:d}",          12, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{sale.Seller.Surname} {sale.Seller.Name[0]}. {sale.Seller.Patronymic[0]}.", 25, textColor: ConsoleColor.Green);
            WriteColorXY($"{sale.Purchase.Good.Name}",  48, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{sale.Amount,10:n0}",        71, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{sale.Price,10:n0}",         84, textColor: ConsoleColor.Green);
            WriteColorXY($"{sale.Unit.Short}",          97, textColor: ConsoleColor.Green);
            Console.WriteLine();
        } // ShowElem


        // вывод подвала таблицы
        static public void ShowFooterSales() =>
            WriteColorXY("     ╚════╩════════════╩══════════════════════╩══════════════════════╩════════════╩════════════╩════════════╝\n", textColor: ConsoleColor.Magenta);



        #endregion




        #endregion

    }
}
