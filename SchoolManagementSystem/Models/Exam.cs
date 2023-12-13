namespace SchoolManagementSystem.Models
{
    public class Exam
    {
        public string? Id { get; set; } = Guid.NewGuid().ToString();
        public string? Title { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }

        public decimal? Grade { get; set; }
        public decimal? MinGrade { get; set; }

        public virtual Teacher? Teacher { get; set; }
        public bool IsDeleted { get; set; }

    }
}
