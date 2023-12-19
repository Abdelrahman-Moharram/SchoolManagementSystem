namespace SchoolManagementSystem.Models
{
    public class Admin
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public decimal Salary { get; set; }

        public string? UserId { get; set; }
        public virtual ApplicationUser? User { get; set; }
        public bool IsDeleted { get; set; }

    }
}
