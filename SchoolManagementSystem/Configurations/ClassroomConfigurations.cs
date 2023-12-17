
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Configurations
{
    public class ClassroomConfigurations:IEntityTypeConfiguration<Classroom>
    {
        public void Configure(EntityTypeBuilder<Classroom> builder)
        {
            builder
            .Property(i => i.IsDeleted)
            .HasDefaultValue(false);
            builder
                .HasMany(i => i.Teachers)
                .WithMany(i => i.Classrooms);
        }
    }
}