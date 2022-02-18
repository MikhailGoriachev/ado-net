using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HomeWork.Models;                  // модели 
using HomeWork.Models.ViewModels;       // модели представления
using HomeWork.Utilities;               // утилиты

/*
 * Разработайте, пожалуйста, приложение Windows Forms для решения задачи на выполнение 
 * запросов к базе данных учета продаж оптового магазина из задания на 24.11.2021. 
 * Разработайте и выполните запросы LINQ to SQL с использованием расширяющих методов. 
 * Выводите результаты запросов в DataGridView в отдельных вкладках. Один запрос – одна
 * вкладка. 
 * 
 * Используйте меню, панель инструментов, окно с выводом сведений о приложении и
 * разработчике. При необходимости используйте вспомогательные классы для отображения 
 * результатов запросов к связанным таблицам.
 * 
 * База данных «Оптовый магазин. Учет продаж». Описание предметной области
 * Оптовый магазин закупает товар по Цене закупки единицы товара и продает товар по 
 * Цене продажи единицы товара. Разница между ценой продажи и ценой закупки составляет 
 * прибыль магазина от реализации единицы товара.
 * 
 * Каждый продавец получает комиссионное вознаграждение за проданный товар. Размер этого
 * вознаграждения равен: Цена продажи единицы товара * Кол-во проданных единиц товара * 
 * Процент комиссионных продавца.
 * 
 * Прибыль от продажи партии товара вычисляется как (Цена продажи единицы товара - Цена 
 * закупки единицы товара) * Кол-во проданных единиц товара.
 * 
 * База данных должна включать как минимум таблицы ТОВАРЫ, ПРОДАВЦЫ, ПРОДАЖИ, содержащие
 * следующую информацию:
 * Наименование товара
 * Единица измерения товара
 * Цена закупки единицы товара
 * Дата продажи товара
 * Цена продажи единицы товара
 * Количество проданных единиц товара
 * Фамилия продавца, оформившего продажу
 * Имя продавца, оформившего продажу
 * Отчество продавца, оформившего продажу
 * Процент комиссионных продавца, оформившего продажу
 * 
 * Разработайте скрипты:
 * 1.	создания таблиц 
 * 2.	заполнения таблиц начальным набором данных. Каждая таблица должна содержать 
 *      не менее 10 записей.
 * 3.	Запросы SQL по заданию
 * 
 * Запросы:
 * 1	Запрос с параметрами	Выбирает из таблицы ТОВАРЫ информацию о товарах, 
 *      единицей измерения которых является «шт» (штуки) и цена закупки составляет
 *      меньше 200 руб.
 * 2	Запрос с параметрами	Выбирает из таблицы ТОВАРЫ информацию о товарах, цена
 *      закупки которых больше 500 руб. за единицу товара
 * 3	Запрос с параметрами	Выбирает из таблицы ТОВАРЫ информацию о товарах с 
 *      заданным наименованием (например, «чехол защитный»), для которых цена закупки 
 *      меньше 1800 руб.
 * 4	Запрос с параметрами	Выбирает из таблицы ПРОДАВЦЫ информацию о продавцах с 
 *      заданным значением процента комиссионных. 
 * 5	Запрос с параметрами	Выбирает из таблиц ТОВАРЫ, ПРОДАВЦЫ и ПРОДАЖИ 
 *      информацию обо всех зафиксированных фактах продажи товаров (Наименование 
 *      товара, Цена закупки, Цена продажи, дата продажи), для которых Цена продажи 
 *      оказалась в некоторых заданных границах. 
 * 6	Запрос с вычисляемыми полями	Вычисляет прибыль от продажи за каждый 
 *      проданный товар. Включает поля Дата продажи, Наименование товара, Цена 
 *      закупки, Цена продажи, Количество проданных единиц, Прибыль. Сортировка по 
 *      полю Наименование товара
 * 		
 * 7	Итоговый запрос	Выполняет группировку по полю Наименование товара. Для 
 *      каждого наименования вычисляет среднюю цену закупки товара, количество закупок
 * 8	Итоговый запрос	Выполняет группировку по полю Код продавца из таблицы ПРОДАЖИ. 
 *      Для каждого продавца вычисляет среднее значение по полю Цена продажи единицы 
 *      товара, количество продаж
 *      
 * При помощи запросов LINQ to SQL также выведите все таблицы Вашей базы данных.
*/


