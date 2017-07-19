using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToSqlRelationships.Data
{
    public class PersonRepository
    {
        private string _connectionString;

        public PersonRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Person> GetPeople()
        {
            using (var context = new PersonCarsDataContext(_connectionString))
            {
                var loadOptions = new DataLoadOptions();
                loadOptions.LoadWith<Person>(p => p.Cars);
                context.LoadOptions = loadOptions;
                return context.Persons.ToList();
            }
        }

        public IEnumerable<Car> GetCarsForPerson(int personId)
        {
            using (var context = new PersonCarsDataContext(_connectionString))
            {
                var loadOptions = new DataLoadOptions();
                loadOptions.LoadWith<Car>(c => c.Person);
                context.LoadOptions = loadOptions;
                return context.Cars.Where(c => c.PersonId == personId).ToList();
            }
        }
    }
}
