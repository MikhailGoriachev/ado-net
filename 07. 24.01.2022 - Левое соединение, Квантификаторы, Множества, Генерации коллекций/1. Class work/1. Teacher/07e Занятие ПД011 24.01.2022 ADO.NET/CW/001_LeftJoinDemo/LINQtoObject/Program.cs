using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LINQtoObject
{
    class Program
    {
        static void Main(string[] args) {
            Console.Title = "Занятие 24.01.2022 - LINQ to object, дополнение";

            List<Person> persons = new List<Person> {
                new Person { Id =  1, FirstName = "Даша",  LastName = "Ситникова", Age = 23},
                new Person { Id =  2, FirstName = "Ваня",  LastName = "Бурцев",    Age = 25},
                new Person { Id =  3, FirstName = "Ирина", LastName = "Ципкало",   Age = 29},
                new Person { Id =  4, FirstName = "Вова",  LastName = "Терешенко", Age = 25},
                new Person { Id =  5, FirstName = "Дима",  LastName = "Цветков",   Age = 31},
                new Person { Id =  6, FirstName = "Тома",  LastName = "Белая",     Age = 33},
                new Person { Id =  7, FirstName = "Олег",  LastName = "Иванов",    Age = 67},
                new Person { Id =  8, FirstName = "Дима",  LastName = "Родинский", Age = 53},
                new Person { Id =  9, FirstName = "Тома",  LastName = "Ромашкина", Age = 27},
                new Person { Id = 10, FirstName = "Алина", LastName = "Ромашкина", Age = 18},
                new Person { Id = 11, FirstName = "Варя",  LastName = "Ромашкина", Age = 57},
                new Person { Id = 12, FirstName = "Тома",  LastName = "Васильева", Age = 27},
                new Person { Id = 13, FirstName = "Катя",  LastName = "Огогошко",  Age = 18}
            };

            // Поэлементные операции - возвращают один элемент, выполняются немедленно
            // First(), Last() - возврат первого или последнего, соотв. условию --> InvalidOperationException 
            // Single() - возврат первого, но в отличие от First() - выборос InvalidOperationException, если 
            //            элементов > 1
            // ElementAt() - получить элемент по указанному индексу, не работает с LINQtoSQL

            Console.WriteLine("\nПоэлементные операции");
            var request =
                from p in persons where p.FirstName == "Тома" select p;
            Console.WriteLine("First() " + request.First());
            Console.WriteLine("Last()  " + request.Last());
            // Console.WriteLine("Single() " + (request.Single()));
            Console.WriteLine("ElementAt() " + request.ElementAt(0));
            Console.WriteLine("ElementAt() " + request.ElementAt(request.Count()-1));
            
            Person pers = persons.First(p => p.FirstName == "Тома");
            Console.WriteLine("First(L) " + pers);

            
            // FirstOrDefault(), LastOrDefault()
            // default: 0 для значимых типов, null для ссылочных
            // SingleOrDefault() - все-таки бросает исключение... InvalidOperationException
            // pers = persons.SingleOrDefault(p => p.FirstName == "Тома"); // ????
            // pers = persons.SingleOrDefault(p => p.FirstName == "Таря"); // ????
            pers = persons.SingleOrDefault(p => p.FirstName == "Варя"); // ????
            Console.WriteLine($"\n\"{pers}\"");

            Console.WriteLine($"\n{persons[3]} == {persons.ElementAt(3)}: {persons[3] == persons.ElementAt(3)}");
            
            
            // Квантификаторы - операторы типа bool, показывают удовлетворяет или
            // нет один или несколько элементов коллекции заданному условию
            // Contains(), Any(), All(), SequenceEqual()
            Console.WriteLine("\nКвантификаторы:");
            Console.WriteLine(persons.Contains(pers));              // true, если есть персона pers в коллекции
            Console.WriteLine(persons.Any(p => p.Age > 50));  // true, если условие выполняется хотя бы для одного в коллекции
            Console.WriteLine(persons.All(p => p.Age > 30));  // true, если условие выполняется для всех записей в коллекции
            
            
            // Методы генерирования коллекций ---------------------------------------------------------
            // Empty(), Range(), Repeat()
            // статические, не расширяющие методы класса Enumerable
            IEnumerable <int> vars = Enumerable.Empty<int>();   // пустая коллекция
            Console.WriteLine($"{vars.Count()}");

            // Python
            // for i in range(3, 13):
            //     print(f'{i:3}')
            vars = Enumerable.Range(3, 10);        // последовательность от 3х из 10 чисел с шагом 1
            foreach (var item in vars) {       // т.е. 3, 4, ..., 12
                Console.Write($"{item}  ");
            }
            Console.WriteLine();

            
            // int[] arr1 = new int[10];
            // foreach (int i in Enumerable.Range(0, 10)) {
            //     arr1[i] = i;
            // }
            // 
            // такой вариант короче
            // int[] arr1 = Enumerable.Range(0, 10).ToArray();

            vars = Enumerable.Repeat(7, 5);   // число 7 повторить 5 раз
            foreach (var item in vars) {
                Console.Write($"{item}  ");
            }
            Console.WriteLine();
            
            
            // создать список из 10 пустых объектов типа Person
            List<Person> list = Enumerable
                .Repeat(new Person(), 10)
                .ToList();
            Console.WriteLine("Сформированный список объектов типа Person (пустые объекты):");
            foreach (var item in list) {
                Console.WriteLine(item);
            }
            
            
            // Генерация массива случайных чисел
            int[] array;
            int number = 11;        // количество элементов массива
            int Lo = -12, Hi = 15;  // диапазон значений случайных чисел
            Random rnd = new Random();
            Console.WriteLine($"\nМассив случайных чисел из {number} элементов, диапазон от {Lo} до {Hi}:");
            
            array = Enumerable
                .Repeat(0, number)
                .Select(x => rnd.Next(Lo, Hi + 1))
                .ToArray();

            foreach (var item in array) {
                Console.Write($"{item}  ");
            }
            Console.WriteLine();
            
            // пример преобразования массива в коллекцию и вывода без явного задания цикла
            List<int> listArray = new List<int>(array);
            listArray.ForEach(item=> Console.Write($"{item}  "));
            Console.WriteLine();
            
        } // Main

    } // class Program
}
