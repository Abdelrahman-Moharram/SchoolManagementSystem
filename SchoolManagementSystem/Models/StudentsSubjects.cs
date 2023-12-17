using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models
{
    public class StudentsSubjects
    {
        public string Id {get; set;} = Guid.NewGuid().ToString();
        public string? StudentId {get; set;}
        public virtual Student? Student {get; set;}
        public string? SubjectId {get; set;}
        public virtual Subject? Subject { get; set;}
        public virtual decimal TotalGrade {get; set; }
        public bool IsDeleted { get; set; }
        
    }
}