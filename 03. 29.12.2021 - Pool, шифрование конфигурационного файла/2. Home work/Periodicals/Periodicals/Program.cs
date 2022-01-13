using Periodicals.Application;    // подключение главного класса приложения 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periodicals
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // установка заголовка окна 
            Console.Title = "Домашнее задание на 10.01.2022";

            // установка размера консоли
            Console.WindowWidth = 160;

            // объект App
            App app = new App();

            // запуск меню приложения 
            app.Menu();

            // возвращение исходного цвета 
            Console.ResetColor();
        }
    }
}
