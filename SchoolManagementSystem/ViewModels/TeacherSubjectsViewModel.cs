using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.ViewModels
{
    public class TeacherSubjectsViewModel
    {        
        public string? TeacherId { get; set; }
        public virtual Teacher? Teacher { get; set; }
        public virtual string? SubjectCategoryId { get; set; }
        public virtual SubjectCategory? SubjectCategory { get; set; }
        public virtual List<Subject>? Subjects { get; set; }

    }
}
