using StudentPerformancePortal.Models;
using System.ComponentModel.DataAnnotations;

namespace StudentPerformancePortal.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required]
        [StringLength(20)]
        public string StudentNumber { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Phone]
        public string? Phone { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        public string? Gender { get; set; }

        public int DepartmentId { get; set; }

        public int AdmissionYear { get; set; }

        // Navigation property
        public Department? Department { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

        public ICollection<Mark> Marks { get; set; } = new List<Mark>();

        public ICollection<Attendance> AttendanceRecords { get; set; } = new List<Attendance>();
    }
}