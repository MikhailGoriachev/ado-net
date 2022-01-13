using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;        // для работы с SQL
using System.Text;
using System.Threading.Tasks;

using static HomeWork.Application.App.Utils;        // утилиты

namespace HomeWork.Models
{
    // Класс Моедль для вывода представления таблицы Immovables   (Недвижимость)
    internal class ShowModelViewImmovables
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
        public ShowModelViewImmovables() : this(default) { }

        // конструктор инициализирующий
        public ShowModelViewImmovables(SqlDataReader dataReader)
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
            //                  Id 2      Street 20      HomeNumber 10 ApartmentNumber 10 AmountRooms 10  Area 10     Price 15     
            WriteColorXY("     ╔════╦══════════════════════╦════════════╦════════════╦════════════╦════════════╦═════════════════╗\n",
                textColor: ConsoleColor.DarkMagenta);
            WriteColorXY("     ║    ║                      ║            ║            ║            ║            ║                 ║",
                textColor: ConsoleColor.DarkMagenta);
            WriteColorXY("ID",          7, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Улица",       12, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Дом",         35, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Квартира",    48, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Комнаты",     61, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Площадь",     74, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Цена",        87, textColor: ConsoleColor.DarkYellow);

            Console.WriteLine();

            WriteColorXY("     ╠════╬══════════════════════╬════════════╬════════════╬════════════╬════════════╬═════════════════╣\n",
                textColor: ConsoleColor.DarkMagenta);
        }

        // вывод строки таблицы 
        public void ShowElem()
        {
            WriteColorXY("     ║    ║                      ║            ║            ║            ║            ║                 ║",
                textColor: ConsoleColor.DarkMagenta);
            WriteColorXY($"{_dataReader.GetInt32(0),2}",        7, textColor: ConsoleColor.DarkGray);
            WriteColorXY($"{_dataReader.GetString(1),-20}",     12, textColor: ConsoleColor.DarkCyan);
            WriteColorXY($"{_dataReader.GetString(2),10}",      35, textColor: ConsoleColor.DarkCyan);
            WriteColorXY($"{_dataReader.GetString(3),10}",      48, textColor: ConsoleColor.DarkCyan);
            WriteColorXY($"{_dataReader.GetInt32(4),10}",       61, textColor: ConsoleColor.Green);
            WriteColorXY($"{_dataReader.GetDouble(5),10:n2}",   74, textColor: ConsoleColor.Green);
            WriteColorXY($"{_dataReader.GetInt32(6),15:n0}",    87, textColor: ConsoleColor.Green);
            Console.WriteLine();
        }

        // вывод подвала таблицы
        public void ShowLine() =>
            WriteColorXY("     ╚════╩══════════════════════╩════════════╩════════════╩════════════╩════════════╩═════════════════╝\n",
                textColor: ConsoleColor.DarkMagenta);

        #endregion

    }
}