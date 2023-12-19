using Microsoft.EntityFrameworkCore;
using SmartSchool.Students.Domain.Models;

namespace SmartSchool.Students.Data.Migrations
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Relative> Relatives { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Program).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
