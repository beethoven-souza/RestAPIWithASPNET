using RestAPI_ASPNET.Model;
using RestAPI_ASPNET.Model.Context;

namespace RestAPI_ASPNET.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private SqlServerContext _context;

        public PersonServiceImplementation(SqlServerContext context) 
        {
            _context = context;
        }
        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        public Person FindById(long id)
        {
            return  new Person
            {
                Id = 1,
                FirstName = "Beethoven",
                LastName = "Souza",
                Adress = "Niterói - RJ - Brasil",
                Gender = "Male"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }        
    }
}
