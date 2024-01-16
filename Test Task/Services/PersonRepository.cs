using Test_Task.Data;
using Test_Task.Models;

namespace Test_Task.Services
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ApplicationDbContext _context;

        public PersonRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Person> GetAll()
        {
            return _context.Persons.ToList();
        }

        public Person GetById(Guid id)
        {
            return _context.Persons.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Person person)
        {
            _context.Persons.Add(person);
            _context.SaveChanges();
        }

        public void Update(Person person)
        {
            _context.Persons.Update(person);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var personToDelete = _context.Persons.Find(id);
            if (personToDelete != null)
            {
                _context.Persons.Remove(personToDelete);
                _context.SaveChanges();
            }
        }
    }

}
