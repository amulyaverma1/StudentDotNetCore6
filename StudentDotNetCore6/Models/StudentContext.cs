using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace StudentDotNetCore6.Models
{
    public class StudentContext :IdentityDbContext
    { 
       
        public StudentContext(DbContextOptions<StudentContext> options):base(options)
        {
            //Options = options;
        }

        //public DbContextOptions<StudentContext> Options { get; }

        public DbSet<Student> Students { get; set; }


    }
}
