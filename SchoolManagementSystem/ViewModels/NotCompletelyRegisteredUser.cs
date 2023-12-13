using System.Runtime.CompilerServices;

namespace SchoolManagementSystem.ViewModels
{
    public class NotCompletelyRegisteredUser
    {
            public string Id { get; set; }
            public string? UserName { get; set; }
            public string? Image { get; set; }
            public bool? IsDone { get; set; }
            public string? Role { get; set; }
            public DateTime DateTime { get; set; }

    }
}
