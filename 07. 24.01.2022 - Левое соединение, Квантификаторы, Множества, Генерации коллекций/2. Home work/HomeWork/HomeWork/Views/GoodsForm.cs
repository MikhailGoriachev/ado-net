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
    public partial class GoodsForm : Form
    {
        // модель для работы
        private Good _goodsModel;

        public Good GoodsModel
        {
            get => _goodsModel;
            set => _goodsModel = value;
        }


        // модель базы данных
        public SalesAccountingDataContext Data { get; set; }


        #region Конструкторы

        // конструктор для запуска формы в режиме создания
        public GoodsForm()
        {
            InitializeComponent();

            // создание объекта
            _goodsModel = new Good();

            // установка значений из модели в поля
            SetValueFields();
        }


        // конструктор для запуска формы в режиме редактирования
        public GoodsForm(Good goods)
        {
            InitializeComponent();

            // установка ссылки на редактируемый объект
            _goodsModel = goods;

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
        public void SetValueFields() => TbxTitle.Text = _goodsModel.Name;


        // обработка изменения текста в поле ввода
        private void TbxTitle_TextChanged(object sender, EventArgs e) => BtnOk.Enabled = !string.IsNullOrWhiteSpace(TbxTitle.Text);


        // добавление/применение изменений
        private void BtnOk_Click(object sender, EventArgs e)
        {
            _goodsModel.Name = TbxTitle.Text;
        }

        #endregion


    }
}
