using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models
{
    public class SubjectCategory
    {
        public string Id {get; set;} = Guid.NewGuid().ToString();
        public string? Name {get; set;}
    }
}