using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Data;
using ContosoUniversity.Models;
using System.Threading.Tasks;

namespace ContosoUniversity.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly SchoolContext _context;

        public CreateModel(SchoolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Students.Add(Student);
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }
                return Page();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed.
                ModelState.AddModelError("", "An error occurred while saving the data.");
                return Page();
            }
        }

    }
}
