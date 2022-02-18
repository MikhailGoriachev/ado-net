using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using HomeWork.Models;      // модели

namespace HomeWork.Views
{
    // Форма добавление/редактирование закупки
    public partial class PurchaseForm : Form
    {
        // модель для работы
        private Purchase _purchaseModel;

        public Purchase PurchaseModel
        {
            get => _purchaseModel;
            set => _purchaseModel = value;
        }


        // модель базы данных
        public SalesAccountingDataContext Data { get; set; }


        #region Конструкторы

        // конструктор для запуска формы в режиме создания
        public PurchaseForm(SalesAccountingDataContext data) 
        {
            InitializeComponent();

            // установка ссылки на объект модели базы данных
            Data = data;

            // создание объекта
            _purchaseModel = new Purchase
            {
                Good = data.Goods.ToArray()[0],
                Unit = data.Units.ToArray()[0],
                DatePurchase = DateTime.Now,
                Price = 1000,
                Amount = 16
            };

            // заполнение ComboBox
            SetComboBoxesValues();

            // установка значений из модели в поля
            SetValueFields();
        }


        // конструктор для запуска формы в режиме редактирования
        public PurchaseForm(SalesAccountingDataContext data, Purchase purchase)
        {
            InitializeComponent();

            // установка ссылки на объект модели базы данных
            Data = data;

            // установка ссылки на редактируемый объект
            _purchaseModel = purchase;

            // заполнение ComboBox
            SetComboBoxesValues();

            // установка значений из модели в поля
            SetValueFields();

            // установка текста заголовков
            Text = LblHeader.Text = "Редактирование закупки";

            // установка текта на кнопке
            BtnOk.Text = "Сохранить";
        }

        #endregion

        #region Методы

        // установка значений из модели в поля
        public void SetValueFields()
        {
            TbxDate.Text = $"{_purchaseModel.DatePurchase:d}";
            CmbGoods.SelectedItem = _purchaseModel.Good.Name;
            CmbUnits.SelectedItem = _purchaseModel.Unit.Long;
            NudAmount.Value = _purchaseModel.Amount;
            NudPrice.Value = _purchaseModel.Price;
        }

        // установка значений для комбо-боксов
        public void SetComboBoxesValues()
        {
            CmbGoods.Items.AddRange(Data.Goods.Select(g => g.Name).ToArray());
            CmbUnits.Items.AddRange(Data.Units.Select(u => u.Long).ToArray());
        }

        #endregion

        // применение изменений
        private void BtnOk_Click(object sender, EventArgs e)
        {
            _purchaseModel.Good   = Data.Goods.Where(g => g.Name == CmbGoods.Text).ToArray()[0];
            _purchaseModel.Unit   = Data.Units.Where(u => u.Long == CmbUnits.Text).ToArray()[0];
            _purchaseModel.Price  = (int)NudPrice.Value;
            _purchaseModel.Amount = (int)NudAmount.Value;
            _purchaseModel.DatePurchase = DateTime.Parse(TbxDate.Text);
        }
    }
}
