using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentPerformancePortal.Data;
using StudentPerformancePortal.Models;

namespace StudentPerformancePortal.Pages.Students
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Student Student { get; set; } = new();

        public SelectList Departments { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();

            var student = await _context.Students.FindAsync(id);

            if (student == null)
                return NotFound();

            Student = student;

            await LoadDepartmentsAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await LoadDepartmentsAsync();
                return Page();
            }

            _context.Attach(Student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await StudentExists(Student.StudentId))
                    return NotFound();

                throw;
            }

            return RedirectToPage("./Index");
        }

        private async Task LoadDepartmentsAsync()
        {
            Departments = new SelectList(
                await _context.Departments
                    .OrderBy(d => d.DepartmentName)
                    .ToListAsync(),
                "DepartmentId",
                "DepartmentName"
            );
        }

        private async Task<bool> StudentExists(int id)
        {
            return await _context.Students.AnyAsync(s => s.StudentId == id);
        }
    }
}