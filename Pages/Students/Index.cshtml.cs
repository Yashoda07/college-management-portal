using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentPerformancePortal.Data;
using StudentPerformancePortal.Models;

namespace StudentPerformancePortal.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Student> Students { get; set; } = new List<Student>();

        public async Task OnGetAsync()
        {
            Students = await _context.Students
                .Include(s => s.Department)
                .OrderBy(s => s.StudentNumber)
                .ToListAsync();
        }
    }
}