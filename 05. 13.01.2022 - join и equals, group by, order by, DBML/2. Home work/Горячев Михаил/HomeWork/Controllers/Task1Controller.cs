using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HomeWork.Models;                              // модели 
using HomeWork.Models.Task1;                        // модели задания 1

using static HomeWork.Application.App.Utils;        // утилиты

/*
 * •	Задача 1. Даны две связанные коллекции – описание книг и авторов книг. Объект класса 
 *      Книга имеет следующие поля: идентификатор, идентификатор автора, название книги, год 
 *      издания, цена. Поля объекта класса Автор: идентификатор, фамилия и инициалы, год рождения. 
 *      
 *      Требуется реализовать запросы к коллекциям, использовать два варианта – синтаксис запросов и
 *      синтаксис расширяющих функций.  
 *      
 *      o	Вывести все книги коллекции, выводить фамилии и инициалы автора
 *      o	Вывести книги авторов, год рождения которых принадлежит заданном диапазону 
 *      o	Вывести книги, в названии которых содержится заданная подстрока и цена не превышает 
 *          заданного значения
 *      o	Список авторов и количество их книг в коллекции
 *      o	Средняя цена книг по годам издания
 *      o	Список авторов по убыванию количества их книг в коллекции 
 *      o	Средний возраст книг по авторам, выводить список с упорядочиванием фамилий и инициалов
 *          авторов по алфавиту
 */

namespace HomeWork.Controllers
{
    // Класс Контроллер обработки по заданию 1 (Книги)
    public class Task1Controller
    {
        // коллекция книг
        private List<Book> _books;

        public List<Book> Books
        {
            get => _books;
            set => _books = value;
        }


        // коллекция авторов
        private List<Author> _authors;

        public List<Author> Authors
        {
            get => _authors;
            set => _authors = value;
        }


        #region Конструкторы 

        // конструктор по умолчанию
        public Task1Controller() : this(new List<Book>(), new List<Author>()) { }


        // конструктор инициализирующий
        public Task1Controller(List<Book> books, List<Author> authors)
        {
            // установка значений
            _books = books;
            _authors = authors;
        }

        #endregion

        #region Методы

