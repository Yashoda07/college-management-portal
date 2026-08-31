using StudentPerformancePortal.Models;
using System.ComponentModel.DataAnnotations;

namespace StudentPerformancePortal.Models
{
    public class Faculty
    {
        public int FacultyId { get; set; }

        [Required]
        [StringLength(100)]
        public string FacultyName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public int DepartmentId { get; set; }

        // Navigation properties
        public Department? Department { get; set; }

        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}