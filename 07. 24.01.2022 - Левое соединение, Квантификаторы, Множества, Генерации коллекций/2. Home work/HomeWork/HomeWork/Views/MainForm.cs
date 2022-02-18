using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using HomeWork.Controllers;     // контроллеры
using HomeWork.Utilities;       // утилиты


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

namespace HomeWork.Views
{
    public partial class MainForm : Form
    {
        // контроллер обработки по заданию
        private TaskController _controller;

        public TaskController Controller
        {
            get => _controller;
            set => _controller = value;
        }


        #region Конструкторы

        // конструктор по умолчанию
        public MainForm() : this(new TaskController()) { }


        // конструктор инциализирующий
        public MainForm(TaskController controller)
        {
            InitializeComponent();

            // установка значений
            _controller = controller;
            TbcMain_SelectedIndexChanged(new object(), EventArgs.Empty);
        }


        #endregion


        #region Методы 


        #region Обработчики событий


        // выход из программы
        private void Exit_Command(object sender, EventArgs e) => Application.Exit();


        // открытие формы с информацией о программе
        private void Info_Command(object sender, EventArgs e) => new InfoForm().ShowDialog();



        #endregion


        #region Общие методы


        // переключение вкладки
        private void TbcMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            // выключение редактирующих кнопок
            TsiAdd.Enabled = TsiEdit.Enabled = false;

            switch (TbcMain.SelectedIndex)
            {
                // Содержание таблицы "Единицы измерения"
                case 0:
                    UpdateBinding(DgvUnits, _controller.QueryUnits());
                    break;

                // Содержание таблицы "Товары"
                case 1:

                    // включение редактирующих кнопок
                    TsiAdd.Enabled = TsiEdit.Enabled = true;

                    UpdateBinding(DgvGoods, _controller.QueryGoods());
                    break;

                // Содержание таблицы "Продавцы"
                case 2:
                    UpdateBinding(DgvSellers, _controller.QuerySellers());
                    break;

                // Содержание таблицы "Закупки"
                case 3:

                    // включение редактирующих кнопок
                    TsiAdd.Enabled = TsiEdit.Enabled = true;

                    UpdateBinding(DgvPurchases, _controller.QueryPurchases());
                    break;

                // Содержание таблицы "Продажи"
                case 4:
                    UpdateBinding(DgvSales, _controller.QuerySales());
                    break;

                // Запрос 1
                case 5:
                    UpdateBinding(DgvQuery1, _controller.Query1());
                    break;

                // Запрос 2
                case 6:
                    UpdateBinding(DgvQuery2, _controller.Query2());
                    break;

                // Запрос 3
                case 7:

                    // наименование товара 
                    string name = Utils.GetNameGoods();

                    // текст информации о запросе
                    string text3 = TbxQuery3.Text;

                    // вывод условий запроса
                    TbxQuery3.Text = text3.Remove(text3.LastIndexOf(':') + 2) + name;

                    // обновление привязки
                    UpdateBinding(DgvQuery3, _controller.Query3(name));
                    break;

                // Запрос 4
                case 8:

                    // процент коммисионных
                    double interest = Utils.GetInterestSeller();

                    // текст информации о запросе
                    string text4 = TbxQuery4.Text;

                    // вывод условий запроса
                    TbxQuery4.Text = text4.Remove(text4.LastIndexOf(':') + 2) + $"{interest:n1}";

                    UpdateBinding(DgvQuery4, _controller.Query4(interest));
                    break;

                // Запрос 5
                case 9:

                    // диапазон цены продажи
                    int lo = Utils.GetRand(5, 10) * 100, hi = lo + Utils.GetRand(2, 3) * 100;

                    // текст информации о запросе
                    string text5 = TbxQuery5.Text;

                    // вывод условий запроса
                    TbxQuery5.Text = text5.Remove(text5.LastIndexOf(':') + 2) + $"{lo} - {hi}";

                    UpdateBinding(DgvQuery5, _controller.Query5(lo, hi));
                    break;

                // Запрос 6
                case 10:

                    BdsData.DataSource = null;
                    BdsData.DataSource = _controller.Query6();
                    break;

                // Запрос 7
                case 11:

                    BdsData.DataSource = null;
                    BdsData.DataSource = _controller.Query7();

                    break;

                // Запрос 8
                case 12:

                    BdsData.DataSource = null;
                    BdsData.DataSource = _controller.Query8();

                    break;

                // Запрос 9
                case 13:

                    // диапазон даты продажи
                    DateTime dateLo = new DateTime(2021, Utils.GetRand(5, 13), Utils.GetRand(1, 28)),
                             //dateHi = new DateTime(dateLo.Year, dateLo.Month, dateLo.Day).AddMonths();
                             dateHi = dateLo.AddMonths(Utils.GetRand(3, 6));

                    // текст информации о запросе
                    string text9 = TbxQuery9.Text;

                    // вывод условий запроса
                    TbxQuery9.Text = text9.Remove(text9.LastIndexOf(':') + 2) + $"{dateLo:d} - {dateHi:d}";

                    BdsData.DataSource = null;
                    BdsData.DataSource = _controller.Query9(dateLo, dateHi);

                    break;

                // Запрос 10
                case 14:

                    BdsData.DataSource = null;
                    BdsData.DataSource = _controller.Query10();

                    break;

                default:
                    break;
            }
        }


