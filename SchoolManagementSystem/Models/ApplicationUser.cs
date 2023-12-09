using Microsoft.AspNetCore.Identity;

namespace SchoolManagementSystem.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string? Image {  get; set; }

        public DateTime? DOB { get; set; }

        public bool IsDeleted {  get; set; }

    }
}
