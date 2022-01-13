using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;        // для работы с SQL
using System.Text;
using System.Threading.Tasks;

using static HomeWork.Application.App.Utils;        // утилиты

namespace HomeWork.Models
{
    // Класс Модель для вывода таблицы Streets      (Улицы)
    internal class ShowModelStreetsQuery8And9
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
        public ShowModelStreetsQuery8And9() : this(default) { }

        // конструктор инициализирующий
        public ShowModelStreetsQuery8And9(SqlDataReader dataReader)
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

            // вывод записей таблицы
            if (_dataReader.HasRows)
                while (_dataReader.Read())
                    ShowElem();

            // вывод подвала таблицы
            ShowLine();
        }


        // вывод шапки таблицы
        public void ShowHead()
        {
            //                  Id 2      Street 20      CountTransactions 15 SumTransactions 15
            WriteColorXY("     ╔════╦══════════════════════╦═════════════════╦═════════════════╗\n",
                textColor: ConsoleColor.DarkMagenta);
            WriteColorXY("     ║    ║                      ║                 ║                 ║",
                textColor: ConsoleColor.DarkMagenta);
            WriteColorXY("ID",              7, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Улица",           12, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Количество",      35, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Сумма сделок",    53, textColor: ConsoleColor.DarkYellow);

            Console.WriteLine();

            WriteColorXY("     ╠════╬══════════════════════╬═════════════════╬═════════════════╣\n",
                textColor: ConsoleColor.DarkMagenta);
        }

        // вывод строки таблицы 
        public void ShowElem()
        {
            WriteColorXY("     ║    ║                      ║                 ║                 ║",
                textColor: ConsoleColor.DarkMagenta);
            WriteColorXY($"{_dataReader.GetInt32(0),2}",        7, textColor: ConsoleColor.DarkGray);
            WriteColorXY($"{_dataReader.GetString(1),-20}",     12, textColor: ConsoleColor.DarkCyan);
            WriteColorXY($"{_dataReader.GetInt32(2),15}",      35, textColor: ConsoleColor.Green);
            WriteColorXY($"{_dataReader.GetInt32(3),15:n0}",   53, textColor: ConsoleColor.Green);
            Console.WriteLine();
        }

        // вывод подвала таблицы
        public void ShowLine() =>
            WriteColorXY("     ╚════╩══════════════════════╩═════════════════╩═════════════════╝\n",
                textColor: ConsoleColor.DarkMagenta);

        #endregion

    }
}
