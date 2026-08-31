using System.ComponentModel.DataAnnotations;

namespace StudentPerformancePortal.Models
{
    public class Mark
    {
        public int MarkId { get; set; }

        public int StudentId { get; set; }

        public int CourseId { get; set; }

        [Range(0, 1000)]
        public decimal MarksObtained { get; set; }

        [Range(1, 1000)]
        public decimal MaximumMarks { get; set; }

        [Required]
        [StringLength(50)]
        public string ExamType { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime ExamDate { get; set; }

        // Navigation properties
        public Student? Student { get; set; }

        public Course? Course { get; set; }
    }
}