using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee { ID = 1, DepartmentID = 1, Name = "Vinay" },
                new Employee { ID = 2, DepartmentID = 2, Name = "Hamilton" },
                new Employee { ID = 3, DepartmentID = 3, Name = "Max" }
                );
        }
    }
}
