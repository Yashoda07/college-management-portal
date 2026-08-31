using StudentPerformancePortal.Models;
using System.ComponentModel.DataAnnotations;

namespace StudentPerformancePortal.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        [Required]
        [StringLength(20)]
        public string CourseCode { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string CourseName { get; set; } = string.Empty;

        [Range(1, 10)]
        public int Credits { get; set; }

        public int DepartmentId { get; set; }

        public int FacultyId { get; set; }

        // Navigation properties
        public Department? Department { get; set; }

        public Faculty? Faculty { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

        public ICollection<Mark> Marks { get; set; } = new List<Mark>();

        public ICollection<Attendance> AttendanceRecords { get; set; } = new List<Attendance>();
    }
}