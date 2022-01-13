using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;        // для работы с SQL
using System.Text;
using System.Threading.Tasks;

using static HomeWork.Application.App.Utils;        // утилиты

namespace HomeWork.Models.Task2
{
    // Класс Модель для вывода результата запроса 8 
    internal class ShowModelProc8
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
        public ShowModelProc8() : this(default) { }

        // конструктор инициализирующий
        public ShowModelProc8(SqlDataReader dataReader)
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
            //                  Id 2        Brand 20         Plate 10                   Amount 10  SumPrice 10  SumDuration 10     
            WriteColorXY("     ╔════╦══════════════════════╦════════════╦════════════╦════════════╦════════════╦════════════╗\n",
                textColor: ConsoleColor.DarkMagenta);
            WriteColorXY("     ║    ║                      ║            ║            ║            ║            ║            ║",
                textColor: ConsoleColor.DarkMagenta);
            WriteColorXY("ID",               7, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Бренд-модель",    12, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Номер",           35, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Цена(день)",      48, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Прокаты",         61, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Стоимость",       74, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Длитель.",        87, textColor: ConsoleColor.DarkYellow);

            Console.WriteLine();

            WriteColorXY("     ╠════╬══════════════════════╬════════════╬════════════╬════════════╬════════════╬════════════╣\n",
                textColor: ConsoleColor.DarkMagenta);
        }


        // вывод строки таблицы 
        public void ShowElem()
        {
            WriteColorXY("     ║    ║                      ║            ║            ║            ║            ║            ║",
                textColor: ConsoleColor.DarkMagenta);
            WriteColorXY($"{_dataReader.GetInt32(0),2}",         7, textColor: ConsoleColor.DarkGray);
            WriteColorXY($"{_dataReader.GetString(1),-20}",     12, textColor: ConsoleColor.Green);
            WriteColorXY($"{_dataReader.GetString(2),-10}",     35, textColor: ConsoleColor.Green);
            WriteColorXY($"{_dataReader.GetInt32(3),10:n0}",    48, textColor: ConsoleColor.DarkCyan);
            WriteColorXY($"{_dataReader.GetInt32(4),10}",       61, textColor: ConsoleColor.DarkCyan);
            WriteColorXY($"{_dataReader.GetInt32(5),10:n0}",    74, textColor: ConsoleColor.DarkCyan);
            WriteColorXY($"{_dataReader.GetInt32(6),10:n0}",    87, textColor: ConsoleColor.DarkCyan);
            Console.WriteLine();
        }


        // вывод подвала таблицы
        public void ShowLine() =>
            WriteColorXY("     ╚════╩══════════════════════╩════════════╩════════════╩════════════╩════════════╩════════════╝\n",
                textColor: ConsoleColor.DarkMagenta);


        #endregion
    }
}
