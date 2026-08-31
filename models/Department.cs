using StudentPerformancePortal.Models;
using System.ComponentModel.DataAnnotations;

namespace StudentPerformancePortal.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }

        [Required]
        [StringLength(100)]
        public string DepartmentName { get; set; } = string.Empty;

        // Navigation properties
        public ICollection<Student> Students { get; set; } = new List<Student>();

        public ICollection<Faculty> FacultyMembers { get; set; } = new List<Faculty>();

        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}