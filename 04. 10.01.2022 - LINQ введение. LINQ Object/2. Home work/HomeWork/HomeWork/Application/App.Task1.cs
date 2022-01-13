using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HomeWork.Models;      // модели

using static HomeWork.Application.App.Utils;       // для использования утилит

namespace HomeWork.Application
{
    public partial class App
    {
        #region Задание 1. Скидка на товары

        /*
        * •	Задача 1. Для класса, представляющего товар (наименование, цена, количество,
        *      год выпуска) разработать расширяющий метод, возвращающий процент скидки в 
        *      зависимости от возраста товара – до 3х лет скидка не представляется, от 3х до 
        *      10 лет скидка 3%, свыше 10 лет – скидка 7%. Продемонстрировать работу метода 
        *      на коллекции из 12 товаров.
        */

        // Задание 1. Скидка на товары
        public void Task1()
        {
            ShowNavBarMessage("Задание 1. Скидка на товары");

            // товары
            List<Goods> goods = new List<Goods>().Initialization(12);

            // вывод элементов с вычислением скидки

            // вывод шапки таблицы
            Goods.ShowHeadDisount();

            // номер записи
            int n = 1;

            // вывод записей 
            goods.ForEach(x => x.ShowElemDisount(n++, x.PercentDiscount()));

            // вывод подвала таблицы
            Goods.ShowFooterDisount();

            // ввод клавиши для продолжения 
            WriteColor("\n\n\tНажмите на [Enter] для продолжения...", ConsoleColor.Cyan);
            Console.CursorVisible = false;
            while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
            Console.CursorVisible = true;
        }

        #endregion

    }
}
