using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HomeWork.Models.ViewModels
{
    // Класс Предаставление класса Purchase
    public class PurchaseViewModel
    {
        // ID
        public int Id { get; set; }

        // название товара
        public string Goods { get; set; }


        // единица измерения
        public string Unit { get; set; }


        // цена закупки
        public int Price { get; set; }


        // количество единиц товара
        public int Amount { get; set; }


        // дата закупки
        public DateTime DatePurchase { get; set; }


        #region Конструкторы


        // констркутор по умолчанию
        public PurchaseViewModel() { }


        // конструктор инициализирующий
        public PurchaseViewModel(Purchase purchase)
        {
            // установка значений
            Id           = purchase.Id;
            Goods        = purchase.Good.Name;
            Unit         = purchase.Unit.Long;
            Price        = purchase.Price;
            Amount       = purchase.Amount;
            DatePurchase = purchase.DatePurchase;
        }


        #endregion
    }
}
