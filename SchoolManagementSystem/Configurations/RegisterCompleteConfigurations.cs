using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Configurations
{
    public class RegisterCompleteConfigurations
    {
        public void Configure(EntityTypeBuilder<RegisterComplete> builder)
        {
            builder
            .Property(i => i.DateTime).HasDefaultValueSql("getdate()");


            builder
            .Property(i => i.IsDeleted)
            .HasDefaultValue(false);
            
            builder
            .Property(i => i.IsDone)
            .HasDefaultValue(false);
            
        }
    }
}