namespace HomeWork.Controllers
{
    // Класс Контроллер обработки по заданию 2 (Оптовый магазин. Учет продаж)
    public class TaskController
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
        public TaskController() : this(new SalesAccountingDataContext()) { }


        // конструктор инициализирующий
        public TaskController(SalesAccountingDataContext data)
        {
            _data = data;
        }


        #endregion

        #region Методы

        #region Вывод таблиц

        // вывод всех записей Units         (Единицы_измерения)
        public List<Unit> QueryUnits() => _data.Units.ToList();


        // вывод всех записей Goods         (Товары)
        public List<Good> QueryGoods() => _data.Goods.ToList();


        // вывод всех записей Sellers       (Продавцы)
        public List<Seller> QuerySellers() => _data.Sellers.ToList();


        // вывод всех записей Purchases     (Закупки)
        public List<PurchaseViewModel> QueryPurchases() => _data.Purchases.Select(p => new PurchaseViewModel(p)).ToList();


        // вывод всех записей Sales         (Продажи)
        public List<SaleViewModel> QuerySales() => _data.Sales.Select(s => new SaleViewModel(s)).ToList();

        #endregion 


        #region Запросы


        // 1. Товары с еденицей измерения "шт" и цена закупки меньше 200 руб.                           (Extended)
        public List<PurchaseViewModel> Query1() => _data.Purchases.Where(p => p.Unit.Short == "шт" && p.Price < 200)
                                                                  .Select(p => new PurchaseViewModel(p))
                                                                  .ToList();


        // 2. Товары цена закупки, которых больше 500 руб.                                              (Extended)
        public List<PurchaseViewModel> Query2() => _data.Purchases.Where(p => p.Price > 500)
                                                                  .Select(p => new PurchaseViewModel(p))
                                                                  .ToList();


        // 3. Товары с заданным наименованием и цена закупки меньше 1800 руб.                           (Extended)
        public List<PurchaseViewModel> Query3(string name) => _data.Purchases.Where(p => p.Good.Name == name && p.Price < 1800)
                                                                             .Select(p => new PurchaseViewModel(p))
                                                                             .ToList();


        // 4. Продавцы с заданным значением процента комисионных                                        (Extended)
        public List<Seller> Query4(double interest) => _data.Sellers.Where(s => s.Interest == interest)
                                                                    .ToList();


        // 5. Факты продажи товаров, для которых цена продажи в заданном диапазоне                      (Extended)
        public List<SaleViewModel> Query5(int priceLo, int priceHi) => _data.Sales.Where(s => s.Price >= priceLo && s.Price <= priceHi)
                                                                                  .Select(s => new SaleViewModel(s))
                                                                                  .ToList();


        // 6. Прибыль от продажи за каждый проданный товар. Сортировка по полю наименование товара       (Extended)
        public IEnumerable Query6() => _data.Sales.OrderBy(s => s.Purchase.Good.Name)
                                                  .Select(s => new {
                                                      s.Id,
                                                      s.DateSell,
                                                      Goods = s.Purchase.Good.Name,
                                                      Seller = $"{s.Seller.Surname} {s.Seller.Name[0]}. {s.Seller.Patronymic[0]}.",
                                                      s.Amount,
                                                      s.Price,
                                                      Unit = s.Unit.Long,
                                                      SumPrice = s.Price * s.Amount
                                                  });


        // 7. Средняя цена закупки товара, количество закупок
        public IEnumerable Query7() => _data.Purchases.GroupBy(p => new { p.Good.Name, p.Good.Id })
                                                      .Select(p => new {
                                                          Id = p.Key.Id,
                                                          Goods = p.Key.Name,
                                                          Avarage = p.Average(i => i.Price),
                                                          Count = p.Count()
                                                      });


        // 8. Вычисление для каждого продавца среднего значения по полю Цена продажи единицы товара и количества продаж
        public IEnumerable Query8() => _data.Sales.GroupBy(s => new { s.Seller.Id, s.Seller.Surname, s.Seller.Name, s.Seller.Patronymic })
                                                    .Select(s => new
                                                    {
                                                        Id = s.Key.Id,
                                                        s.Key.Surname,
                                                        s.Key.Name,
                                                        s.Key.Patronymic,
                                                        Count = s.Count(),
                                                        AvgPrice = s.Average(i => i.Price),
                                                    });

        #endregion


        #endregion

    }
}
