using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;        // для работы с SQL
using System.Text;
using System.Threading.Tasks;

using static HomeWork.Application.App.Utils;        // утилиты

namespace HomeWork.Models.Task2
{
    // Класс Модель для вывода результата запроса 6 
    internal class ShowModelRentalsProc6
    {
        // reader для чтения с базы данных
        private SqlDataReader _dataReader;

        public SqlDataReader DataReader
        {
            get => _dataReader;
            set => _dataReader = value;
        }


        #region Консткруторы

        // конструктор по умолчанию
        public ShowModelRentalsProc6() : this(default) { }

        // конструктор инициализирующий
        public ShowModelRentalsProc6(SqlDataReader dataReader)
        {
            // установка значений
            _dataReader = dataReader;
        }

        #endregion

        #region Методы

        // вывод данных в виде таблицы 
        public void ShowData()
        {
            // вывод шапки таблицы
            ShowHead();

            // номер записи
            int n = 1;

            // вывод записей таблицы
            if (_dataReader.HasRows)
                while (_dataReader.Read())
                    ShowElem(n++);

            // вывод подвала таблицы
            ShowLine();
        }


        // вывод шапки таблицы
        public void ShowHead()
        {
            //                  Id 2 DateStart 10       Brand 20           Plate 10    Duration 10   Rental 10     Price 10
            WriteColorXY("     ╔════╦════════════╦══════════════════════╦════════════╦════════════╦════════════╦════════════╗\n",
                textColor: ConsoleColor.DarkMagenta);
            WriteColorXY("     ║    ║            ║                      ║            ║            ║            ║            ║",
                textColor: ConsoleColor.DarkMagenta);
            WriteColorXY(" N",               7, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Дата",            12, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Бренд-модель",    25, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Номер",           48, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Срок(дней)",      61, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Цена(день)",      74, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Стоимость",       87, textColor: ConsoleColor.DarkYellow);

            Console.WriteLine();

            WriteColorXY("     ╠════╬════════════╬══════════════════════╬════════════╬════════════╬════════════╬════════════╣\n",
                textColor: ConsoleColor.DarkMagenta);
        }

        // вывод строки таблицы 
        public void ShowElem(int n)
        {
            WriteColorXY("     ║    ║            ║                      ║            ║            ║            ║            ║",
                textColor: ConsoleColor.DarkMagenta);
            WriteColorXY($"{n,2}",                               7, textColor: ConsoleColor.DarkGray);
            WriteColorXY($"{_dataReader.GetDateTime(0),10:d}",  12, textColor: ConsoleColor.Green);
            WriteColorXY($"{_dataReader.GetString(1),-20}",     25, textColor: ConsoleColor.DarkCyan);
            WriteColorXY($"{_dataReader.GetString(2),10}",      48, textColor: ConsoleColor.DarkCyan);
            WriteColorXY($"{_dataReader.GetInt32(3),10}",       61, textColor: ConsoleColor.Green);
            WriteColorXY($"{_dataReader.GetInt32(4),10:n0}",    74, textColor: ConsoleColor.Green);
            WriteColorXY($"{_dataReader.GetInt32(5),10:n0}",    87, textColor: ConsoleColor.DarkCyan);
            Console.WriteLine();
        }

        // вывод подвала таблицы
        public void ShowLine() =>
            WriteColorXY("     ╚════╩════════════╩══════════════════════╩════════════╩════════════╩════════════╩════════════╝\n",
                textColor: ConsoleColor.DarkMagenta);

        #endregion
    }
}
