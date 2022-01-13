using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityConfig.Models
{
    // модель для отображения владельца квартиры - все поля представления
    public class Owner
    {
        public int OwnerId { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Passport { get; set; }
    }
}
