using System;
using System.Linq;
using CrudLinqToSql.Models;

namespace CrudLinqToSql
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "19.01.2022 - добавление, изменение и удаление записей в LINQ to SQL";
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Clear();

            // Подключение к базе данных
            // После копирования в папку AppData файлам БД
            // надо дать разрешения полного доступа группе Пользователи
            // Открыть файлы БД и перетащить таблицы на dbml-дизайнер
            // Класс TestDbDataContext создастся автоматически
            TestDbDataContext db = new TestDbDataContext(
                "Data Source=(LocalDB)\\MSSQLLocalDB;" +
                "AttachDbFilename=\"D:\\Students\\ПД011\\06 ADO.NET\\06 Занятие ПД011 19.01.2022 ADO.NET\\CW\\" +
                "002_CrudLinqToSql\\CrudLinqToSql\\AppData\\TestDb.mdf\";" +
                "Integrated Security=True;Connect Timeout=30");

            // пример запроса, созданный с использованием синтаксиса LINQ
            Console.WriteLine("Список городов\nId   Название города  Население");

            // Операция чтения данных, R (Read) в аббревиатуре CRUD
            var query01 = 
                from city in db.Cities 
                select city;
            
            foreach (var city in query01) {
                Console.WriteLine($"{city.Id, 2}   {city.Name, -15}  {city.Population, -9}");
            } // for city
            Console.WriteLine("\n--------------------------------------------");
            
            // Операция insert, C (Create) в аббревиатуре CRUD
            // Создать новый объект в таблице City
            Cities newCity = new Cities {
                Name = "Широкий", Population = 1500
            };

            // Добавить созданный объект в коллекцию записей
            // базаДанных.Таблица.InsertOnSubmit(объект)
            db.Cities.InsertOnSubmit(newCity);

            // Отправить изменения в базу данных db.SubmitChanges();
            try {
                db.SubmitChanges();
            } catch (Exception e) {
                Console.WriteLine(e);
            } // try-catch

            Console.WriteLine($"\nСписок городов после вставки {newCity.Name}\nId   Название города  Население");
            foreach (var city in query01) {
                Console.WriteLine($"{city.Id,2}   {city.Name,-15}  {city.Population,-9}");
            } // for city
            Console.WriteLine("\n--------------------------------------------");
            Console.WriteLine("\n\n");

            // Буква U (Update) в аббревиатуре CRUD 
            // Изменить количество жителей в городе

            // 1. Выбрать данные для изменения
            var queryCity =
                from city in db.Cities
                where city.Name == "Широкий"
                select city;

            Cities readCity = queryCity.ToArray()[0];

            // 2. Изменить коллекцию - в данном случае меняем только одну запись
            readCity.Population += 500;

            // 3. Отправить изменения в базу данных
            try {
                db.SubmitChanges();
            } catch (Exception e) {
                Console.WriteLine(e);
            } // try-catch

            Console.WriteLine($"\nСписок городов после измения населения {newCity.Name}\nId   Название города  Население");
            foreach (var city in query01) {
                Console.WriteLine($"{city.Id,2}   {city.Name,-15}  {city.Population,-9}");
            } // for city
            Console.WriteLine("\n--------------------------------------------");
            Console.WriteLine("\n\n");
            
            // Удалить город из таблицы -- задать on delete cascade в ограничениях таблицы !!
            // 1. Отобрать записи для удаления, в даннлм случае удаляем только одну запись
            readCity = queryCity.ToArray()[0];
            
            // 2. Удаление записей из коллекции (!!! не из БД !!!)
            db.Cities.DeleteOnSubmit(readCity);

            // 3. Отправить изменения в базу данных
            try {
                db.SubmitChanges();
            } catch (Exception e) {
                Console.WriteLine(e);
            } // try-catch

            Console.WriteLine($"\nСписок городов после удаления города {newCity.Name}\nId   Название города  Население");
            foreach (var city in query01) {
                Console.WriteLine($"{city.Id,2}   {city.Name,-15}  {city.Population,-9}");
            } // for city
            Console.WriteLine("\n--------------------------------------------");
            
            // вызывать не надо 
            // b.Dispose();
            Console.WriteLine("\n\n");
        } // Main
    } // class Program
}
