using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
 * Поля объекта класса Автор: 
 *      - идентификатор
 *      - фамилия и инициалы
 *      - год рождения
 */

namespace HomeWork.Models.Task1
{
    // Класс Автор
    public class Author
    {
        // идентификатор
        private int _id;

        public int Id
        {
            get => _id; 
            set => _id = value; 
        }


        // фамилия и инициалы
        private string _fullName;

        public string FullName
        {
            get => _fullName; 
            set => _fullName = value; 
        }


        // год рождения
        private int _yearBirth;

        public int YearBirth
        {
            get => _yearBirth; 
            set => _yearBirth = value; 
        }
    }
}
