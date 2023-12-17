using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.ViewModels
{
    public class AdminListPropertiesViewModel
    {
        public int RegistersCount {get; set;}
        public int RegistersCompleted {get; set;}
        public int RegistersNotCompleted { get; set; }
    }
}