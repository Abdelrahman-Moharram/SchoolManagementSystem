
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Configurations
{
    public class StudentConfigurations:IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder
            .Property(i => i.IsDeleted)
            .HasDefaultValue(false);

            builder
                .HasMany(i => i.Subjects)
                .WithMany(i => i.students)
                .UsingEntity<StudentsSubjects>(
                j=>
                j.HasOne(i=>i.Subject).WithMany().HasForeignKey(i=>i.SubjectId),

                j=>
                j.HasOne(i=>i.Student).WithMany().HasForeignKey(i=>i.StudentId),

                j =>
                {
                    j.Property(i => i.TotalGrade).HasColumnType("decimal(18,2)").HasDefaultValue("0");
                }
                );

        }
    }

}