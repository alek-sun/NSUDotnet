using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Task4Web.Models;

namespace Task4Web.Pages.Projects
{
    public class CreateModel : PageModel
    {
        private readonly EffectiveWorkerContext _context;

        public CreateModel(EffectiveWorkerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Project Project { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _context.Projects.AddAsync(Project);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}