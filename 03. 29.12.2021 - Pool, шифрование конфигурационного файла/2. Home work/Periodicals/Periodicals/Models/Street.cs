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
    // Класс Улица
    internal class Street: IModelSqlData
    {
        // идентификатор
        public int Id { get; set; }

        // название название улицы
        public string Title { get; set; }

        #region Конструкторы

        // конструктор по умолчанию
        public Street() { }

        // конструктор инициализирующий значениями из SqlDataReader
        public Street(SqlDataReader reader)
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
            Id      = reader.GetInt32(0);
            Title   = reader.GetString(1);

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
            //                  ID 2 IndexEdition 10  TypeEdition 15      Title 20        Price 10     
            WriteColorXY("     ╔════╦══════════════════════╗\n", textColor: ConsoleColor.Magenta);
            WriteColorXY("     ║    ║                      ║", textColor: ConsoleColor.Magenta);
            WriteColorXY("ID", 7, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Название улицы", 12, textColor: ConsoleColor.DarkYellow);
            Console.WriteLine();

            WriteColorXY("     ╠════╬══════════════════════╣\n", textColor: ConsoleColor.Magenta);
        }


        // вывод записей таблицы
        public void ShowElem()
        {
            WriteColorXY("     ║    ║                      ║", textColor: ConsoleColor.Magenta);
            WriteColorXY($"{Id}", 7, textColor: ConsoleColor.DarkGray);
            WriteColorXY($"{Title}", 12, textColor: ConsoleColor.Green);
            Console.WriteLine();
        }


        // вывод подвала таблицы
        public static void ShowLine() =>
            WriteColorXY("     ╚════╩══════════════════════╝\n", textColor: ConsoleColor.Magenta);

        #endregion

    }
}
