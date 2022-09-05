using Microsoft.EntityFrameworkCore;
using WebApi_01_DataWithEntityFramework_CodeFirst.Models;

namespace WebApi_01_DataWithEntityFramework_CodeFirst.Data
{
    public class PersonDbContext : DbContext
    {
        //public PersonDbContext()
        //{
        //}

        public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer();
            }
        }
    }
}
