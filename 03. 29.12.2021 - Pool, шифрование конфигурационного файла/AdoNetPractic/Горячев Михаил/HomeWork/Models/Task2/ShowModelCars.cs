using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;        // для работы с SQL
using System.Text;
using System.Threading.Tasks;

using static HomeWork.Application.App.Utils;        // утилиты

namespace HomeWork.Models.Task2
{
    // Класс Модель для вывода представления таблицы Cars		(Машины)
    internal class ShowModelCars
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
        public ShowModelCars() : this(default) { }

        // конструктор инициализирующий
        public ShowModelCars(SqlDataReader dataReader)
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
            //                  Id 2        Brand 20              Color 20          Plate 10  YearManuf 10  UnshurancePay 10  Rental 10     
            WriteColorXY("     ╔════╦══════════════════════╦══════════════════════╦════════════╦════════════╦════════════╦════════════╗\n",
                textColor:ConsoleColor.DarkMagenta);
            WriteColorXY("     ║    ║                      ║                      ║            ║            ║            ║            ║",
                textColor: ConsoleColor.DarkMagenta);
            WriteColorXY("ID",                      7,     textColor:ConsoleColor.DarkYellow);
            WriteColorXY("Бренд-модель",           12,     textColor:ConsoleColor.DarkYellow);
            WriteColorXY("Цвет",                   35,     textColor:ConsoleColor.DarkYellow);
            WriteColorXY("Номер",                  58,     textColor:ConsoleColor.DarkYellow);
            WriteColorXY("Год выпус.",             71,     textColor:ConsoleColor.DarkYellow);
            WriteColorXY("Страховка",              84,     textColor:ConsoleColor.DarkYellow);
            WriteColorXY("Цена(день)",             97,     textColor:ConsoleColor.DarkYellow);

            Console.WriteLine();

            WriteColorXY("     ╠════╬══════════════════════╬══════════════════════╬════════════╬════════════╬════════════╬════════════╣\n",
                textColor: ConsoleColor.DarkMagenta);
        }

        // вывод строки таблицы 
        public void ShowElem()
        {
            WriteColorXY("     ║    ║                      ║                      ║            ║            ║            ║            ║",
                textColor: ConsoleColor.DarkMagenta);
            WriteColorXY($"{_dataReader.GetInt32(0),2}",         7,         textColor: ConsoleColor.DarkGray);
            WriteColorXY($"{_dataReader.GetString(1),-20}",     12,         textColor: ConsoleColor.Green);
            WriteColorXY($"{_dataReader.GetString(2),-20}",     35,         textColor: ConsoleColor.Green);
            WriteColorXY($"{_dataReader.GetString(3),-10}",     58,         textColor: ConsoleColor.DarkCyan);
            WriteColorXY($"{_dataReader.GetInt32(4),10}",       71,         textColor: ConsoleColor.DarkCyan);
            WriteColorXY($"{_dataReader.GetInt32(5),10:n0}",    84,         textColor: ConsoleColor.DarkCyan);
            WriteColorXY($"{_dataReader.GetInt32(6),10:n0}",    97,         textColor: ConsoleColor.DarkCyan);
            Console.WriteLine();
        }

        // вывод подвала таблицы
        public void ShowLine() =>
            WriteColorXY("     ╚════╩══════════════════════╩══════════════════════╩════════════╩════════════╩════════════╩════════════╝\n",
                textColor: ConsoleColor.DarkMagenta);


        #endregion

    }
}
