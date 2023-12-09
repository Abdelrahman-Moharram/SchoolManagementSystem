
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagementSystem.Models;
namespace SchoolManagementSystem.Configurations
{
    public class ExamConfigurations:IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder.Property(i => i.Grade).HasColumnType("decimal(18, 2)");
            builder.Property(i => i.MinGrade).HasColumnType("decimal(18, 2)");

        }
    }

}