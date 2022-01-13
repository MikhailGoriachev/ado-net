using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Periodicals.Controllers;      // контроллеры
using System.Configuration;

using static Periodicals.Application.App.Utils;       // для использования утилит

namespace Periodicals.Application
{
    public partial class App
    {
        // контроллер обработки по заданию
        private TaskController _controller;

        public TaskController Controller
        {
            get => _controller; 
            set => _controller = value; 
        }


        #region Конструкторы

        // конструктор по умолчанию 
        public App() : this(new TaskController { ConnectionString = ConfigurationManager.ConnectionStrings["Periodicals"].ConnectionString }) { }

        // конструктор инициализирующий
        public App(TaskController taskController)
        {
            // установка значений
            _controller = taskController;
        }
        #endregion
    }
}
