using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using static HomeWork.Application.App.Utils;       // для использования утилит

/*
 * Условия заданий
*/

namespace HomeWork.Application
{
    public partial class App
    {
        // строка для подключения к серверу
        private string _connectionString;

        public string ConnectionString
        {
            get => _connectionString; 
            set => _connectionString = value; 
        }


        #region Конструкторы 

        // конструктор по умолчанию
        public App() : this(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\admin\Desktop\HomeWork\HomeWork\App_Data\Transactions.mdf;Integrated Security=True") { }

        // конструктор инициализирующий
        public App(string connectionString)
        {
            // установка значений
            _connectionString = connectionString;
        }

        #endregion
    }
}
