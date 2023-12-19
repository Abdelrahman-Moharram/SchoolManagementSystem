using System.ComponentModel;

namespace SchoolManagementSystem.Models
{
    public class Lecture
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? Name { get; set; }

        public DateTime DateTime { get; set; }
        public string? subjectId { get; set; }
        public virtual Subject? Subject { get; set; }

        public string? ClassroomId { get; set; }
        public virtual Classroom? Classroom { get; set; }


        public string? TeacherId { get; set; }
        public virtual Teacher? Teacher { get; set; }

        public string? SubjectClassroomTeacherId {get; set;}
        public virtual SubjectClassroomTeacher? SubjectClassroomTeacher {get; set;}

        public virtual List<LecturePost>? Posts { get; set; }

        public bool? IsDeleted { get; set; }

    }
}
