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
    // Класс Подписчик
    internal class Subscriber: IModelSqlData
    {
        // идентификатор
        public int Id { get; set; }

        // фамилия
        public string LastName { get; set; }

        // имя
        public string FirstName { get; set; }

        // отчество
        public string Patronymic { get; set; }

        // номер паспорта
        public string NumberPassport { get; set; }

        // улица
        public string Street { get; set; }

        // номер дома
        public string NumberHome { get; set; }

        // номер квартиры(0 - если нет квартиры)
        public string NumberApartment { get; set; }

        #region Конструкторы

        // конструктор по умолчанию
        public Subscriber() { }

        // конструктор инициализирующий значениями из SqlDataReader
        public Subscriber(SqlDataReader reader)
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
            Id              = reader.GetInt32(0);
            LastName        = reader.GetString(1);
            FirstName       = reader.GetString(2);
            Patronymic      = reader.GetString(3);
            NumberPassport  = reader.GetString(4);
            Street          = reader.GetString(5);
            NumberHome      = reader.GetString(6);
            NumberApartment = reader.GetString(7);

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
            //                  ID 2    LastName 15      FirstName 15    Patronymic 15   NumberPassport 15       Street 20  NumberHome 10 NumberApartment 10
            WriteColorXY("     ╔════╦═════════════════╦═════════════════╦═════════════════╦═════════════════╦══════════════════════╦════════════╦════════════╗\n", textColor: ConsoleColor.Magenta);
            WriteColorXY("     ║    ║                 ║                 ║                 ║                 ║                      ║            ║            ║", textColor: ConsoleColor.Magenta);
            WriteColorXY("ID",          7, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Фамилия",    12, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Имя",        30, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Отчество",   48, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Паспорт",    66, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Улица",      84, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Дом",       107, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Квартира",  120, textColor: ConsoleColor.DarkYellow);
            Console.WriteLine();

            WriteColorXY("     ╠════╬═════════════════╬═════════════════╬═════════════════╬═════════════════╬══════════════════════╬════════════╬════════════╣\n", textColor: ConsoleColor.Magenta);
        }


        // вывод записей таблицы
        public void ShowElem()
        {
            WriteColorXY("     ║    ║                 ║                 ║                 ║                 ║                      ║            ║            ║", textColor: ConsoleColor.Magenta);
            WriteColorXY($"{Id}",                 7, textColor: ConsoleColor.DarkGray);
            WriteColorXY($"{LastName}",          12, textColor: ConsoleColor.Green);
            WriteColorXY($"{FirstName}",         30, textColor: ConsoleColor.Green);
            WriteColorXY($"{Patronymic}",        48, textColor: ConsoleColor.Green);
            WriteColorXY($"{NumberPassport}",    66, textColor: ConsoleColor.DarkCyan);
            WriteColorXY($"{Street}",            84, textColor: ConsoleColor.DarkCyan);
            WriteColorXY($"{NumberHome}",       107, textColor: ConsoleColor.DarkCyan);
            WriteColorXY($"{NumberApartment}",  120, textColor: ConsoleColor.DarkCyan);
            Console.WriteLine();
        }


        // вывод подвала таблицы
        public static void ShowLine() =>
            WriteColorXY("     ╚════╩═════════════════╩═════════════════╩═════════════════╩═════════════════╩══════════════════════╩════════════╩════════════╝\n", textColor: ConsoleColor.Magenta);

        #endregion

    }
}