        // инициализация коллекций
        public void Initialization()
        {
            // очистка коллекций
            _books.Clear();
            _authors.Clear();

            // заполенение коллекции с авторами
            _authors.AddRange(new[] {
                new Author { Id = 1,  FullName = "Стефани Майер",       YearBirth = 1973 },   // 1
                new Author { Id = 2,  FullName = "Колин Маккалоу",      YearBirth = 1937 },   // 2
                new Author { Id = 3,  FullName = "Патрик Зюскинд",      YearBirth = 1949 },   // 3
                new Author { Id = 4,  FullName = "Павел Санаев",        YearBirth = 1969 },   // 4
                new Author { Id = 5,  FullName = "Елена Ризо",          YearBirth = 1980 },   // 5
                new Author { Id = 6,  FullName = "Сесилия Ахерн",       YearBirth = 1981 },   // 6
                new Author { Id = 7,  FullName = "Сергей Лукьяненко",   YearBirth = 1968 },   // 7
                new Author { Id = 8,  FullName = "Анна Гавальда",       YearBirth = 1970 },   // 8
                new Author { Id = 9,  FullName = "Борис Акунин",        YearBirth = 1956 },   // 9
                new Author { Id = 10, FullName = "Милана Касакина",     YearBirth = 1975 },   // 10
            });


            // заполнение коллеции с книгами
            _books.AddRange(new[] {
                new Book { Id =  1, Title = "Гостья",                        IdAuthor = 1, Price = rand.Next(12, 40) * 100, Year = 2008 },  // 1
                new Book { Id =  2, Title = "Солнце полуночи",               IdAuthor = 1, Price = rand.Next(16, 40) * 100, Year = 2020 },  // 2
                new Book { Id =  3, Title = "Новолуние",                     IdAuthor = 1, Price = rand.Next(14, 40) * 100, Year = 2006 },  // 3
                new Book { Id =  4, Title = "Рассвет",                       IdAuthor = 1, Price = rand.Next(12, 40) * 100, Year = 2008 },  // 4
                new Book { Id =  5, Title = "Поющие в терновнике",           IdAuthor = 2, Price = rand.Next(12, 40) * 100, Year = 1977 },  // 5
                new Book { Id =  6, Title = "Прикосновение",                 IdAuthor = 2, Price = rand.Next(12, 40) * 100, Year = 2008 },  // 6
                new Book { Id =  7, Title = "Леди из Миссалонги",            IdAuthor = 2, Price = rand.Next(12, 40) * 100, Year = 1987 },  // 7
                new Book { Id =  8, Title = "Женщины Цезаря",                IdAuthor = 2, Price = rand.Next(12, 40) * 100, Year = 1996 },  // 8
                new Book { Id =  9, Title = "Повесть о господине Зоммере",   IdAuthor = 3, Price = rand.Next(12, 40) * 100, Year = 1991 },  // 9
                new Book { Id = 10, Title = "Контрабас",                     IdAuthor = 3, Price = rand.Next(12, 40) * 100, Year = 1981 },  // 10
                new Book { Id = 11, Title = "Нулевой километр",              IdAuthor = 4, Price = rand.Next(12, 40) * 100, Year = 2007 },  // 11
                new Book { Id = 12, Title = "Похороните меня за плинтусом",  IdAuthor = 4, Price = rand.Next(12, 40) * 100, Year = 1996 },  // 12
                new Book { Id = 13, Title = "Выбираем имя малышу",           IdAuthor = 5, Price = rand.Next(12, 40) * 100, Year = 2008 },  // 13
                new Book { Id = 14, Title = "Волшебный дневник",             IdAuthor = 6, Price = rand.Next(12, 40) * 100, Year = 2009 },  // 14
                new Book { Id = 15, Title = "P.S. Я люблю тебя!",            IdAuthor = 6, Price = rand.Next(12, 40) * 100, Year = 2004 },  // 15
                new Book { Id = 16, Title = "Идеал",                         IdAuthor = 6, Price = rand.Next(12, 40) * 100, Year = 2017 },  // 16
                new Book { Id = 17, Title = "Недотёпа",                      IdAuthor = 7, Price = rand.Next(12, 40) * 100, Year = 2009 },  // 17
                new Book { Id = 18, Title = "Новый Дозор",                   IdAuthor = 7, Price = rand.Next(12, 40) * 100, Year = 2012 },  // 18
                new Book { Id = 19, Title = "Танцы на снегу",                IdAuthor = 7, Price = rand.Next(12, 40) * 100, Year = 2001 },  // 19
                new Book { Id = 20, Title = "Атомный сон",                   IdAuthor = 7, Price = rand.Next(12, 40) * 100, Year = 1990 },  // 20
            });

        }


        // 1. Вывести все книги коллекции, выводить фамилии и инициалы автора       (Linq)
        public void ShowProc1Linq() => (from book in _books
                                        join author in _authors on book.IdAuthor equals author.Id
                                        select new BookViewModel
                                        {
                                            Id          = book.Id,
                                            Title       = book.Title,
                                            AuthorName  = author.FullName,
                                            AuthorYear  = author.YearBirth,
                                            Year        = book.Year,
                                            Price       = book.Price
                                        }).ToList()
                                          .ShowTable();


        // 1. Вывести все книги коллекции, выводить фамилии и инициалы автора       (Extended)
        public void ShowProc1Extended() => _books.Join(_authors, b => b.IdAuthor, a => a.Id, 
                                                (b, a) => new BookViewModel { 
                                                                Id = b.Id, 
                                                                Title = b.Title, 
                                                                AuthorName = a.FullName, 
                                                                AuthorYear = a.YearBirth,
                                                                Year = b.Year, 
                                                                Price = b.Price })
                                                 .ToList()
                                                 .ShowTable();




        // 2. Вывести книги авторов, год рождения которых принадлежит заданном диапазону        (Linq)
        public void ShowProc2Linq(int yearLo, int yearHi) => (from book in _books
                                                              join author in _authors on book.IdAuthor equals author.Id
                                                              where author.YearBirth >= yearLo && author.YearBirth <= yearHi
                                                              select new BookViewModel
                                                              {
                                                                  Id = book.Id,
                                                                  Title = book.Title,
                                                                  AuthorName = author.FullName,
                                                                  AuthorYear = author.YearBirth,
                                                                  Year = book.Year,
                                                                  Price = book.Price
                                                              }).ToList()
                                                                .ShowTable();


