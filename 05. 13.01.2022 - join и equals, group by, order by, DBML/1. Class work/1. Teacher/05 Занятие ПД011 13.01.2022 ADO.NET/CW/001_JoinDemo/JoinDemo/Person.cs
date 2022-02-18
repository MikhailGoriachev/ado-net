using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinDemo
{
    // тип для демонстрации связанных коллекций 
    // Person связан с City по полю  IdCity
    class Person
    {
        public int Id { get; set; }             // ид записи
        public string FirstName { get; set; }   // имя персоны
        public string LastName { get; set; }    // фамилия персоны
        public int Age { get; set; }            // возраст  в годах
        public int IdCity { get; set; }         // ид города

        public override string ToString() =>
            $"{LastName,-15} {FirstName,-15} {Age, 3} {IdCity}";
    } // class Person
}
