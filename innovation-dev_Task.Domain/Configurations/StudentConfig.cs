using innovation_dev_Task.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ToDoTask.Domain.Configurations
{
    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(s => s.DateOfBirth)
                .IsRequired();


            builder.Property(s => s.Email)
                .HasMaxLength(40)
                .IsRequired(false);

            builder.Property(s => s.Address)
                .HasMaxLength(100);

            builder.HasMany(s => s.Subjects)
                .WithMany(s => s.Students);
               
        }
    }

}