        // обновление привязки DataGridView
        public void UpdateBinding(DataGridView view, object dataSource)
        {
            view.DataSource = null;
            view.DataSource = dataSource;
        }


        // добавление записи в таблицу
        private void Add_Command(object sender, EventArgs e)
        {
            switch (TbcMain.SelectedIndex)
            {
                // Содержание таблицы "Товары"
                case 1:
                    // форма для добавления
                    GoodsForm formGoods = new GoodsForm();

                    // запуск формы 
                    if (formGoods.ShowDialog() != DialogResult.OK)
                        return;

                    // добавление товара в коллекцию
                    _controller.Data.Goods.InsertOnSubmit(formGoods.GoodsModel);

                    // применение изменений в базе данных
                    _controller.Data.SubmitChanges();

                    UpdateBinding(DgvGoods, _controller.QueryGoods());
                    break;

                // Содержание таблицы "Закупки"
                case 3:

                    // форма для добавления
                    PurchaseForm formPurchase = new PurchaseForm(_controller.Data);

                    // запуск формы 
                    if (formPurchase.ShowDialog() != DialogResult.OK)
                        return;

                    // добавление товара в коллекцию
                    _controller.Data.Purchases.InsertOnSubmit(formPurchase.PurchaseModel);

                    // применение изменений в базе данных
                    _controller.Data.SubmitChanges();

                    UpdateBinding(DgvPurchases, _controller.QueryPurchases());
                    break;
            }
        }


        // редактирование записи в таблице
        private void Edit_Command(object sender, EventArgs e)
        {
            switch (TbcMain.SelectedIndex)
            {
                // Содержание таблицы "Товары"
                case 1:
                    // если элемент не выбран
                    if (DgvGoods.SelectedRows.Count == 0)
                        return;

                    // форма для редактирования
                    GoodsForm formGoods = new GoodsForm(_controller.Data.Goods.ToArray()[DgvGoods.SelectedRows[0].Index]);

                    // запуск формы 
                    if (formGoods.ShowDialog() != DialogResult.OK)
                        return;

                    // применение изменений в базе данных
                    _controller.Data.SubmitChanges();

                    UpdateBinding(DgvGoods, _controller.QueryGoods());
                    break;

                // Содержание таблицы "Закупки"
                case 3:
                    // если элемент не выбран
                    if (DgvPurchases.SelectedRows.Count == 0)
                        return;

                    // форма для редактирования
                    PurchaseForm formPurchase = new PurchaseForm(_controller.Data, _controller.Data.Purchases.ToArray()[DgvPurchases.SelectedRows[0].Index]);

                    // запуск формы 
                    if (formPurchase.ShowDialog() != DialogResult.OK)
                        return;

                    // применение изменений в базе данных
                    _controller.Data.SubmitChanges();

                    UpdateBinding(DgvPurchases, _controller.QueryPurchases());
                    break;
            }
        }


        #endregion

        #endregion

    }
}
