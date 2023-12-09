using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.ViewModels
{
    public class RegisterViewModel
    {

        [Required, MinLength(2), Key, DataType(DataType.Text)]
        [Remote("IsUniqueUserName", "Account", ErrorMessage ="This UserName already exists")]
        public string UserName { get; set; }

        [DataType(DataType.EmailAddress), Required]
        [Remote("IsUniqueEmail", "Account", ErrorMessage = "This Email already exists")]

        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string? Image {  get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password"), Column(name:"Confirm Password")]
        [DataType(DataType.Password)]

        public string ConfirmPassword { get; set; }

    }
}
