using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sets
{
    class Program
    {
        static void Main(string[] args) {
            Console.Title = "Занятие 24.01.2022 - множества, преобразования коллекций";

            // наборы данных для демонстрации
            int[] a = { 1, 2, 3, 3, 3, 4, 8, 8 };
            int[] b = { 3, 4, 5, 6 };
            IEnumerable<int> c;

            Show("Массив       a: ", a);
            Show("Массив       b: ", b);
            Console.WriteLine();

            // Соединение множеств - могут быть повторяющиеся значения
            c = a.Concat(b);
            Show("Concat    a, b: ", c.ToArray());
            
            // Объединение множеств - только уникальные значения
            c = a.Union(b);
            Show("Union     a, b: ", c.ToArray());

            // Пересечение множеств - элементы находящиеся и в первом и во втором множестве 
            c = a.Intersect(b);
            Show("Intersect a, b: ", c.ToArray());
            
            // Элементы первой последовательности, которых нет
            // во второй последовательности (разность множеств) 
            c = a.Except(b);
            Show("Except    a, b: ", c.ToArray());
            
            /* 
            Приведение типов
            ToList(), ToArray(), ToDictionary() 
            
            Методы преобразования необобщенных коллекций в обобщенные
            OfType() - приведение типов с игнорированием неподходящих значений 
            Cast()   - приведение типов с выбросом исключения при обнаружении неподходящих значений
            
            */
            
            
            Console.WriteLine("\nПреобразование списка в словарь\n");
            List<City> cities = new List<City> {
                new City {Id = 1, Name = "Донецк"   },
                new City {Id = 2, Name = "Луганск"  },
                new City {Id = 3, Name = "Макеевка" },
                new City {Id = 4, Name = "Алчевск"  },
                new City {Id = 5, Name = "Седово"   }
            };

            // лямбда задает ключевое поле
            //         K    Value
            Dictionary<int, City> dictionary = cities.ToDictionary(x => x.Id);

            Console.WriteLine("Ключ   -->  Значение");
            // Тип KeyValuePair<int, City> - тип - пара ключ-значение из словаря 
            foreach (KeyValuePair<int, City> item in dictionary) {
                // item.Key   - значение ключа
                // item.Value - значение пары 
                Console.WriteLine($"{item.Key}  -->  ({item.Value})");
            } // foreach


            // Альтернативный вариант - компилятор сам подставит KeyValuePair<int, City>
            Console.WriteLine();
            Console.WriteLine("Ключ   -->  Значение");
            foreach (var item in dictionary) {
                Console.WriteLine($"{item.Key}  -->  ({item.Value})");
            } // foreach
            
            
            // Пример преобразования необобщенной коллекции в обобщенную
            Console.WriteLine();
            ArrayList values = new ArrayList {
                21, "4", 5, "6", 7, "8", 
                new City { Id = 1, Name = "Город"}
            };

            Console.Write("Исходная необобщенная коллекция: ");
            foreach (var item in values) {
                Console.Write($"{item}; ");
            }
            Console.WriteLine();

            
            try {
                // в result попадут только элементы коллекции типа int
                IEnumerable<int> result = values.OfType<int>();
                // IEnumerable<int> result = values.Cast<int>();
                Console.Write("Результирующая, закрытая типом int коллекция (т.е. только int-переменные): ");
                foreach (var item in result) {
                    Console.Write($"{item}; ");
                } // foreach
            } catch (Exception ex) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n\n{ex.Message}");
                Console.ResetColor();
            } // try-catch
            
            Console.WriteLine();
        } // Main

        // отображение массива dataInts в консоли в сопровождении заголовка title
        private static void Show(string title, IEnumerable dataInts) {
            StringBuilder sbr = new StringBuilder(title);
            foreach (var item in dataInts) sbr.Append($"{item, 3}");
            Console.WriteLine(sbr);
        } // Show
    } // class Program
}
