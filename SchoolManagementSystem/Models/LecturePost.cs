using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Models
{
    public class LecturePost
    {

        public string Id { get; set; } = Guid.NewGuid().ToString();


        public string? Text { get; set; }
        public string? File { get; set; }
        public DateTime DateTime { get; set; }

        public string? LectureId { get; set; }
        [ForeignKey(nameof(LectureId))]
        public virtual Lecture? Lecture { get; set; }

        public string? UserId { get; set; }
        public virtual ApplicationUser? User { get; set; }
        public bool? IsDeleted { get; set; }

    }
}
