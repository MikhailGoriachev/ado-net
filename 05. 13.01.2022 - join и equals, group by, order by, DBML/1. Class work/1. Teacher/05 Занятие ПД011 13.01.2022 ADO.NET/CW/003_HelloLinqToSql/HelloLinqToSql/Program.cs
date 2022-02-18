using System;
using System.Collections.Generic;
using System.Linq;     // появляется при добавлении элемента "Классы LINQ для SQL"
using System.Text;
using System.Threading.Tasks;

namespace HelloLinqToSql
{
    class Program
    {
        // пример приложения с использованием LINQ to SQL
        static void Main(string[] args) {
            // контекст данных - подключение к базе данных
            Books2DataContext db = new Books2DataContext();

            Console.WriteLine("\n\nВсе книги - синтаксис SQL:");
            // запрос - выбрать все книги, демонстрация работы
            // связанных свойств
            // Связи - из модели базы данных
            var query =
                from book in db.books
                select book;
            // вывод выбранных данных 
            ShowBooks(query);

            Console.WriteLine("\n\nКниги Шилдта - синтаксис SQL:");
            var query1 =
                from book in db.books
                where book.authors.name.Contains("Шилдт")
                select book;
            // вывод выбранных данных 
            ShowBooks(query1);


            Console.WriteLine("\n\nВсе книги - синтаксис расширяющих методов:");
            // запрос - выбрать все книги, демонстрация работы
            // связанных свойств
            // Связи - из модели базы данных
            // вывод выбранных данных 
            ShowBooks(db.books);

            Console.WriteLine("\n\nКниги Шилдта - синтаксис расширяющих методов:");
            query1 = db.books
                .Where(book => book.authors.name.Contains("Шилдт"));
            ShowBooks(query1);
        } // Main


        // вывод результата запроса к таблице books
        private static void ShowBooks(IQueryable<books> query) {
            foreach (var book in query) {
                Console.WriteLine(
                    $"{book.id,3} {book.authors.name,-15} {book.categories.category,-12} {book.title,-43} " +
                    $"{book.year, 4} {book.price, 5}");
            } // foreach book
        } // ShowBooks
    } // class Program
}
