using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;        // для работы с SQL
using System.Text;
using System.Threading.Tasks;

using static HomeWork.Application.App.Utils;        // утилиты

namespace HomeWork.Models.Task1
{
    // Класс Модель для вывода представления таблицы Transactions (Сделки)
    internal class ShowModelViewTransaction
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
        public ShowModelViewTransaction() : this(default) { }

        // конструктор инициализирующий
        public ShowModelViewTransaction(SqlDataReader dataReader)
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
            //                  Id 2             Address 30              Price 15               Realtor 20      Percent 10         Owner 20         Passport 15     DateTrans 10
            WriteColorXY("     ╔════╦════════════════════════════════╦═════════════════╦══════════════════════╦════════════╦══════════════════════╦═════════════════╦════════════╗\n",
                textColor:ConsoleColor.DarkMagenta);
            WriteColorXY("     ║    ║                                ║                 ║                      ║            ║                      ║                 ║            ║",
                textColor: ConsoleColor.DarkMagenta);
            WriteColorXY("ID",                  7,      textColor:ConsoleColor.DarkYellow);
            WriteColorXY("Адрес квартиры",      12,     textColor:ConsoleColor.DarkYellow);
            WriteColorXY("Стоимость ",          45,     textColor:ConsoleColor.DarkYellow);
            WriteColorXY("Риэлтор",             63,     textColor:ConsoleColor.DarkYellow);
            WriteColorXY("Процент",             86,     textColor:ConsoleColor.DarkYellow);
            WriteColorXY("Владелец квартиры",   99,     textColor:ConsoleColor.DarkYellow);
            WriteColorXY("Пасспорт",            122,    textColor:ConsoleColor.DarkYellow);
            WriteColorXY("Дата",                140,    textColor:ConsoleColor.DarkYellow);

            Console.WriteLine();

            WriteColorXY("     ╠════╬════════════════════════════════╬═════════════════╬══════════════════════╬════════════╬══════════════════════╬═════════════════╬════════════╣\n",
                textColor: ConsoleColor.DarkMagenta);
        }

        // вывод строки таблицы 
        public void ShowElem()
        {
            WriteColorXY("     ║    ║                                ║                 ║                      ║            ║                      ║                 ║            ║",
                textColor: ConsoleColor.DarkMagenta);
            WriteColorXY($"{_dataReader.GetInt32(0),2}",        7,          textColor: ConsoleColor.DarkGray);
            WriteColorXY($"{_dataReader.GetString(1),-30}",     12,         textColor: ConsoleColor.DarkCyan);
            WriteColorXY($"{_dataReader.GetInt32(2),15:n0}",    45,         textColor: ConsoleColor.Green);
            WriteColorXY($"{_dataReader.GetString(3),-20}",     63,         textColor: ConsoleColor.DarkCyan);
            WriteColorXY($"{_dataReader.GetDouble(4),10:n2}",   86,         textColor: ConsoleColor.Green);
            WriteColorXY($"{_dataReader.GetString(5),-20}",     99,         textColor: ConsoleColor.DarkCyan);
            WriteColorXY($"{_dataReader.GetString(6),-15}",     122,        textColor: ConsoleColor.Green);
            WriteColorXY($"{_dataReader.GetDateTime(7),10:d}",  140,        textColor: ConsoleColor.Green);
            Console.WriteLine();
        }

        // вывод подвала таблицы
        public void ShowLine() =>
            WriteColorXY("     ╚════╩════════════════════════════════╩═════════════════╩══════════════════════╩════════════╩══════════════════════╩═════════════════╩════════════╝\n",
                textColor: ConsoleColor.DarkMagenta);


        #endregion

    }
}
