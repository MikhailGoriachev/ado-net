using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQtoObjWhereSelect
{
    // Фильтрация и проецирование
    class Program
    {
        static void Main(string[] args) {
            Console.Title = "10.01.2022 - введение в LINQ to Object";
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Clear();

            // Обобщенная коллекция -- IEnumerable - результат запроса
            // List - стандартная коллекция .NET Framework - односвязный
            // обобщенная, универсальная, generic (шаблонный класс) -- IEnumerable<>
            List<Person> persons = new List<Person>() {
                new Person { FirstName = "Татьяна",     LastName = "Сталь",      Age = 23},
                new Person { FirstName = "Андрей",      LastName = "Двацветка",  Age = 28},
                new Person { FirstName = "Татьяна",     LastName = "Цезарь",     Age = 28},
                new Person { FirstName = "Дмитрий",     LastName = "Хазаров",    Age = 25},
                new Person { FirstName = "Андрей",      LastName = "Цветков",    Age = 31},
                new Person { FirstName = "Евгения",     LastName = "Белова",     Age = 31},
                new Person { FirstName = "Дмитрий",     LastName = "Ивановский", Age = 67},
                new Person { FirstName = "Дмитрий",     LastName = "Рыков",      Age = 31},
                new Person { FirstName = "Татьяна",     LastName = "Ромашкина",  Age = 42},
                new Person { FirstName = "Екатерина",   LastName = "Огогошко",   Age = 18}
            };

            Show(persons, "Список для обработки:");

            // Фильтрация - ключевое слово where или методы
            // Where(expression), 
            // Take(m) - получить первые m записей
            // TakeWhile(expression) - получать записи, пока выражение истинно   
            // Skip(m) - пропустить m записей, вернуть оставшиеся   
            // SkipWhile(expression) - пропускать записи, пока выражение истинно, вернуть оставшиеся
            // Distinct() - вернуть только уникальные записи
            
            // персоны старше 25 с именем Татьяна
            int age = 25;
            string name = "Татьяна";
            var query =
                from p in persons
                where p.Age > age && p.FirstName == name
                select p;
            var result = query.ToList();  // выполнение запроса (LazyLoad!!!)
            Show(result, $"\nВсе персоны с именем {name} старше {age} лет");
            
            Console.WriteLine("\nИспользуем анонимный тип:");
            var request_a = from person in persons
                where person.Age > 25 && person.FirstName == "Татьяна"
                select new {
                    // можно указать имя свойства явно, но оно должно совпадать
                    // с имененм по умолчанию, т.е. FirstName, Age в данном случае
                    // FirstName = person.FirstName, LastName = person.LastName, Age = person.Age
                    person.FirstName, person.LastName, person.Age
                    // FullName = person.FirstName + " " + person.LastName, person.Age
                };
            foreach (var item in request_a) {
                Console.WriteLine($"Имя {item.FirstName} {item.LastName} возраст {item.Age}");
            }

            Console.ReadKey(true);
            
            // пример с отложенным выполнением
            // request = persons.Where(person => person.Age > 25 && person.FirstName == "Татьяна");
            // result = request.ToList();

            // пример с немедленным выполнением
            result = persons   
                .Where(p => p.Age > 25 && p.FirstName == "Татьяна")
                .ToList();
            Show(result, "\nВсе Татьяны старше 25 лет");

            // вариант с анонимным типом
            var result_a = persons
                .Where(p => p.Age > 25 && p.FirstName == "Татьяна")
                .Select(p => new {p.FirstName, p.Age})
                .ToList();
            Show(result_a, "\nВсе Татьяны старше 25 лет - анонимный тип");
            
            // Take(n) - взять первые n записей
            // первые две записи, имена которых не Дарья и не Иван
            result = persons
                .Where(p => p.FirstName != "Дарья" && p.FirstName != "Иван")
                .Take(2)
                .ToList();
            Show(result, "\nпервые две записи, имена которых не Дарья и не Иван");
            
            // Skip(n) - пропустить первые n записей
            Show(persons.Skip(3).ToList(), "\nСписок персон без первых 3х");
            
            // TakeWhile(условие) - взять записи с начала коллекции, пока условие истинно
            // вывод записей с начала коллекции до записи с возрастом >= 50 
            result = persons
                .TakeWhile(p => p.Age < 50)
                .ToList();
            Show(result, "\nСписок персон до первой персоны с возрастом < 50 лет");
            
            // SkipWhile(условие) - пропускать записи с начала коллекции, пока условие истинно
            // Пропустить все подряд идущие записи с возрастом <= 33
            // т.е. выбирать все записи после первой записи с возрастом 33
            result = persons
                .SkipWhile(p => p.Age <= 33)
                .ToList();
            Show(result, "\nВсе персоны из списка после персоны с возрастом 33");

            Show(persons.Skip(2).Take(3).ToList(), "\nПропустили 2х первых, показали 3х следующих");
            
            // Проецирование - выборка при помощи select всей записи, части записи или
            // нового типа (тип анонимый или нет - не важно) 
            // Методы Select(), SelectMany()

            // Получение уникальных значений, Distinct() совмещенный с Select() (с проецированием)
            var request1 = (
                from person in persons
                select person.FirstName).Distinct();
            var result1 = request1.ToList();
            Show(result1, "\nСписок уникальных имен:");
            
            // Тот же запрос, но обратите внимание на Select() - возвращает
            // заданную часть типа, весь тип или новый, анонимный тип 
            // отложенное выполнение
            // request1 = persons.Select(p => p.FirstName).Distinct();
            // result1 = request1.ToList();

            // непосредственное выполнение
            result1 = persons
                .Select(p => p.FirstName)
                .Distinct()
                .ToList();

            Show(result1, "\nСписок уникальных имен:");
            
            // Создание анонимного типа в операторе select
            // Фамилии и имена персон старше 18 лет
            var request2 =
                from person in persons
                where person.Age > 18
                select new { person.FirstName, person.LastName};
            var result2 = request2.ToList();
            Show(result2, "\nФамилии и имена персон, старше 18 (анонимный тип)");

            request2 = persons
                .Where(p => p.Age > 18)
                .Select(p => new { p.FirstName, p.LastName });
            result2 = request2.ToList();
            Show(result2, "\nФамилии и имена персон, старше 18 (анонимный тип)");

            // Использование именованного типа Name в операторе select
            var request3 =
                from person in persons
                where person.Age > 18
                select new Name { FirstName = person.FirstName, LastName = person.LastName };
            var result3 = request3.ToList();
            Show(result3, "\nФамилии и имена персон, старше 18 (тип Name)");

            // LINQ расширяющие методы, непосредственное выполнение проецирования коллекции
            // типа Person в коллекцию Name (не слишком ли умно???? :) )
            result3 = persons
                .Where(p => p.Age > 18)
                .Select(p => new Name { FirstName = p.FirstName, LastName = p.LastName })
                .ToList();
            Show(result3, "\nФамилии и имена персон, старше 18 (тип Name)");

            // ----------------------------------------------------------------------
            
            // Вернуть имена и фамилии персон с диапазоном возраста от 18 до 25
            var request4 = persons
                .Where(p => p.Age >= 18 && p.Age <= 25)
                .Select(p => new {
                    p.FirstName, p.LastName
                })
                .ToList();
            Show(request4, "\nИмена и фамилии персон с диапазоном возраста от 18 до 25");

            var request4a =
                from p in persons
                where p.Age >= 18 && p.Age <= 25
                select new {p.FirstName, p.LastName};
            var result4 = request4a.ToList();
            Show(result4, "\nИмена и фамилии персон с диапазоном возраста от 18 до 25");

            // Сортировка коллекции
            var sorted = persons
                .OrderBy(p => p.Age)
                .ToList();
            Show(sorted, "\n\nСписок персон упорядоченый по возрасту");

            sorted = persons
                // .OrderBy(p => p.FirstName+ " " + p.Age.ToString())
                // .OrderBy(p => p.FirstName + " " + p.Age)  // неявный вызов Age.ToString() 
                .OrderBy(p => p.FirstName)
                .ThenBy(p => p.Age)
                .ToList();
            Show(sorted, "\n\nСписок персон упорядоченый по имени и возрасту");

            sorted = persons
                .OrderBy(p => p.FirstName)
                .ThenByDescending(p => p.Age)
                .ToList();
            Show(sorted, "\n\nСписок персон упорядоченый по имени и убыванию возрасту");

            sorted = persons
                .OrderByDescending(p => p.Age)
                .ToList();
            Show(sorted, "\n\nСписок персон упорядоченый по убыванию возрасту");

            sorted = persons
                .OrderByDescending(p => p.LastName)
                .ToList();
            Show(sorted, "\n\nСписок персон упорядоченый по убыванию фамилий");

            Console.WriteLine("\n\n");
            
            // отобрать Дмитриев и Татьян с возрастом от 29 до 50
            var queryLast =
                from p in persons
                where (p.FirstName == "Дмитрий" || p.FirstName == "Татьяна") &&
                    29 <= p.Age && p.Age <= 50
                select p.Age;
            foreach (var p in queryLast) {
                Console.WriteLine(p);
            }

            Console.WriteLine();

            var ageList = persons
                .Where(p => (p.FirstName == "Дмитрий" || p.FirstName == "Татьяна") &&
                            29 <= p.Age && p.Age <= 50)
                .Select(p => p.Age);
            foreach (var p in ageList) {
                Console.WriteLine(p);
            }

            Console.WriteLine("\n\n");
        } // Main


        // обобщенный метод
        // доступ тип имя<списокТипов>(список параметров) {...}
        private static void Show<T>(List<T> list, string title) {
            Console.WriteLine(title);
            list.ForEach(item => Console.WriteLine($"{item}"));
        } // Show
    } // class Program
}
