using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentPerformancePortal.Data;

namespace StudentPerformancePortal.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public int TotalStudents { get; set; }
        public int TotalCourses { get; set; }
        public int TotalDepartments { get; set; }

        public async Task OnGetAsync()
        {
            TotalStudents = await _context.Students.CountAsync();
            TotalCourses = await _context.Courses.CountAsync();
            TotalDepartments = await _context.Departments.CountAsync();
        }
    }
}
