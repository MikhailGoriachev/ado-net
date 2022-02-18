using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HomeWork.Models;                              // модели 

using static HomeWork.Application.App.Utils;        // утилиты

/*
* •	Задача 2. Для базы данных учета продаж оптового магазина из задания на 
*   24.11.2021 разработайте и выполните запросы LINQ to SQL. Реализуйте два 
*   варианта – с использованием синтаксиса запросов и с использованием 
*   расширяющих методов.
*   
*   База данных «Оптовый магазин. Учет продаж»
*   
*   Описание предметной области
*   Оптовый магазин закупает товар по Цене закупки единицы товара и продает 
*   товар по Цене продажи единицы товара. Разница между ценой продажи и ценой
*   закупки составляет прибыль магазина от реализации единицы товара.
*   
*   Каждый продавец получает комиссионное вознаграждение за проданный товар. 
*   Размер этого вознаграждения равен: Цена продажи единицы товара * Кол-во 
*   проданных единиц товара * Процент комиссионных продавца.
*   Прибыль от продажи партии товара вычисляется как (Цена продажи единицы 
*   товара - Цена закупки единицы товара) * Кол-во проданных единиц товара.
*   
*   База данных должна включать как минимум таблицы ТОВАРЫ, ПРОДАВЦЫ, ПРОДАЖИ, 
*   содержащие следующую информацию:
*       Наименование товара
*       Единица измерения товара
*       Цена закупки единицы товара
*       Дата продажи товара
*       Цена продажи единицы товара
*       Количество проданных единиц товара
*       Фамилия продавца, оформившего продажу
*       Имя продавца, оформившего продажу
*       Отчество продавца, оформившего продажу
*       Процент комиссионных продавца, оформившего продажу
*   
*   Разработайте скрипты:
*   1.	создания таблиц 
*   2.	заполнения таблиц начальным набором данных. Каждая таблица должна 
*       содержать не менее 10 записей.
*   3.	Запросы SQL по заданию
*   
*   Запросы: 
*   1	Запрос с параметрами	Выбирает из таблицы ТОВАРЫ информацию о 
*       товарах, единицей измерения которых является «шт» (штуки) и цена
*       закупки составляет меньше 200 руб.
*       
*   2	Запрос с параметрами	Выбирает из таблицы ТОВАРЫ информацию о 
*       товарах, цена закупки которых больше 500 руб. за единицу товара
*   
*   3	Запрос с параметрами	Выбирает из таблицы ТОВАРЫ информацию о 
*       товарах с заданным наименованием (например, «чехол защитный»), для
*       которых цена закупки меньше 1800 руб.
*       
*   4	Запрос с параметрами	Выбирает из таблицы ПРОДАВЦЫ информацию 
*       о продавцах с заданным значением процента комиссионных. 
*       
*   5	Запрос с параметрами	Выбирает из таблиц ТОВАРЫ, ПРОДАВЦЫ и 
*       ПРОДАЖИ информацию обо всех зафиксированных фактах продажи товаров
*       (Наименование товара, Цена закупки, Цена продажи, дата продажи), для 
*       которых Цена продажи оказалась в некоторых заданных границах. 
*       
*   6	Запрос с вычисляемыми полями	Вычисляет прибыль от продажи за 
*       каждый проданный товар. Включает поля Дата продажи, Наименование 
*       товара, Цена закупки, Цена продажи, Количество проданных единиц, 
*       Прибыль. Сортировка по полю Наименование товара
*       
*   При помощи запросов LINQ to SQL также выведите все таблицы Вашей базы данных.
*/

namespace HomeWork.Controllers
{
    // Класс Контроллер обработки по заданию 2 (Оптовый магазин. Учет продаж)
    public class Task2Controller
    {
        // объект базы данных
        private SalesAccountingDataContext _data;

        public SalesAccountingDataContext Data
        {
            get => _data;
            set => _data = value;
        }


        #region Конструкторы 


        // конструктор по умолчанию
        public Task2Controller() : this(new SalesAccountingDataContext()) { }


