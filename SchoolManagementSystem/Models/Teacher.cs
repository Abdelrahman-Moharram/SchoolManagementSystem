using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models
{
    public class Teacher
    {
        public string Id {get; set;} = Guid.NewGuid().ToString();

        public decimal Salary { get; set; }
        
        public string? UserId { get; set; }
        public virtual ApplicationUser? User { get; set; }
        public virtual List<Subject>? Subjects { get; set; }
        public virtual List<Classroom>? Classrooms { get; set; }
        public bool IsDeleted { get; set; }


    }
}