using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Models
{
    // Класс Подписчик
    class Subscriber
    {
        // фамилия
        private string _lastName;

        public string LastName
        {
            get => _lastName; 
            set => _lastName = value; 
        }


        // имя
        private string _name;

        public string Name
        {
            get => _name;
            set => _name = value;
        }



        // отчество
        private string _patronymic;

        public string Patronymic
        {
            get => _patronymic;
            set => _patronymic = value;
        }



        // номер паспорта
        private string _passport;

        public string Passport
        {
            get => _passport; 
            set => _passport = value; 
        }



        // улица


        // номер дома


        // номер квартиры

    }
}
