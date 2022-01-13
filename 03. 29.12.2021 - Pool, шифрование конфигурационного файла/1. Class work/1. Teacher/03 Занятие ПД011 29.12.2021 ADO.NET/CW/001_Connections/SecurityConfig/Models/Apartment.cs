using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityConfig.Models
{
    // модель для отображения квартиры - все поля представления
    public class Apartment
    {
        public int ApartmentId { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public int Flat { get; set; }
        public int Area { get; set; }
        public int RoomNum { get; set; }

        // вывод в строку таблицы
        public string ToTableRow() =>
            $"\t│ {ApartmentId, 11} │ {Street, -15} │ {Building, -15} │ {Flat, 4} │ {Area, 4} │ {RoomNum, 7} │";
    }
}
