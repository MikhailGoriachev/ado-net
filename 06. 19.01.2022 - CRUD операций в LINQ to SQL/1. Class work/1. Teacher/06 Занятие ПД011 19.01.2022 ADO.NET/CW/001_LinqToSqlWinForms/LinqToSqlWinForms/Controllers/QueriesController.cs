using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToSqlWinForms.Models;

namespace LinqToSqlWinForms.Controllers
{
    public class QueriesController
    {
        // связь с базой данных
        private TestDbDataContext _db;

        public QueriesController(): this(new TestDbDataContext()) { } // QueriesController

        public QueriesController(TestDbDataContext db) {
            _db = db;
        } // QueriesController

        // запрос выборки данных сотрудников, использование анонимного класса
        public IEnumerable QueryPeople() =>
            from person in _db.People
            select new {
                person.Id,
                person.SurnameNP,
                CityName = person.Cities.Name,
                person.Age
            };

        // запрос выборки данных по городам
        public IEnumerable QueryCities() {
            var query =
                from city in _db.Cities
                select new  {
                    city.Id,
                    city.Name,
                    city.Population
                };
            return query;
        } // QueryCities


        // запрос выборки данных о персонах с выводом названия города,
        // вместо идентификатора города - для этого применим вспомогательный класс
        // PeopleViewModel
        public List<PeopleViewModel> QueryPeopleCity() => _db.People
            .Select(p => new PeopleViewModel {
                Id = p.Id,
                Fullname = p.SurnameNP,
                City = p.Cities.Name,
                Age = p.Age
            })
            .ToList();
    } // class QueriesController
}
