using Test_Task.Models;

namespace Test_Task.Services
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetAll();
        Person GetById(Guid id);
        void Add(Person person);
        void Update(Person person);
        void Delete(Guid id);
    }

}
