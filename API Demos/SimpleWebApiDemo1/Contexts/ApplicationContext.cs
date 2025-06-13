using Microsoft.EntityFrameworkCore;
using SimpleWebApiDemo1.Models;
namespace SimpleWebApiDemo1.contexts
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options) { 

        }
       public DbSet<Course> Courses { get;set; }
        public DbSet<Student> students { get;set; }
    }
}
