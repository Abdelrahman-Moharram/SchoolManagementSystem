using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models
{
    public class SubjectClassroomTeacher
    {
        
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? TeacherId  { get; set;}
        public virtual Teacher? Teacher { get; set;}

        public string? SubjectId  { get; set;}
        public virtual Subject? subject { get; set;}

        public virtual List<Lecture>? Lectures {get; set;}

        public string? ClassroomId  { get; set;}
        public virtual Classroom? classroom { get; set;}

    }
}