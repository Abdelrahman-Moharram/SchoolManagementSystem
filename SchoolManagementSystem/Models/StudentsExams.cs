using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models
{
    public class StudentsExams
    {
        public string Id {get; set;} = Guid.NewGuid().ToString();
        public virtual List<Student>? Students {get; set;}
        public virtual List<Exam>? Exams {get; set;}
        public virtual List<Subject>? Subjects {get; set;}
        
        public decimal degree {get; set;}
        public bool IsDeleted {  get; set; }

    }
}