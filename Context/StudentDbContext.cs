using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StudentMarks.Model;

namespace StudentMarks.Context
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {

        }

        public DbSet<Student> students { get; set; }

        public DbSet<Subject> subjects { get; set; }
    }
}
