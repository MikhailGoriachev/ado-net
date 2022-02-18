using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Models.ViewModels
{
    // Класс Предаставление класса Sale
    public class SaleViewModel
    {
        // ID
        public int Id { get; set; }


        // дата продажи
        public DateTime DateSell { get; set; }


        // продавец
        public string Seller { get; set; }


        // закупленный товар
        public string Purchase { get; set; }


        // количество товара
        public int Amount { get; set; }


        // цена продажи единицы товара
        public int Price { get; set; }


        // единица измерения
        public string Unit { get; set; }


        #region Конструкторы


        // конструктор по умолчанию
        public SaleViewModel() { }


        // конструктор инициализирующий
        public SaleViewModel(Sale sale)
        {
            // установка значений
            Id       = sale.Id;
            DateSell = sale.DateSell;    
            Seller   = $"{sale.Seller.Surname} {sale.Seller.Name[0]}. {sale.Seller.Patronymic[0]}.";
            Purchase = sale.Purchase.Good.Name;    
            Amount   = sale.Amount;
            Unit     = sale.Unit.Long;
            Price    = sale.Price;
        }

        #endregion
    }
}
