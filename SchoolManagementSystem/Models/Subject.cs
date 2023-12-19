
namespace SchoolManagementSystem.Models
{
    public class Subject
    {
        public string Id {get; set;} = Guid.NewGuid().ToString();
        public string? Name { get; set;}
        public decimal? Grade { get; set;}
        public bool IsDeleted { get; set; }
        public string? subjectCategoryId {get; set;}
        public virtual SubjectCategory? subjectCategory {get; set;}
        public virtual List<Teacher>? Teacher { get; set;}
        public virtual List<Classroom>? Classes { get; set;}
        public virtual List<SubjectClassroomTeacher>? subjectClassroomTeacher { get; set;}






        public string? levelId { get; set;}
        public virtual Level? level { get; set;}

        public virtual List<Student>? students { get; set;}
        public virtual List<Lecture>? Lectures { get; set;}

        public virtual List<Exam>? Exams { get; set;}

    }
}