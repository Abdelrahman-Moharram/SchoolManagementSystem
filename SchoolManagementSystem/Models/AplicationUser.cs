using Microsoft.AspNetCore.Identity;

namespace SchoolManagementSystem.Models
{
    public class AplicationUser:IdentityUser
    {
        public string? Image {  get; set; }

    }
}
