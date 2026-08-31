using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentPerformancePortal.Data;

namespace StudentPerformancePortal.Pages
{
    public class DashboardModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DashboardModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public int TotalStudents { get; set; }
        public int TotalFaculty { get; set; }
        public int TotalCourses { get; set; }
        public int TotalDepartments { get; set; }

        public decimal AverageMarks { get; set; }
        public decimal AttendancePercentage { get; set; }
        public int AtRiskStudents { get; set; }

        public async Task OnGetAsync()
        {
            TotalStudents = await _context.Students.CountAsync();
            TotalFaculty = await _context.Faculty.CountAsync();
            TotalCourses = await _context.Courses.CountAsync();
            TotalDepartments = await _context.Departments.CountAsync();

            var marks = await _context.Marks.ToListAsync();

            if (marks.Any())
            {
                AverageMarks = Math.Round(
                    marks.Average(m =>
                        (m.MarksObtained / m.MaximumMarks) * 100), 1);
            }

            var attendance = await _context.Attendance.ToListAsync();

            if (attendance.Any())
            {
                AttendancePercentage = Math.Round(
                    attendance.Count(a => a.Status == "Present")
                    * 100m / attendance.Count, 1);
            }

            var studentAttendance = attendance
                .GroupBy(a => a.StudentId)
                .Select(g => new
                {
                    StudentId = g.Key,
                    Attendance = g.Count(a => a.Status == "Present")
                                 * 100m / g.Count()
                })
                .ToList();

            AtRiskStudents = studentAttendance
                .Count(a => a.Attendance < 75);
        }
    }
}