using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeWork.Utilities
{
    // Утилиты
    public class Utils
    {
        #region Утилиты

        public static Random rand = new Random();


        // генерация вещественного числа (min, max]
        public static double GetRand(double min, double max)
        {
            // если диапазон не корректен
            if (min.CompareTo(max) > 0 || max.CompareTo(min) < 0)
                throw new Exception("Utils.GetRand(double min, double max): минимум не может быть больше максимума");

            // число
            double num;

            // генерация числа
            do
            {
                num = rand.Next((int)min, (int)max - 1) + rand.NextDouble();
            } while (num.CompareTo(min) < 0 || num.CompareTo(max) > 0);

            return num;
        }


        // генерация целого числа (min, max]
        public static int GetRand(int min, int max)
        {
            // если диапазон не корректен
            if (min.CompareTo(max) > 0 || max.CompareTo(min) < 0)
                throw new Exception("Utils.GetRand(int min, int max): минимум не может быть больше максимума");

            return rand.Next(min, max);
        }


        // получение подстроки для поиска 
        public static string GetSubstringTitle()
        {
            string[] str = new[] { "гос", "во", "нов"};

            return str[rand.Next(0, str.Length)];
        }


        // получение наименования товара
        public static string GetNameGoods()
        {
            string[] goods = new[] { "Чай Lipton", "Чай Grenfield", "Обои Синтра", "Обои Grandeco", "Тетардь Interdruk", "Сахар" };

            return goods[rand.Next(0, goods.Length)];
        }


        // получение процента продавца
        public static double GetInterestSeller()
        {
            double[] interest = new[] { 8d, 12d, 5d, 7d, 4d };

            return interest[rand.Next(0, interest.Length)];
        }

        #endregion
    }
}