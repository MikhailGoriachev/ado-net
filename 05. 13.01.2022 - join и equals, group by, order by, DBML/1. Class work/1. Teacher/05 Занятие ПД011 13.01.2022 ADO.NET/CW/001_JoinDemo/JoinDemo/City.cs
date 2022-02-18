using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinDemo
{
    // тип для демонстрации связанных коллекций 
    // City связан с Person по полю  Id
    class City
    {
        public int    Id { get; set; }     // идентификатор
        public string Name { get; set; }   // название города

        public override string ToString()
        {
            return $"{Name,-15}";
        } // ToString
    } // class City
}
