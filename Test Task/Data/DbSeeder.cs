using Microsoft.EntityFrameworkCore;
using Test_Task.Models;

namespace Test_Task.Data
{
    public static class DbSeeder
    {
        public static void SeedData(ApplicationDbContext context)
        {
            context.Database.Migrate(); 

          
            if (!context.Persons.Any())
            {
                var testPersons = new List<Person>
            {
                new Person { Id = Guid.NewGuid(), FirstName = "John", LastName = "Doe" },
                new Person { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith" },
                new Person { Id = Guid.NewGuid(), FirstName = "Bob", LastName = "Johnson" }
            };

                context.Persons.AddRange(testPersons);
                context.SaveChanges();
            }
        }
    }
}
