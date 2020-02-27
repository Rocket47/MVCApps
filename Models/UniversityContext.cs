using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MVCApps.Models
{
    public class UniversityContext : DbContext
    {
        public DbSet<Course> Courses {get; set; }
        public DbSet<Group> Groups {get; set; }
        public DbSet<Student> Students {get; set; }

        public UniversityContext(DbContextOptions<UniversityContext> options) : base(options)
        {
            Database.EnsureCreated();           
        }
    }
}