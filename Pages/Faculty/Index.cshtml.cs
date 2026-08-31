using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentPerformancePortal.Data;
using StudentPerformancePortal.Models;

namespace StudentPerformancePortal.Pages.Faculty
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<StudentPerformancePortal.Models.Faculty> Faculty { get; set; } = new List<StudentPerformancePortal.Models.Faculty>();

        public async Task OnGetAsync()
        {
            Faculty = await _context.Faculty
                .Include(f => f.Department)
                .OrderBy(f => f.FacultyName)
                .ToListAsync();
        }
    }
}