        // 2. Вывести книги авторов, год рождения которых принадлежит заданном диапазону        (Extended)
        public void ShowProc2Extended(int yearLo, int yearHi) => _books.Join(_authors.Where(a => a.YearBirth >= yearLo && a.YearBirth <= yearHi), 
                                                                            b => b.IdAuthor, a => a.Id,
                                                                            (b, a) => new BookViewModel {
                                                                                Id = b.Id,
                                                                                Title = b.Title,
                                                                                AuthorName = a.FullName,
                                                                                AuthorYear = a.YearBirth,
                                                                                Year = b.Year,
                                                                                Price = b.Price })
                                                                       .ToList()
                                                                       .ShowTable();


        // 3. Вывести книги, в названии которых содержится заданная подстрока и цена не превышает       (Linq)
        // заданного значения
        public void ShowProc3Linq(string str, int maxPrice) => (from book in _books
                                                                let loStr = str.ToLower()
                                                                join author in _authors on book.IdAuthor equals author.Id
                                                                where book.Title.ToLower().Contains(loStr) && book.Price < maxPrice
                                                                select new BookViewModel
                                                                {
                                                                    Id = book.Id,
                                                                    Title = book.Title,
                                                                    AuthorName = author.FullName,
                                                                    AuthorYear = author.YearBirth,
                                                                    Year = book.Year,
                                                                    Price = book.Price
                                                                }).ToList()
                                                                .ShowTable();


        // 3. Вывести книги, в названии которых содержится заданная подстрока и цена не превышает       (Extended)
        // заданного значения
        public void ShowProc3Extended(string str, int maxPrice)
        {
            // искомая подстрока в нижнем регистре
            string loStr = str.ToLower();
            
            // получение и вывод результата
            _books.Where(b => b.Title.ToLower().Contains(loStr) && b.Price < maxPrice)
                                                     .Join(_authors, b => b.IdAuthor, a => a.Id,
                                                        (b, a) => new BookViewModel
                                                        {
                                                            Id = b.Id,
                                                            Title = b.Title,
                                                            AuthorName = a.FullName,
                                                            AuthorYear = a.YearBirth,
                                                            Year = b.Year,
                                                            Price = b.Price
                                                        })
                                                     .ToList()
                                                     .ShowTable();
        }


        // 4. Список авторов и количество их книг в коллекции                                           (Linq)
        public void ShowProc4Linq()
        {
            // результат запроса
            var result = (from author in _authors
                          join book in _books on author.Id equals book.IdAuthor
                          group author by author.FullName into authorGroup
                          select new
                          {
                                AuthorFullName = authorGroup.Key,
                                CountBooks = authorGroup.Count()
                          }).ToList();


            // вывод результата
            ShowHeadAuthorCountBooks();
            result.ForEach(a => ShowAuthorCountBooksElem(a.AuthorFullName, a.CountBooks));
            ShowAuthorCountBooksFooter();

        } // ShowProc4


        // 4. Список авторов и количество их книг в коллекции                                           (Extended)
        public void ShowProc4Extended()
        {
            // результат запроса
            var result = _authors.Join(_books, a => a.Id, b => b.IdAuthor, (a, b) => new BookViewModel {
                                                                            Id = b.Id,
                                                                            Title = b.Title,
                                                                            AuthorName = a.FullName,
                                                                            AuthorYear = a.YearBirth,
                                                                            Year = b.Year,
                                                                            Price = b.Price
                                                                        })
                    .GroupBy(b => b.AuthorName)
                    .Select(b => new { FullName = b.Key, CountBooks = b.Count() })
                    .ToList();

            // вывод результата
            ShowHeadAuthorCountBooks();
            result.ForEach(a => ShowAuthorCountBooksElem(a.FullName, a.CountBooks));
            ShowAuthorCountBooksFooter();

        } // ShowProc4


        // 5. Средняя цена книг по годам издания                                                        (Linq)
        public void ShowProc5Linq()
        {
            // результат запроса 
            var result = (from book in _books
                          group book by book.Year into yearGroup
                          select new {
                              Year = yearGroup.Key,
                              AvgPrice = yearGroup.Average(b => b.Price)
                          }).ToList();

            // вывод результата
            ShowHeadProc5();
            result.ForEach(b => ShowProc5Elem(b.Year, b.AvgPrice));
            ShowProc5Footer();

        } // ShowProc5


