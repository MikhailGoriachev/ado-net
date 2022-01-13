using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

// REXX
// LINQ - Language INtegrated Queries

// LINQ to object  - запросы к коллекциям, массивам
// LINQ to SQL     - запросы к таблицам БД SQL
// LINQ to XML     - запросы к файлам XML / документам в формате XML
// LINQ to Entity  - запросы к сущностям EntityFramework (к таблицам БД)
// LINQ to DataSet - запросы к таблицам БД в отключенном режиме ADO.NET

namespace IntroLINQ
{
    class Program
    {
        static void Main(string[] args) {
            Console.Title = "10.01.2022 - введение в LINQ";

            // массив для исследований
            int[] data = { 2, 4, 5, 1, -1, -11, 6, 12, 1, -11, 12, -11};
            
            Console.WriteLine("Исходный массив:");
            foreach (var item in data) {
                Console.Write($"{item, 5}");
            }
            Console.WriteLine("\n");

            Console.WriteLine("\nМассив - выводим только четные числа:");
            Console.Write("Цикл четные: ");
            foreach (var item in data) {
                if (item % 2 == 0) Console.Write($"{item,5}");
            }
            Console.WriteLine();
            
            /* синтаксис запроса
               var query = from     переменная 
                           in       коллекция
                           where    условие с использованием переменной (при необходимости)
                           order by выражениеСортировки
                           select   выражениеТипаВключаемого в результат
             */

            // запрос к массиву - выбрать только четные числа
            // используем синтаксис LINQ - Language INtegrated Queries
            // язык встроенных запросов 
            var query1 = from item in data
                                 where item % 2 == 0
                                 select item;    // SQL: select item from data where item % 2 == 0;

            // Запрос выполняется не сразу после создания, а при
            // 1) обращении к запросу в циклах
            // 2) при вызове ToArray(), ToList(), ToDictionary() к запросу
            // 3) при вызове Count(), Max(), Min(), Sum()
            // Такое поведение запроса - отложенное исполнение, или LazyLoad
            Console.Write("LINQ четные: ");
            foreach (var item in query1) {
                Console.Write($"{item, 5}");
            }
            Console.WriteLine();
                    
            // тот же запрос, но с использованием синтаксиса методов расширения
            // LINQ-запрос транслируется в набор методов расширения
            var query2 = data
                .Where(item => item % 2 == 0)
                .Select(item => item); // такой Select() смысла не имеет - не используем в следующем примере
                    
            // Запрос выполняется не сразу после создания, а при
            // 1) обращении к запросу в циклах
            // 2) при вызове ToArray(), ToList(), ToDictionary() к запросу
            // 3) при вызове Sum(), Count() на запросе
            // Такое поведение запроса - отложенное исполнение, или LazyLoad
            int[] result = query2.ToArray();  // новый массив
            Console.Write("LINQ четные: ");
            foreach (var item in result) {
                Console.Write($"{item,5}");
            }
            Console.WriteLine();
                    
            int[] array = data
                .Where(item => item % 2 == 0)  // фильтруем, выбираем четные числа
                .ToArray();                       // выполняем запрос, помещая его результат в массив

            Console.Write("LINQ четные: ");
            foreach (var item in array) {
                Console.Write($"{item,5}");
            }
            Console.WriteLine("\n");
            foreach (var item in data) {
                Console.Write($"{item, 5}");
            }
            Console.WriteLine();
			        
            // Пример реализации еще одного запроса - отбор отрицательных чисел
            // и уменьшение их в 2 раза
            Console.ForegroundColor = ConsoleColor.Red;
            var query_x = 
                from item in data 
                where item < 0 
                select item/2;
            foreach (var x in query_x) {
                Console.Write($"{x, 5}");
            }
            Console.ResetColor();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Cyan; 
            query_x = data
                .Where(x => x < 0)
                .Select(x => x/2);
            Array.ForEach( query_x.ToArray(), x => Console.Write($"{x, 5}"));
            Console.ResetColor();
	        Console.WriteLine("\n");
                    
            Console.WriteLine("\nПримеры агрегатных функций для массива");
            // стандартные 5 агрегатных функций
            // выбрать минимальное, максимальное и рассчитать среднее значение, сумму и количество 
            // из массива - LINQ, методы расширения
            int min = data.Min();
            int max = data.Max();
            double avg = data.Average();
            int sum = data.Sum();
            int count = data.Count();
            
            Console.WriteLine($"min = {min}, max = {max}, average = {avg:F2}, sum = {sum}, count = {count};\n");
            
            // агрегатная функция, определяемая пользователем
            // произведение нечетных элементов массива
            // (x, y) => x + (y%2 == 0?y:1)  -->  считается так:  x = x + (y%2 == 0?y:1)
            long oddProduct = data.Aggregate((product, item) => product * (item%2 != 0?item:1));
            Console.WriteLine($"Произведение элементов с нечетным значением: {oddProduct}");
            
            // Примеры запросов 
            // колчество четных элементов массива
            int countEven = data
                .Where(x => x % 2 == 0)
                .Count();
            Console.WriteLine($"Четных {countEven}");

            // краткий вариант - количество четных элементов массива
            countEven = data.Count(x => x % 2 == 0);
            Console.WriteLine($"Четных {countEven}");

            // Сумма четных элементов
            int sumEven = data
                .Where(x => x % 2 == 0)
                .Sum();
            Console.WriteLine($"Сумма четных элементов {sumEven}");


            Console.WriteLine("\nПримеры Select()");
            // Запрос, удваивающий элемены массива - при этом формируется новый массив
            var query3 = 
                from item in data    
                select item * 2;  // запрос готов
            data = query3.ToArray();       // выполнение запроса
            Array.ForEach(data, item => Console.Write($"{item,5}"));
            Console.WriteLine();

            // тот же запрос через методы расширения
            data = data
                .Select(item => 2 * item)  // проекция, проецирующее выражение :) мы умные :)
                .ToArray();
            Array.ForEach(data, item => Console.Write($"{item,5}"));
            Console.WriteLine();

            // Для каждого отрицательного в массиве сгенерировать букву 'a', для каждого
            // положительного - букву 'б'
            var query4 = 
                from item in data
                select item >= 0?'а':'б';   // проецирование в другой тип
            
            // выполнение запроса
            char[] chars = query4.ToArray();
                    
            // вывод получившегося массива
            Array.ForEach(chars, item => Console.Write($"{item,5}"));
            Console.WriteLine();

            query4 = data.Select(item => item >= 0 ? 'а' : 'б');
            chars = query4.ToArray();
                    
            // вывод получившегося массива
            Array.ForEach(chars, item => Console.Write($"{item,5}"));
            Console.WriteLine();
            Console.ReadKey(true);

            // Вывести все элементы массива после первого минимального
            min = data.Min();
            Console.WriteLine($"\nВывести все элементы массива после первого минимального ({min}):");
                    
            // определяем количество пропускаемых элементов - до первого минимального
            // элемента включительно
            var query5 = data
                .SkipWhile(item => item > min)  // пропуск элементов до первого минимального
                .Skip(1);                       // пропуск минимального
            Array.ForEach(query5.ToArray(), item => Console.Write($"{item,5}"));
            Console.WriteLine();

            // вычисление суммы элементов массива после первого минимального элемента 
            sum = query5.Sum();
            Console.WriteLine($"Сумма элементов массива после первого минимального: {sum}");
                    
            Console.WriteLine("\n");
        } // Main
    } // class Program
}
