using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FirstLinqToSql
{
    class Program
    {
        static void Main(string[] args){
            Console.Title = "13.01.2022 - введение в LINQ to SQL";
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Clear();

            // Подключение к базе данных
            // После копирования в папку App_Data файлам БД
            // надо дать разрешения полного доступа группе Пользователи
            // Открыть файлы БД и перетащить таблицы на dbml-дизайнер
            // Класс TestDbDataContext создастся автоматически
            TestDbDataContext db = new TestDbDataContext();

            // пример запроса, созданный с использованием синтаксиса LINQ
            Console.WriteLine("\n\nСписок городов\n" +
                              "-------------------------------\n" +
                              "Id   Название города  Население\n" +
                              "-------------------------------");
            
            var query01 = 
                from city in db.Cities select city;
            
            foreach (var city in query01) {
                Console.WriteLine($"{city.Id, 2}   {city.Name, -15}  {city.Population, -9}");
            } // for city
            Console.WriteLine("-------------------------------\n");

            // пример запроса, использующего функции LINQ
            Console.WriteLine("\nСписок сотрудников с городами проживания, упорядочен по населению городов\n" +
                "-----------------------------------------------------------------\n" +
                "Id   Фамилия И.О.      Возраст  Название города  Население города\n" +
                "-----------------------------------------------------------------");
            
            var query02 = db.People
                .OrderByDescending(p=>p.Cities.Population)  // !!! сортировка по полю связанного класса !!!
                .ToList();
            
            foreach (var p in query02) {
                Console.WriteLine($"{p.Id, 2}   {p.SurnameNP, -15} {p.Age, 9}  {p.Cities.Name, -16}  " +
                                  $"{p.Cities.Population, 15}");
            } // for p
            Console.WriteLine("-----------------------------------------------------------------\n");

            // Список сотрудников с городами проживания, возраст < 30
            var query03 = 
                from person in db.People
                where person.Age < 30
                select person;

            Console.WriteLine("\nСписок сотрудников с городами проживания, возраст < 30\n" +
                              "-----------------------------------------------------------------\n" +
                              "Id   Фамилия И.О.      Возраст  Название города  Население города\n" +
                              "-----------------------------------------------------------------");
            foreach (var p in query03) {
                Console.WriteLine($"{p.Id,2}   {p.SurnameNP,-15} {p.Age,9}  {p.Cities.Name,-16}  " +
                                  $"{p.Cities.Population,15}");
            } // for p
            Console.WriteLine("-----------------------------------------------------------------\n");

            var query04 = db.People
                .Where(person => person.Age < 30)
                .ToList();

            Console.WriteLine("\nСписок сотрудников с городами проживания, возраст < 30\n" +
                              "-----------------------------------------------------------------\n" +
                              "Id   Фамилия И.О.      Возраст  Название города  Население города\n" +
                              "-----------------------------------------------------------------");
            foreach (var p in query04) {
                Console.WriteLine($"{p.Id,2}   {p.SurnameNP,-15} {p.Age,9}  {p.Cities.Name,-16}  " +
                                  $"{p.Cities.Population,15}");
            } // for p
            Console.WriteLine("-----------------------------------------------------------------\n");

            Console.WriteLine("\n\n");
        } // Main
    } // class Program
}
