using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static HomeWork.Application.App;        // утилиты

namespace HomeWork.Models
{
    // Класс Расширяющие методы для класса Goods
    internal static class GoodsExtendedMethods
    {
        // расширяющий метод вычисляющий процент скидки в зависимости от возраста товара:
        // - до 3х лет скидка не представляется
        // - от 3х до 10 лет скидка 3%
        // - свыше 10 лет – скидка 7%
        public static int PercentDiscount(this Goods goods)
        {
            // возраст товара
            int diff = DateTime.Now.Year - goods.Year;

            // до 3х лет скидка не представляется
            if (diff < 3)
                return 0;
            // от 3х до 10 лет скидка 3 %
            else if (diff < 10)
                return 3;
            // свыше 10 лет – скидка 7 %
            else 
                return 7;
        }


        // инициализация коллекции
        public static List<Goods> Initialization(this List<Goods> goods, int n)
        {
            // очистка списка
            goods.Clear();

            // инциализация коллекции
            for (int i = 0; i < n; i++)
                goods.Add(Utils.GetGoods());

            return goods;
        }

    }
}
