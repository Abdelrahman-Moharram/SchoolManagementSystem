
namespace SchoolManagementSystem.Models
{
    public class Teacher
    {
        public string Id {get; set;} = Guid.NewGuid().ToString();

        public decimal Salary { get; set; }
        
        public string? UserId { get; set; }
        public virtual ApplicationUser? User { get; set; }

        public string? subjectCategoryId {get; set;}
        public virtual SubjectCategory? subjectCategory {get; set;}

        public virtual List<Subject>? Subjects { get; set; }
        public virtual List<Classroom>? Classrooms { get; set; }
        public virtual List<SubjectClassroomTeacher>? subjectClassroomTeacher { get; set;}
        public bool IsDeleted { get; set; }

    }
}