        // 5. Средняя цена книг по годам издания                                                        (Extended)
        public void ShowProc5Extended()
        {
            // результат запроса 
            var result = _books.GroupBy(b => b.Year)
                               .Select(b => new { Year = b.Key, AvgPrice = b.Average(item => item.Price) })
                               .ToList();

            // вывод результата
            ShowHeadProc5();
            result.ForEach(b => ShowProc5Elem(b.Year, b.AvgPrice));
            ShowProc5Footer();

        } // ShowProc5


        // 6. Список авторов по убыванию количества их книг в коллекции                                 (Linq)
        public void ShowProc6Linq()
        {
            // результат запроса
            var result = (from author in _authors
                          join book in _books on author.Id equals book.IdAuthor
                          group author by author.FullName into authorGroup
                          orderby authorGroup.Count() descending
                          select new
                          {
                              AuthorFullName = authorGroup.Key,
                              CountBooks = authorGroup.Count()
                          }).ToList();


            // вывод результата
            ShowHeadAuthorCountBooks();
            result.ForEach(a => ShowAuthorCountBooksElem(a.AuthorFullName, a.CountBooks));
            ShowAuthorCountBooksFooter();

        } // ShowProc6


        // 6. Список авторов по убыванию количества их книг в коллекции                                 (Extended)
        public void ShowProc6Extended()
        {
            // результат запроса
            var result = _authors.Join(_books, a => a.Id, b => b.IdAuthor, (a, b) => new BookViewModel {
                                                                                        Id = b.Id,
                                                                                        Title = b.Title,
                                                                                        AuthorName = a.FullName,
                                                                                        AuthorYear = a.YearBirth,
                                                                                        Year = b.Year,
                                                                                        Price = b.Price
                                                                                    })
                    .GroupBy(b => b.AuthorName)
                    .OrderByDescending(b => b.Count())
                    .Select(b => new { FullName = b.Key, CountBooks = b.Count() })
                    .ToList();

            // вывод результата
            ShowHeadAuthorCountBooks();
            result.ForEach(a => ShowAuthorCountBooksElem(a.FullName, a.CountBooks));
            ShowAuthorCountBooksFooter();

        } // ShowProc6


        // 7. Средний возраст книг по авторам, выводить список с упорядочиванием фамилий и инициалов    (Linq)
        // авторов по алфавиту
        public void ShowProc7Linq()
        {
            // получение среднего возраста по авторам
            var result = (from book in _books 
                          group book by book.IdAuthor into authorGroup
                          select new {
                              IdAuthor = authorGroup.Key,
                              AvgAge = authorGroup.Average(b => DateTime.Now.Year - b.Year)
                          }).ToList();

            // получение расшифровка полей в результирующих данных
            var finalResult = (from item in result
                               join author in _authors on item.IdAuthor equals author.Id
                               orderby author.FullName
                               select new {
                                   FullName = author.FullName,
                                   AvgAge = item.AvgAge
                               }).ToList();

            // вывод результата
            ShowHeadProc7();
            finalResult.ForEach(a => ShowProc7Elem(a.FullName, a.AvgAge));
            ShowProc7Footer();


        } // ShowProc7


        // 7. Средний возраст книг по авторам, выводить список с упорядочиванием фамилий и инициалов    (Extended)
        // авторов по алфавиту
        public void ShowProc7Extended()
        {
            // получение результата
            var result = _authors.Join(_books, a => a.Id, b => b.IdAuthor, (a, b) => new BookViewModel {
                                                                                        Id = b.Id,
                                                                                        Title = b.Title,
                                                                                        AuthorName = a.FullName,
                                                                                        AuthorYear = a.YearBirth,
                                                                                        Year = b.Year,
                                                                                        Price = b.Price
                                                                                    })
                                 .GroupBy(a => a.AuthorName)
                                 .OrderBy(a => a.Key)
                                 .Select(a => new { FullName = a.Key, AvgAge = a.Average(b => DateTime.Now.Year - b.Year)})
                                 .ToList();

            // вывод результата
            ShowHeadProc7();
            result.ForEach(a => ShowProc7Elem(a.FullName, a.AvgAge));
            ShowProc7Footer();

        } // ShowProc7


