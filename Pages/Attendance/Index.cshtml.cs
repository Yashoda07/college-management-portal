using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentPerformancePortal.Data;
using StudentPerformancePortal.Models;

namespace StudentPerformancePortal.Pages.Attendance
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<StudentPerformancePortal.Models.Attendance> AttendanceRecords { get; set; } = new List<StudentPerformancePortal.Models.Attendance>();

        public async Task OnGetAsync()
        {
            AttendanceRecords = await _context.Attendance
                .Include(a => a.Student)
                .Include(a => a.Course)
                .OrderByDescending(a => a.AttendanceDate)
                .ToListAsync();
        }
    }
}
