using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ApplicationUserConfigurations:IEntityTypeConfiguration<ApplicationUser>
    {
        

        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder
            .Property(i => i.DOB)
            .HasColumnName("Date Of Birth")
            .HasColumnType("date");
            
            
            builder
            .Property(i=>i.IsDeleted)
            .HasDefaultValue(false);

        }
    }

