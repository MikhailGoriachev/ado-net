using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQtoObject
{
    class Person
    {
        public int   Id         { get; set; }   // ид записи
        public string FirstName { get; set; }   // имя персоны
        public string LastName  { get; set; }   // фамилия персоны
        public int    Age       { get; set; }   // возраст в годах

        public override string ToString()
        {
            return $"\"{FirstName,-15}\" \"{LastName,-15}\" {Age, 3}";
        } // ToString
    } // class Person
}
