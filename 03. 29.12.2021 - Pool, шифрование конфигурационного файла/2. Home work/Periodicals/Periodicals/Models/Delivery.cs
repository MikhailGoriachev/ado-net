using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Periodicals.Interfaces;   // интерфейсы

using static Periodicals.Application.App.Utils;     // утилиты

namespace Periodicals.Models
{
    // Класс Доставка
    internal class Delivery : IModelSqlData
    {
        // идентификатор
        public int Id { get; set; }

        // фамилия и инициалы подписчика
        public string FullName { get; set; }

        // номер паспорта подписчика
        public string NumberPassport { get; set; }

        // адресс подписчика
        public string Address { get; set; }

        // индекс издания
        public string IndexEdition { get; set; }

        // название издания
        public string Title { get; set; }

        // цена издания
        public int Price { get; set; }

        // дата начала подписки
        public DateTime DateStartSubscribe { get; set; }

        // количество месяцев подписки
        public int SubscribePeriodMonths { get; set; }

        #region Конструкторы

        // конструктор по умолчанию
        public Delivery() { }

        // конструктор инициализирующий значениями из SqlDataReader
        public Delivery(SqlDataReader reader)
        {
            // установка значений
            SetValuesSqlDataReader(reader);
        }

        #endregion

        #region Методы

        // установка значений из SqlDataReader
        public IModelSqlData SetValuesSqlDataReader(SqlDataReader reader)
        {
            // установка значений
            Id                      = reader.GetInt32(0); 
            FullName                = reader.GetString(1);
            NumberPassport          = reader.GetString(2); 
            Address                 = reader.GetString(3);
            IndexEdition            = reader.GetString(4);   
            Title                   = reader.GetString(5);
            Price                   = reader.GetInt32(6);
            DateStartSubscribe      = reader.GetDateTime(7);
            SubscribePeriodMonths   = reader.GetInt32(8);

            return this;
        }


        // вывод данных в виде таблицы 
        public static void ShowTable(List<IModelSqlData> types)
        {
            // вывод шапки таблицы
            ShowHead();

            // вывод записей таблицы
            types.ForEach(item => item.ShowElem());

            // вывод подвала таблицы
            ShowLine();
        }


        // вывод шапки таблицы
        public static void ShowHead()
        {
            //                  ID 2    FullName 20      NumberPassport 15    Address 20      IndexEdition 10       Title 30                Price 10 DateStartSubscribe 10 SubscribePeriodMonths 10
            WriteColorXY("  ╔════╦══════════════════════╦═════════════════╦══════════════════════╦════════════╦════════════════════════════════╦════════════╦════════════╦════════════╗\n", textColor: ConsoleColor.Magenta);
            WriteColorXY("  ║    ║                      ║                 ║                      ║            ║                                ║            ║            ║            ║", textColor: ConsoleColor.Magenta);
            WriteColorXY("ID",                  4, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("ФИО подписчика",      9, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Паспорт",            32, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Адрес",              50, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Индекс",             73, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Название издания",   86, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Цена",              119, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("   Дата   ",        132, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("   Срок   ",        145, textColor: ConsoleColor.DarkYellow);
            Console.WriteLine();

            WriteColorXY("  ║    ║                      ║                 ║                      ║            ║                                ║            ║            ║            ║", textColor: ConsoleColor.Magenta);
            WriteColorXY(" подписки ", 132, textColor: ConsoleColor.DarkYellow);
            WriteColorXY(" подписки ", 145, textColor: ConsoleColor.DarkYellow);
            Console.WriteLine();

            WriteColorXY("  ╠════╬══════════════════════╬═════════════════╬══════════════════════╬════════════╬════════════════════════════════╬════════════╬════════════╬════════════╣\n", textColor: ConsoleColor.Magenta);
        }


        // вывод записей таблицы
        public void ShowElem()
        {
            WriteColorXY("  ║    ║                      ║                 ║                      ║            ║                                ║            ║            ║            ║", textColor: ConsoleColor.Magenta);
            WriteColorXY($"{Id}",                       4, textColor: ConsoleColor.DarkGray);
            WriteColorXY(FullName,                      9, textColor: ConsoleColor.Green);
            WriteColorXY(NumberPassport,               32, textColor: ConsoleColor.DarkCyan);
            WriteColorXY(Address,                      50, textColor: ConsoleColor.Green);
            WriteColorXY(IndexEdition,                 73, textColor: ConsoleColor.DarkCyan);
            WriteColorXY(Title,                        86, textColor: ConsoleColor.Green);
            WriteColorXY($"{Price:n0}",               119, textColor: ConsoleColor.DarkCyan);
            WriteColorXY($"{DateStartSubscribe:d}",   132, textColor: ConsoleColor.DarkCyan);
            WriteColorXY($"{SubscribePeriodMonths}",  145, textColor: ConsoleColor.DarkCyan);
            Console.WriteLine();

        }


        // вывод подвала таблицы
        public static void ShowLine() =>
            WriteColorXY("  ╚════╩══════════════════════╩═════════════════╩══════════════════════╩════════════╩════════════════════════════════╩════════════╩════════════╩════════════╝\n", textColor: ConsoleColor.Magenta);

        #endregion

    }
}
