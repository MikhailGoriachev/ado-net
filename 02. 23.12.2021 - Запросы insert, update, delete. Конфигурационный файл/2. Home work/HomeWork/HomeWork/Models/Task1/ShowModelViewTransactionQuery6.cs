using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;        // для работы с SQL
using System.Text;
using System.Threading.Tasks;

using static HomeWork.Application.App.Utils;        // утилиты

namespace HomeWork.Models.Task1
{
    // Класс Модель для вывода результата запроса 6
    internal class ShowModelViewTransactionQuery6
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
        public ShowModelViewTransactionQuery6() : this(default) { }

        // конструктор инициализирующий
        public ShowModelViewTransactionQuery6(SqlDataReader dataReader)
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
            //                  Id 2           LastName 20        FirstName 20      Patronymic 20             DateTrans 15      Price 15       Percent 10    Commisions 15  
            WriteColorXY("     ╔════╦══════════════════════╦══════════════════════╦══════════════════════╦═════════════════╦═════════════════╦════════════╦═════════════════╗\n",
                textColor:ConsoleColor.DarkMagenta);
            WriteColorXY("     ║    ║                      ║                      ║                      ║                 ║                 ║            ║                 ║",
                textColor: ConsoleColor.DarkMagenta);
            WriteColorXY("ID",                  7,      textColor:ConsoleColor.DarkYellow);
            WriteColorXY("Фамилия",             12,     textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Имя",                 35,     textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Отчество",            58,     textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Дата",                81,     textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Стоимость ",          99,     textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Процент",             117,    textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Комиссионные",        130,    textColor: ConsoleColor.DarkYellow);
            Console.WriteLine();

            WriteColorXY("     ╠════╬══════════════════════╬══════════════════════╬══════════════════════╬═════════════════╬═════════════════╬════════════╬═════════════════╣\n",
                textColor: ConsoleColor.DarkMagenta);
        }

        // вывод строки таблицы 
        public void ShowElem()
        {
            WriteColorXY("     ║    ║                      ║                      ║                      ║                 ║                 ║            ║                 ║",
                textColor: ConsoleColor.DarkMagenta);
            WriteColorXY($"{_dataReader.GetInt32(0),2}",        7,          textColor: ConsoleColor.DarkGray);
            WriteColorXY($"{_dataReader.GetString(1),-20}",     12,         textColor: ConsoleColor.DarkCyan);
            WriteColorXY($"{_dataReader.GetString(2),-20}",     35,         textColor: ConsoleColor.Green);
            WriteColorXY($"{_dataReader.GetString(3),-20}",     58,         textColor: ConsoleColor.DarkCyan);
            WriteColorXY($"{_dataReader.GetDateTime(4),15:d}",  81,         textColor: ConsoleColor.Green);
            WriteColorXY($"{_dataReader.GetInt32(5),15:n0}",    99,         textColor: ConsoleColor.DarkCyan);
            WriteColorXY($"{_dataReader.GetDouble(6),10:n2}",   117,        textColor: ConsoleColor.Green);
            WriteColorXY($"{_dataReader.GetDouble(7),15:n2}",   130,        textColor: ConsoleColor.Green);
            Console.WriteLine();
        }

        // вывод подвала таблицы
        public void ShowLine() =>
            WriteColorXY("     ╚════╩══════════════════════╩══════════════════════╩══════════════════════╩═════════════════╩═════════════════╩════════════╩═════════════════╝\n",
                textColor: ConsoleColor.DarkMagenta);


        #endregion

    }
}