        #region Вывод результатов запросов


        #region Таблица авторов и количества их книг

        // вывод шапки таблицы автора и количества его книг
        public void ShowHeadAuthorCountBooks()
        {
            WriteColorXY("     ╔══════════════════════╦════════════╗\n", textColor: ConsoleColor.Magenta);
            WriteColorXY("     ║                      ║            ║", textColor: ConsoleColor.Magenta);
            WriteColorXY("Автор",        7, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Книги",       30, textColor: ConsoleColor.DarkYellow);
            Console.WriteLine();

            WriteColorXY("     ╠══════════════════════╬════════════╣\n", textColor: ConsoleColor.Magenta);

        } // ShowHeadAuthorCountBooks


        // вывод двух полей в виде таблицы
        public void ShowAuthorCountBooksElem(string author, int count)
        {
            WriteColorXY("     ║                      ║            ║", textColor: ConsoleColor.Magenta);
            WriteColorXY($"{author}",    7, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{count, 10}",    30, textColor: ConsoleColor.Green);
            Console.WriteLine();

        } // ShowAuthorCountBooksElem


        // вывод подвала таблицы на два поля двух полей в виде таблицы
        public void ShowAuthorCountBooksFooter() =>
            WriteColorXY("     ╚══════════════════════╩════════════╝\n", textColor: ConsoleColor.Magenta);


        #endregion


        #region Таблица для вывода результата запроса 5 (Средняя цена книг по годам издания)

        // вывод шапки таблицы автора и количества его книг
        public void ShowHeadProc5()
        {
            WriteColorXY("     ╔════════════╦════════════╗\n", textColor: ConsoleColor.Magenta);
            WriteColorXY("     ║            ║            ║", textColor: ConsoleColor.Magenta);
            WriteColorXY("Год изд.", 7, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Ср. цена", 20, textColor: ConsoleColor.DarkYellow);
            Console.WriteLine();

            WriteColorXY("     ╠════════════╬════════════╣\n", textColor: ConsoleColor.Magenta);

        } // ShowHeadAuthorCountBooks


        // вывод двух полей в виде таблицы
        public void ShowProc5Elem(int year, double price)
        {
            WriteColorXY("     ║            ║            ║", textColor: ConsoleColor.Magenta);
            WriteColorXY($"{year}",         10, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{price, 10:n0}", 20, textColor: ConsoleColor.Green);
            Console.WriteLine();

        } // ShowAuthorCountBooksElem


        // вывод подвала таблицы на два поля двух полей в виде таблицы
        public void ShowProc5Footer() =>
            WriteColorXY("     ╚════════════╩════════════╝\n", textColor: ConsoleColor.Magenta);


        #endregion


        #region Таблица для вывода результата запроса 7 (Средний возраст книг по авторам)

        // вывод шапки таблицы автора и количества его книг
        public void ShowHeadProc7()
        {
            WriteColorXY("     ╔══════════════════════╦════════════╗\n", textColor: ConsoleColor.Magenta);
            WriteColorXY("     ║                      ║            ║", textColor: ConsoleColor.Magenta);
            WriteColorXY("Автор", 7, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Ср. возр.", 30, textColor: ConsoleColor.DarkYellow);
            Console.WriteLine();

            WriteColorXY("     ╠══════════════════════╬════════════╣\n", textColor: ConsoleColor.Magenta);

        } // ShowHeadAuthorCountBooks


        // вывод двух полей в виде таблицы
        public void ShowProc7Elem(string author, double avg)
        {
            WriteColorXY("     ║                      ║            ║", textColor: ConsoleColor.Magenta);
            WriteColorXY($"{author}", 7, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{avg, 10:n1}", 30, textColor: ConsoleColor.Green);
            Console.WriteLine();

        } // ShowAuthorCountBooksElem


        // вывод подвала таблицы на два поля двух полей в виде таблицы
        public void ShowProc7Footer() =>
            WriteColorXY("     ╚══════════════════════╩════════════╝\n", textColor: ConsoleColor.Magenta);


        #endregion


        #endregion

        #endregion

    }
}
