using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQtoObjWhereSelect
{
    // тип для использования в проецирующих запросах LINQ
    // т.е. в части select запроса, возвращающей тип, отличный
    // от типа коллекции к которой строится запрос 
    class Name
    {
        public string FirstName { get; set; }   // собственно имя
        public string LastName { get; set; }    // фамилия

        public override string ToString() => $"{FirstName} {LastName}";
    } // class Name
}
