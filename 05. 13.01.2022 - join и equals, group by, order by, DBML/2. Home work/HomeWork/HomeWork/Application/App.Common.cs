using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using HomeWork.Controllers;     // контроллеры

using static HomeWork.Application.App.Utils;       // для использования утилит


namespace HomeWork.Application
{
    public partial class App
    {
        // контроллер обработки по заданию 1
        private Task1Controller _task1Controller;

        public Task1Controller Task1Controller
        {
            get => _task1Controller; 
            set => _task1Controller = value; 
        }


        // контроллер обработки по заданию 2
        private Task2Controller _task2Controller;

        public Task2Controller Task2Controller
        {
            get => _task2Controller; 
            set => _task2Controller = value; 
        }


        #region Конструкторы 

        // конструктор по умолчанию
        public App() : this(new Task1Controller(), new Task2Controller()) { }


        // конструктор инициализирующий
        public App(Task1Controller task1Controller, Task2Controller task2Controller)
        {
            // установка значений 
            _task1Controller = task1Controller;
            _task2Controller = task2Controller;

            task1Controller.Initialization();
        }

        #endregion

    }
}
