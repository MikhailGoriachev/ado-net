using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Поля объекта класса Книга: 
 *      - идентификатор
 *      - идентификатор автора
 *      - название книги
 *      - год издания
 *      - цена
 */

namespace HomeWork.Models.Task1
{
    // Класс книга
    public class Book
    {
        // идентификатор
        private int _id;

        public int Id
        {
            get => _id; 
            set => _id = value; 
        }


        // идентификатор автора
        private int _idAuthor;

        public int IdAuthor
        {
            get => _idAuthor; 
            set => _idAuthor = value; 
        }


        // название книги
        private string _title;

        public string Title
        {
            get => _title; 
            set => _title = value; 
        }


        // год издания
        private int _year;

        public int Year
        {
            get => _year;
            set => _year = value; 
        }


        // цена
        private int _price;

        public int Price
        {
            get => _price; 
            set => _price = value; 
        }


        #region Методы

        // вывод шапки таблицы
        public void ShowHead()
        {

        } // ShowHead


        // вывод элемента
        public void ShowElem()
        {

        } // ShowElem


        // вывод подвала
        public void ShowFooter()
        {

        }

        #endregion
    }
}