        // конструктор инициализирующий
        public Task2Controller(SalesAccountingDataContext data)
        {
            _data = data;
        }


        #endregion

        #region Методы

        #region Вывод таблиц

        // вывод всех записей Units         (Единицы_измерения)
        public void ShowUnits() => _data.Units.ToList().ShowTableUnits();


        // вывод всех записей Goods         (Товары)
        public void ShowGoods() => _data.Goods.ToList().ShowTableGoods();


        // вывод всех записей Sellers       (Продавцы)
        public void ShowSellers() => _data.Sellers.ToList().ShowTableSellers();


        // вывод всех записей Purchases     (Закупки)
        public void ShowPurchases() => _data.Purchases.ToList().ShowTablePurchases();


        // вывод всех записей Sales         (Продажи)
        public void ShowSales() => _data.Sales.ToList().ShowTableSales();

        #endregion 


        #region Запросы

        // 1. Товары с еденицей измерения "шт" и цена закупки меньше 200 руб.                           (Linq)
        public void ShowProc1Linq() => (from purchase in _data.Purchases
                                        where purchase.Unit.Short == "шт" && purchase.Price < 200
                                        select purchase)
                                        .ToList()
                                        .ShowTablePurchases();


        // 1. Товары с еденицей измерения "шт" и цена закупки меньше 200 руб.                           (Extended)
        public void ShowProc1Extended() => _data.Purchases.Where(p => p.Unit.Short == "шт" && p.Price < 200)
                                                          .ToList()
                                                          .ShowTablePurchases();


        // 2. Товары цена закупки, которых больше 500 руб.                                              (Linq)
        public void ShowProc2Linq() => (from purchase in _data.Purchases
                                        where purchase.Price > 500
                                        select purchase)
                                        .ToList()
                                        .ShowTablePurchases();


        // 2. Товары цена закупки, которых больше 500 руб.                                              (Extended)
        public void ShowProc2Extended() => _data.Purchases.Where(p => p.Price > 500)
                                                          .ToList()
                                                          .ShowTablePurchases();


        // 3. Товары с заданным наименованием и цена закупки меньше 1800 руб.                           (Linq)
        public void ShowProc3Linq(string name) => (from purchase in _data.Purchases
                                                   where purchase.Good.Name == name
                                                   select purchase)
                                                   .ToList()
                                                   .ShowTablePurchases();



        // 3. Товары с заданным наименованием и цена закупки меньше 1800 руб.                           (Extended)
        public void ShowProc3Extended(string name) => _data.Purchases.Where(p => p.Good.Name == name && p.Price < 1800)
                                                                     .ToList()
                                                                     .ShowTablePurchases();


        // 4. Продавцы с заданным значением процента комисионных                                        (Linq)
        public void ShowProc4Linq(double interest) => (from seller in _data.Sellers
                                                       where seller.Interest == interest
                                                       select seller)
                                                       .ToList()
                                                       .ShowTableSellers();


        // 4. Продавцы с заданным значением процента комисионных                                        (Extended)
        public void ShowProc4Extended(double interest) => _data.Sellers.Where(s => s.Interest == interest)
                                                                       .ToList()
                                                                       .ShowTableSellers();


        // 5. Факты продажи товаров, для которых цена продажи в заданном диапазоне                      (Linq)
        public void ShowProc5Linq(int priceLo, int priceHi) => (from sale in _data.Sales
                                                                where sale.Price >= priceLo && sale.Price <= priceHi
                                                                select sale)
                                                                .ToList()
                                                                .ShowTableSales();


        // 5. Факты продажи товаров, для которых цена продажи в заданном диапазоне                      (Extended)
        public void ShowProc5Extended(int priceLo, int priceHi) => _data.Sales.Where(s => s.Price >= priceLo && s.Price <= priceHi)
                                                                              .ToList()
                                                                              .ShowTableSales();


