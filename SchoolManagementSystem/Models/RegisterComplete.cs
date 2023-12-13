namespace SchoolManagementSystem.Models
{
    public class RegisterComplete
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? UserId { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsDone { get; set; }
    }
}
