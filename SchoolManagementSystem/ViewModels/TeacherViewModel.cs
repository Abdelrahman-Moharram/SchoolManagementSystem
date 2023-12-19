
using SchoolManagementSystem.Models;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.ViewModels
{
    public class TeacherViewModel
    {
        [Required, Key]
        public string UserId {get; set;}
        [Required]
        public string TeacherId {get; set;}
        public string? UserName {get; set;}
        public string? Image {get; set;}
        [DataType(DataType.EmailAddress)]
        public string? Email {get; set;}

        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber {get; set;}
        public string? RoleName {get; set;}
        public decimal Salary { get; set;}
        public bool IsDone { get; set;}
        public string? subjectCategoryId { get; set; }

    }
}