using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ExtentMethodDemo
{
    class Program
    {
        static void Main(string[] args) {
            Console.Title = "10.01.2022 - расширяющие методы";

            // строка для исследований
            string str = "Это строка";

            // вызов расширяющегно метода str.SqrLength()
            Console.WriteLine($"\"{str}\", длина строки {str.Length}, квадрат длины строки {str.SqrLength()}");

            str = "Это еще одна строка для демонстрации расширяющего метода";
            int n = str.SqrLength();
            Console.WriteLine($"\"{str}\", длина строки {str.Length}, квадрат длины строки {n}");

            str = "формат заголовка метода (метод - статический!!!)";
            n = str.SqrLength();
            Console.WriteLine($"\"{str}\", длина строки {str.Length}, квадрат длины строки {n}");
            
            // вызов расширяющего метода str.VowelNumbers()
            str = "Арбуз растет на дереве, but a starman waiting in the sky";
            Console.WriteLine($"\nВ строке \"{str}\" гласных {str.VowelNumbers()}");

            Console.WriteLine($"\nПервый символ строки \"{str}\": '{str.FirstChar()}'");

            int i = (new Random()).Next(1, str.Length - 1); 
            Console.WriteLine($"\n{i}-й символ строки \"{str}\": '{str.CharAt(i)}'");

            Console.WriteLine($"\nПоследний символ строки \"{str}\": '{str.LastChar()}'\n\n");

            // Мы добавили  расширяющий метод Contains(), но его игнорят,
            // вызывается стандартный Contains() класса string
            // т.к. нельзя перекрыть существующий метод
            // Console.WriteLine($"{str.Contains("hello")}");

        } // Main

      
    } // class Program

    // Отдельный класс для метода/методов расширения
    // должен быть не типизированным (non-generic),
    // должен быть не унаследованным (non-nested)
    // должен быть статическим
    static class ForMyExtendedMethods
    {
        // расширяющий метод для класса string - возвращает квадрат длины строки
        // формат заголовка метода (метод - статический!!!)
        // public static тип ИмяМетода(this ИмяРасширяемогоКласса объектРасширяемогоКласса, тип1 пар1, ...) {}
        public static int SqrLength(this string x) {
            int len = x.Length;
            return len * len;
        } // SqrLength

        // Так не работает - нельзя перекрыть существующий метод
        // public static int Contains(this string x, string y)
        // {
        //     return y.Length;
        // } // Contains

        // еще один расширяющий метод - подсчет гласных букв в строке
        public static int VowelNumbers(this string s) {
            int counter = 0;
            string vowel = "аеиоуыэюяaeiuoy";
            string s1 = s.ToLower();

            foreach (var c in s1) {
                if (vowel.Contains(c)) counter++;
            } // foreach

            return counter;
        } // VowelNumbers

        // расширяющий метод, возвращающий первый символ строки
        public static char FirstChar(this string str) =>  str[0];


        // расширяющий метод, возвращающий последний символ строки
        public static char LastChar(this string str) => str[str.Length-1];

        // расширяющий метод, возвращающий i-ый символ строки
        public static char CharAt(this string str, int i) => str[i];
    } // class ForMyExtendedMethods
}
