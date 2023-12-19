
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Configurations
{
    public class SubjectConfigurations:IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.Property(i => i.Grade).HasColumnType("decimal(18, 2)");
            builder
            .Property(i => i.IsDeleted)
            .HasDefaultValue(false);


            

            builder
                .HasMany(i => i.Classes)
                .WithMany(i => i.Subjects)
                /*.UsingEntity<SubjectClassroomTeacher>(
                    i => i.HasOne(s => s.classroom).WithMany().HasForeignKey(i => i.ClassroomId),
                    i => i.HasOne(s => s.subject).WithMany().HasForeignKey(i => i.SubjectId),
                    i => i.HasOne(s => s.Teacher).WithMany().HasForeignKey(i => i.TeacherId)
                )*/
                ;
        }
    }

}