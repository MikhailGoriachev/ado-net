using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static HomeWork.Application.App.Utils;        // утилиты

namespace HomeWork.Models.Task1
{
    // Класс Представление книги с расшифрованными полями для вывода
    public class BookViewModel
    {
        // идентификатор
        public int Id { get; set; }

        // название книги
        public string Title { get; set; }

        // год издания
        public int Year { get; set; }

        // автор
        public string AuthorName { get; set; }

        // год рождения автора
        public int AuthorYear { get; set; }

        // цена
        public int Price { get; set; }


        #region Методы


        // вывод заголовка таблицы 
        static public void ShowHeadBooks()
        {
            //                  Id 2              Title 30             Year 4       AuthorName 20   AuthorYear 10   Price 10
            WriteColorXY("     ╔════╦════════════════════════════════╦══════╦══════════════════════╦════════════╦════════════╗\n", textColor: ConsoleColor.Magenta);
            WriteColorXY("     ║    ║                                ║      ║                      ║            ║            ║", textColor: ConsoleColor.Magenta);
            WriteColorXY("ID",               7, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Название книги",  12, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Год",             45, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Автор",           52, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Год рожден.",     75, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Цена",            88, textColor: ConsoleColor.DarkYellow);
            Console.WriteLine();

            WriteColorXY("     ╠════╬════════════════════════════════╬══════╬══════════════════════╬════════════╬════════════╣\n", textColor: ConsoleColor.Magenta);

        } // ShowHeadBooks


        // вывод элемента таблицы вывода книг с расшифровкой полей
        public void ShowElem()
        {
            WriteColorXY("     ║    ║                                ║      ║                      ║            ║            ║", textColor: ConsoleColor.Magenta);
            WriteColorXY($"{Id, 2}",         7, textColor: ConsoleColor.DarkGray);
            WriteColorXY($"{Title}",        12, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{Year}",         45, textColor: ConsoleColor.Green);
            WriteColorXY($"{AuthorName}",   52, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{AuthorYear}",   78, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{Price, 10:n0}", 88, textColor: ConsoleColor.Green);
            Console.WriteLine();
        } // ShowElementsBooks


        // вывод элемента таблицы вывода книг с расшифровкой полей
        static public void ShowFooterBooks() =>
            WriteColorXY("     ╚════╩════════════════════════════════╩══════╩══════════════════════╩════════════╩════════════╝\n", textColor: ConsoleColor.Magenta);


        #endregion
    }
}
