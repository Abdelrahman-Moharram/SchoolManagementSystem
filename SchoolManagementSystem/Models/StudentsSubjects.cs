using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models
{
    public class StudentsSubjects
    {
        public string Id {get; set;} = Guid.NewGuid().ToString();
        public virtual List<Student>? Students {get; set;}
        public virtual List<Subject>? Subjects {get; set;}
        public bool IsDeleted { get; set; }

    }
}