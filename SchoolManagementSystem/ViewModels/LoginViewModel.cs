using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.ViewModels
{
    [Keyless]
    public class LoginViewModel
    {
        

        [Required, MinLength(2), Key]
        public string UserName { get; set; }
        public bool RemeberMe { get; set; }

        [DataType(DataType.Password), MinLength(2)]
        public string Password { get; set; }
    }
}
