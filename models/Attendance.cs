using System.ComponentModel.DataAnnotations;

namespace StudentPerformancePortal.Models
{
    public class Attendance
    {
        public int AttendanceId { get; set; }

        public int StudentId { get; set; }

        public int CourseId { get; set; }

        [DataType(DataType.Date)]
        public DateTime AttendanceDate { get; set; }

        [Required]
        public string Status { get; set; } = "Present";

        // Navigation properties
        public Student? Student { get; set; }

        public Course? Course { get; set; }
    }
}