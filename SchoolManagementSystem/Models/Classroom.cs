using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models
{
    public class Classroom
    {
        public string Id {get; set;} = Guid.NewGuid().ToString();
        public string? Name {get; set;}

        public string? levelId { get; set;}

        public virtual Level? level {get; set;}

        public virtual List<Student>? students {get; set;}
        public virtual List<Teacher>? Teachers {get; set;}
        public virtual List<Subject>? Subjects {get; set;}
        public virtual List<SubjectClassroomTeacher>? subjectClassroomTeacher { get; set;}

        public int capacity {get; set;}

        public bool IsDeleted { get; set; }

    }
}