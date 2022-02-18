using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "13.01.2022 - введение в LINQ to Object";
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Clear();

            // коллекция персон
            List<Person> persons = new List<Person> {
                new Person { Id =  1, FirstName = "Даша",    LastName = "Рыбачка",   Age = 23, IdCity = 5},
                new Person { Id =  2, FirstName = "Ваня",    LastName = "Иванов",    Age = 25, IdCity = 2},
                new Person { Id =  3, FirstName = "Таня",    LastName = "Цезарь",    Age = 29, IdCity = 1},
                new Person { Id =  4, FirstName = "Варвара", LastName = "Васильева", Age = 28, IdCity = 3},
                new Person { Id =  5, FirstName = "Дима",    LastName = "Цветков",   Age = 31, IdCity = 4},
                new Person { Id =  6, FirstName = "Таня",    LastName = "Васильева", Age = 33, IdCity = 4},
                new Person { Id =  7, FirstName = "Олег",    LastName = "Иванов",    Age = 67, IdCity = 3},
                new Person { Id =  8, FirstName = "Дима",    LastName = "Рилус",     Age = 53, IdCity = 1},
                new Person { Id =  9, FirstName = "Яна",     LastName = "Ромашкина", Age = 27, IdCity = 4},
                new Person { Id = 10, FirstName = "Алина",   LastName = "Ромашкина", Age = 37, IdCity = 2},
                new Person { Id = 11, FirstName = "Варя",    LastName = "Ромашкина", Age = 57, IdCity = 3},
                new Person { Id = 12, FirstName = "Таня",    LastName = "Васильева", Age = 27, IdCity = 2},
                new Person { Id = 13, FirstName = "Катя",    LastName = "Огогошко",  Age = 18, IdCity = 3},
                new Person { Id = 14, FirstName = "Маша",    LastName = "Морская",   Age = 21, IdCity = 5}
            };

            // коллекция городов
            List<City> cities = new List<City> {
                new City {Id = 1, Name = "Донецк"   },
                new City {Id = 2, Name = "Луганск"  },
                new City {Id = 3, Name = "Макеевка" },
                new City {Id = 4, Name = "Алчевск"  },
                new City {Id = 5, Name = "Седово"   }
            };

            ShowList(persons, "\nСписок персон:\n");
            ShowList(cities, "\nСписок городов:\n");

           
            // объединение - join, Join()
            // DoJoinDemo(persons, cities);
 
            
            // упорядочивание - order by
            //                  OrderBy()           - условие сортировки
            //                  OrderByDescending() - то же, но по убыванию
            //                  ThenBy()            - еще одно условие сортировки
            //                  ThenByDescending()  - то же, но по убыванию

            // группировка    - group ... by  ... into - формируются пары ключ - значение
            //                  ключ группировки - поле, по которому идет группировка
            //                  GroupBy()
            DoOrderByGroupBy(persons, cities);
            
        } // Main


        // Объединение коллекций - join .. on ... или where (как в SQL)
        // или расширяющий метод Join()
        private static void DoJoinDemo(List<Person> persons, List<City> cities) {
            // Вывести всех персон и названия городов в которых они проживают
            var request1 =
                from person in persons
                from city in cities
                where person.IdCity == city.Id   // условие объединения (связи) коллекций
                select new {                     // проекция на анонимный тип
                    person.FirstName,
                    person.LastName,
                    CityName = city.Name  // явное задания имени для поля названия города
                }; 
            var result1 = request1.ToList();
            ShowList(result1, "\nСписок персон и города их проживания:\n");
            
            // Вывести всех персон и названия городов в которых они проживают
            // теперь через оператор join -- очень похоже на SQL
            var request2 =
                from person in persons
                join city in cities on person.IdCity equals city.Id // условие объединения (связи) коллекций
                select new {                                        // проекция на анонимный тип
                    person.FirstName,
                    person.LastName,
                    CityName = city.Name
                };


            var result2 = request2.ToList();
            ShowList(result2, "\nСписок персон и города их проживания:\n");
            
            // Вывести всех персон и названия городов в которых они проживают - через расширяющие методы 
            request1 = persons // какая коллкция соединяется
                .Join(
                cities, // с какой коллекцией соединяемся 
                person => person.IdCity, // условие соединения первой колекции  - показываем совпадающие поля
                city => city.Id,         // условие соединения второй коллекции - показываем совпадающие поля
                // условие выбора (проецирования) из обоих коллекций выбираем нужные поля 
                (person, city) => new { person.FirstName, person.LastName, CityName = city.Name }  
            );


            result1 = request1.ToList();
            ShowList(result1, "\nСписок персон и города их проживания:\n");
            
            // Вывести всех персон, проживающих в заданном городе
            string name = "Седово";
            var request3 =
                 from person in persons
                 join city in cities on person.IdCity equals city.Id
                 where city.Name == name
                 select new Name
                 {   // выборка, проекция
                     FirstName = person.FirstName,
                     LastName = person.LastName,
                 };
            var result3 = request3.ToList();
            ShowList(result3, $"\n\nСписок персон, проживающих в {name} - синтаксис запроса:\n");

            result3 = persons
                .Join(
                    cities.Where(c => c.Name == name), // вначале фильтруем таблицу городов 
                    p => p.IdCity, // условие соедниения - для первой коллекции
                    c => c.Id,     // условие соедниения - для второй коллекции
                    (p, c) => new Name {FirstName = p.FirstName, LastName = p.LastName})
                .ToList();
            ShowList(result3, $"\nСписок персон, проживающих в {name} - синтаксис методов расширения:\n");
            Console.WriteLine();


            // Этот вариант строит сязь по полным коллекциям, выполняет две проекции - что слшком долго
            var result5 = persons
                .Join(cities, p => p.IdCity, c => c.Id,
                    (p, c) => new {p.FirstName, p.LastName, c.Name})
                .Where(pc => pc.Name == name)
                .Select(pc => new {pc.FirstName, pc.LastName})
                .ToList();
            ShowList(result5, $"\nСписок персон, проживающих в {name} - синтаксис методов расширения:\n");
            Console.WriteLine();
        } // DoJoinDemo

        
        // Упорядочивание и группировка
        // orderby, метод OrderBy(), ThenBy()
        // OrderBy() - сортировка по первому ключу
        // ThenBy() - сортировка по следующему ключу/ключам
        //                
        // descending  OrderByDescending(), ThenByDescending() - по убыванию
        // group, метод GroupBy()
        private static void DoOrderByGroupBy(List<Person> persons, List<City> cities)
        {
            
            // Вывести список персон, упорядоченный по фамилии
            // Записи с одинаковыми фамилиями сортируем по убыванию возраста
            var query1 =
                from person in persons
                orderby person.LastName descending , person.Age descending 
                select person;
            var result1 = query1.ToList();
            ShowList(result1, "\nСписок персон, упорядочен по убыванию фамилии, одинаковые фамилии - возраст по убыванию:\n" +
                              "синтаксис запроса\n");
            
            Console.WriteLine();
            query1 = persons
                .OrderByDescending(person => person.LastName)
                .ThenByDescending(person => person.Age);
            result1 = query1.ToList();
            ShowList(result1, "\nСписок персон, упорядочен по убыванию фамилии, одинаковые фамилии - возраст по убыванию:\n" +
                              "синтаксис расширяющих методов\n");
            
            Console.WriteLine();
            result1 = persons
                .OrderByDescending(person => person.LastName)
                .ThenBy(person => person.Age)
                .ToList();
            ShowList(result1, "\nСписок персон (по убыванию фамилий, возрастанию возраста для одинаковых фамилий):\n" +
                              "синтаксис расширяющих методов\n");
            
            // Вывести список персон, упорядоченный по фамилии
            // Записи с одинаковыми фамилиями сортируем по убыванию возраста
            var query2a =
                from person in persons
                join city in cities on person.IdCity equals city.Id
                orderby person.LastName, person.Age descending
                select new { person.FirstName, person.LastName, person.Age, CityName = city.Name};
            ShowList(query2a.ToList(), "\nСписок персон, упорядочен по фамилии, одинаковые фамилии - возраст по убыванию:\n" +
                              "синтаксис запроса, соединение двух коллекций\n");
            
            // -------------------------------------------------------------------
            
            // Группировка
            // Вывести фамилии и количество персон с такими фамилиями
            // т.е. требуется группировка по фамилиям
            var query2 =
                from person in persons
                // собираем в группу groupName всех персон коллекции с одинаковой фамилией 
                group person by person.LastName into groupName
                select new {
                    LastName = groupName.Key,   // выводим фамилию
                    Count = groupName.Count()   // количество записей в группе
                };
            var result2 = query2.ToList();
                ShowList(result2, "\nФамилии и количество их носителей (синтаксис запроса):\n");

            var query3 =
                from person in persons
                group person by person.LastName into groupName
                select new
                {
                    groupName.Key,
                    SumAge = groupName.Sum(p => p.Age),
                    Count = groupName.Count()
                };

            var result3 = query3.ToList();
                ShowList(result3, "\nФамилии, суммарный возраст и количество их носителей (синтаксис запроса):\n");
            

            result2 = persons
                    // key - ключ группировки
                    // group - коллекция записей, входящих в группировку
                .GroupBy(p => p.LastName, (key, group) => new
                    {
                        LastName = key, 
                        Count = group.Count()
                    })
                .ToList();
            ShowList(result2, "\nФамилии и количество их носителей (синтаксис расширяющих методов):\n");
            
            // Вывести города и количество проживающих в них персон
            var query4 =
                from person in persons
                join city in cities on person.IdCity equals city.Id
                group city by city.Name into grCity
                select new {
                     CityName = grCity.Key,       // название города
                     CityCount = grCity.Count()   // количество персон коллекции из этого города
                };
            var result4 = query4.ToList();
            ShowList(result4, "\nГорода и количество в них проживающих персон:\n");

            result4 = persons
                .Join(cities, person => person.IdCity, city => city.Id,
                    (p, c) => new
                        {p.Id, p.LastName, p.FirstName, p.Age, CityName = c.Name})
                .GroupBy(item => item.CityName, 
                    (key, group) => new
                    {
                        CityName = key, 
                        CityCount = group.Count()
                    })
                .ToList();
            ShowList(result4, "\nГорода, количество в них проживающих персон:\n");
            
            var result5 = persons
                .Join(cities, person => person.IdCity, city => city.Id,
                    (p, c) => new
                        {p.Id, p.LastName, p.FirstName, p.Age, CityName = c.Name})
                .GroupBy(item => item.CityName, 
                    (key, group) => new
                    {
                        CityName = key, 
                        CityCount = group.Count(),
                        SumAge = group.Sum(h => h.Age)
                    })
                .ToList();
            ShowList(result5, "\nГорода, количество в них проживающих персон, суммарный возраст жителей:\n");
        } // DoOrderByGroupBy


        // Вывод результата
        private static void ShowList<T>(List<T> list, string title) {
            Console.Write(title);
            foreach (var item in list) {
                Console.WriteLine($"{item}");
            } // foreach
        } // showList
    } // class Program
}
