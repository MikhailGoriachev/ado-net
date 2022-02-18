using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeftJoinDemo
{
    class Program {
        // https://docs.microsoft.com/ru-ru/dotnet/csharp/linq/perform-left-outer-joins
        static void Main(string[] args) {
            Console.Title = "Занятие 24.01.2022 - левое соединение";
            LeftOuterJoinExample();
        } // Main

        public static void LeftOuterJoinExample() {
            Person magnus    = new Person {FirstName = "Magnus",    LastName = "Hedlund"};
            Person terry     = new Person {FirstName = "Terry",     LastName = "Adams"};
            Person steicy    = new Person {FirstName = "Steicy",    LastName = "Grimes" }; // без животного
            Person charlotte = new Person {FirstName = "Charlotte", LastName = "Weiss"};
            Person arlene    = new Person {FirstName = "Arlene",    LastName = "Huff"};    // без животного
            Person tom       = new Person {FirstName = "Tom",       LastName = "Higgins"}; // без животного

            Pet barley   = new Pet {Name = "Barley",    Owner = terry};
            Pet boots    = new Pet {Name = "Boots",     Owner = terry};
            Pet whiskers = new Pet {Name = "Whiskers",  Owner = charlotte};
            Pet bluemoon = new Pet {Name = "Blue Moon", Owner = terry};
            Pet daisy    = new Pet {Name = "Daisy",     Owner = magnus};

            // Две коллекции для работы
            List<Person> people = new List<Person> {magnus, terry, steicy, charlotte, arlene, tom};
            List<Pet>    pets   = new List<Pet> {barley, boots, whiskers, bluemoon, daisy};

            // выборка данных при помощи левого соединения
            // вывести всех персон и их животных
            var query = 
                from person in people
                join pet in pets on person equals pet.Owner into group_join
                from subpet in group_join.DefaultIfEmpty()
                select new {person.FirstName, PetName = subpet?.Name ?? "none"};

            Console.WriteLine("\n\nOwner            Pet");
            Console.WriteLine("---------------  ---------------");

            // вывод запроса
            query
                .ToList()
                .ForEach(item => Console.WriteLine($"{item.FirstName,-15}: {item.PetName}"));

            Console.WriteLine();
        } // Main
    } // class Program




}

