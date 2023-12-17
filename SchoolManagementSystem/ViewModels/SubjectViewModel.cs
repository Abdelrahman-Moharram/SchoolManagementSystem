using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.ViewModels
{
    [Keyless]
    public class SubjectViewModel
    {
        public string? Name { get; set; }
        public decimal? Grade { get; set; }
        public string? subjectCategoryId { get; set; }
        public string? levelId { get; set; }

    }
}
