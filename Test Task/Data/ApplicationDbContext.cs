using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Test_Task.Models;

namespace Test_Task.Data
{
    public class ApplicationDbContext : DbContext
    {
      
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                    : base(options){ }

        public DbSet<Person> Persons { get; set; }





    }
}
