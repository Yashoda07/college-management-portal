using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentPerformancePortal.Data;
using StudentPerformancePortal.Models;

namespace StudentPerformancePortal.Pages.Marks
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Mark> Marks { get; set; } = new List<Mark>();

        public async Task OnGetAsync()
        {
            Marks = await _context.Marks
                .Include(m => m.Student)
                .Include(m => m.Course)
                .OrderByDescending(m => m.MarksObtained)
                .ToListAsync();
        }
    }
}