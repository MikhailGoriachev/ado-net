using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Configuration;    

using static HomeWork.Application.App.Utils;       // для использования утилит

/*
 * Условия заданий
*/

namespace HomeWork.Application
{
    public partial class App
    {
        // строка для подключения к серверу для задания 1
        private string _connectionStringTask1;

        public string ConnectionStringTask1
        {
            get => _connectionStringTask1; 
            set => _connectionStringTask1 = value; 
        }

        // строка для подключения к серверу для задания 2
        private string _connectionStringTask2;

        public string ConnectionStringTask2
        {
            get => _connectionStringTask2; 
            set => _connectionStringTask2 = value; 
        }


        #region Конструкторы 

        // конструктор по умолчанию
        public App() : this(ConfigurationManager.ConnectionStrings["Transactions"].ConnectionString,
                            ConfigurationManager.ConnectionStrings["CarRental"].ConnectionString) { }

        // конструктор инициализирующий
        public App(string connectionStringTask1, string connectionStringTask2)
        {
            // установка значений
            _connectionStringTask1 = connectionStringTask1;
            _connectionStringTask2 = connectionStringTask2;
        }

        #endregion
    }
}
