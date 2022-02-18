using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToSqlWinForms.Models
{
    // класс для отображения данных о персоне с выводом названия города 
    // вмемто его идентификатора
    public class PeopleViewModel
    {
        public int    Id       { get; set; }
        public string Fullname { get; set; }
        public string City     { get; set; }
        public int    Age      { get; set; }
    } // class PeopleViewModel
}
