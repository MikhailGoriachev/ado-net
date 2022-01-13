using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Models
{
    // Вид издания
    class TypeOfEdition
    {
        // первичный ключ
        private int _id;

        public int Id
        {
            get => _id; 
            set => _id = value; 
        }


        // вид издания
        private string _typeEdition;

        public string TypeEdition
        {
            get => _typeEdition; 
            set => _typeEdition = value; 
        }

    }
}
