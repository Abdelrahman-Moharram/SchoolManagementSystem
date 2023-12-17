using System.ComponentModel.DataAnnotations;


namespace SchoolManagementSystem.ViewModels
{
    public class StudentUserViewModel
    {
        [Required, Key]
        public string UserId {get; set;}
        [Required]
        public string StudentId {get; set;}
        public string? UserName {get; set;}
        public string? Image {get; set;}

        [DataType(DataType.EmailAddress)]
        public string? Email {get; set;}

        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber {get; set;}
        public string? RoleName {get; set;}
        public string? LevelId { get; set; }
        public string? ClassroomId { get; set;}
        public bool IsDone { get; set;}

    }
}