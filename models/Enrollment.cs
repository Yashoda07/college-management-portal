using System.ComponentModel.DataAnnotations;

namespace StudentPerformancePortal.Models
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }

        public int StudentId { get; set; }

        public int CourseId { get; set; }

        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }

        [Required]
        public string AcademicYear { get; set; } = string.Empty;

        [Range(1, 8)]
        public int Semester { get; set; }

        // Navigation properties
        public Student? Student { get; set; }

        public Course? Course { get; set; }
    }
}