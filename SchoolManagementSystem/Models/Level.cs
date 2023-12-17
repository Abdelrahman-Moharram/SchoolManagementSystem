using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models
{
    public class Level
    {
        public string Id {get; set;} = Guid.NewGuid().ToString();

        public string? Name {get; set;}

        public virtual List<Classroom>? Classrooms { get; set;}
        public virtual List<Subject>? subjects { get; set; }
        public virtual List<Student>? Students { get; set; }
        public bool IsDeleted { get; set; }

    }
}