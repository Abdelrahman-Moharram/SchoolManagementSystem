
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Configurations
{
    public class TeacherConfigurations:IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.Property(i => i.Salary).HasColumnType("money");
            builder
            .Property(i => i.IsDeleted)
            .HasDefaultValue(false);
            builder
                .HasMany(i => i.Subjects)
                .WithMany(i => i.Teacher);
        }
    }

}