        // 6. Прибыль от продажи за каждый проданный товар.Сортировка по полю наименование товара       (Linq)
        public void ShowProc6Linq()
        {
            // результат
            var result = (from sale in _data.Sales
                          orderby sale.Purchase.Good.Name
                          select new
                          {
                              sale.Id,
                              sale.DateSell,
                              Goods = sale.Purchase.Good.Name,
                              Seller = $"{sale.Seller.Surname} {sale.Seller.Name[0]}. { sale.Seller.Patronymic[0]}. { sale.Purchase.Good.Name[0]}",
                              sale.Amount,
                              sale.Price,
                              Unit = sale.Unit.Short,
                              SumPrice = sale.Price * sale.Amount
                          }).ToList();

            // вывод результата
            ShowHeadProc6();
            result.ForEach(r => ShowElemProc6(r.Id, r.DateSell, r.Seller, r.Goods, r.Amount, r.Price, r.Unit, r.SumPrice));
            ShowFooterProc6();

        } // ShowProc6Linq


        // 6. Прибыль от продажи за каждый проданный товар.Сортировка по полю наименование товара       (Extended)
        public void ShowProc6Extended()
        {
            // результат
            var result = _data.Sales.OrderBy(s => s.Purchase.Good.Name)
                                    .Select(s => new {
                                                    s.Id,
                                                    s.DateSell,
                                                    Goods = s.Purchase.Good.Name,
                                                    Seller = $"{s.Seller.Surname} {s.Seller.Name[0]}. {s.Seller.Patronymic[0]}. {s.Purchase.Good.Name[0]}",
                                                    s.Amount,
                                                    s.Price,
                                                    Unit = s.Unit.Short,
                                                    SumPrice = s.Price * s.Amount
                                                })
                                    .ToList();

            // вывод результата
            ShowHeadProc6();
            result.ForEach(r => ShowElemProc6(r.Id, r.DateSell, r.Seller, r.Goods, r.Amount, r.Price, r.Unit, r.SumPrice));
            ShowFooterProc6();

        } // ShowProc6Extended


        #endregion


        #region Вывод результата запроса 6

        // вывод заголовка таблицы 
        static public void ShowHeadProc6()
        {
            WriteColorXY("  ╔════╦════════════╦══════════════════════╦══════════════════════╦════════════╦════════════╦════════════╦════════════╗\n", textColor: ConsoleColor.Magenta);
            WriteColorXY("  ║    ║            ║                      ║                      ║            ║            ║            ║            ║", textColor: ConsoleColor.Magenta);
            WriteColorXY("ID",                4, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Дата",              9, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Продавец",         22, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Товар",            45, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Количество",       68, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Цена",             81, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Ед. измер.",       94, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Стоимость",       107, textColor: ConsoleColor.DarkYellow);
            Console.WriteLine();

            WriteColorXY("  ╠════╬════════════╬══════════════════════╬══════════════════════╬════════════╬════════════╬════════════╬════════════╣\n", textColor: ConsoleColor.Magenta);
        } // ShowHeadBooks


        // вывод элемента
        public void ShowElemProc6(int id, DateTime dateSell, string seller, string goods, int amount, int price, string unit, int sumPrice)
        {
            WriteColorXY("  ║    ║            ║                      ║                      ║            ║            ║            ║            ║", textColor: ConsoleColor.Magenta);
            WriteColorXY($"{id,2}",               4, textColor: ConsoleColor.DarkGray);
            WriteColorXY($"{dateSell:d}",         9, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{seller}",            22, textColor: ConsoleColor.Green);
            WriteColorXY($"{goods}",             45, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{amount,10:n0}",      68, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{price,10:n0}",       81, textColor: ConsoleColor.Green);
            WriteColorXY($"{unit}",              94, textColor: ConsoleColor.Green);
            WriteColorXY($"{sumPrice,10:n0}",   107, textColor: ConsoleColor.Green);
            Console.WriteLine();
        } // ShowElementsBooks


        // вывод подвала таблицы
        static public void ShowFooterProc6() =>
            WriteColorXY("  ╚════╩════════════╩══════════════════════╩══════════════════════╩════════════╩════════════╩════════════╩════════════╝\n", textColor: ConsoleColor.Magenta);


        #endregion 

        #endregion

    }
}
