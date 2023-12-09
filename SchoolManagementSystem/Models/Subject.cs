using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models
{
    public class Subject
    {
        public string Id {get; set;} = Guid.NewGuid().ToString();
        public string? Name { get; set;}
        public decimal? Grade { get; set;}

        public string? levelId { get; set;}
        public virtual Level? level { get; set;}

        public virtual List<Student>? students { get; set;}

        public string? TeacherId  { get; set;}
        public virtual Teacher? Teacher { get; set;}

        public virtual List<Exam>? Exams { get; set;}

    }
}