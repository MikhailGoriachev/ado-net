using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sets
{
    class City
    {
        public int Id { get; set; }   // иденнтификатор
        public string Name { get; set; }   // название города

        public override string ToString()
        {
            return $"{{City: Id = {Id}  Name = {Name}}}";
        } // ToString
    }
}
