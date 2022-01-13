using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQtoObjWhereSelect
{
    // демонстрационный класс для LINQtoObject
    class Person
    {
        public string FirstName { get; set; }   // имя
        public string LastName  { get; set; }   // фамилия
        public int Age          { get; set; }   // возраст в годах

        //---------------------------------------------
        public override string ToString() =>
            $"{FirstName, -15} {LastName, -15} {Age}";
    } // class Person
}
