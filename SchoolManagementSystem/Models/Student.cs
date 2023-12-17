using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models
{
    public class Student
    {
        public string Id {get; set;} = Guid.NewGuid().ToString();
        
        public string? ClassroomId { get; set;}
        public virtual Classroom? Classroom { get; set;}

        public string? LevelId { get; set;}
        public virtual Level? Level { get; set;}
        public string? UserId { get; set;}
        public virtual ApplicationUser? User { get; set;}

        public virtual List<Subject>? Subjects { get; set;}

        public bool IsDeleted {  get; set; }

    }
}