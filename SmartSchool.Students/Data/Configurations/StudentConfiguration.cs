using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartSchool.Students.Domain.Models;

namespace SmartSchool.Students.Data.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Ignore(s => s.Age);
            builder.Property(s => s.FirstName)
                .IsRequired()
                .HasMaxLength(70);
            builder.Property(s => s.LastName)
                .IsRequired()
                .HasMaxLength (70);
        }
    }
}
