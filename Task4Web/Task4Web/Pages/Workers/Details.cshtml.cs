using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Task4Web.Models;

namespace Task4Web.Pages.Workers
{
    public class DetailsModel : PageModel
    {
        private readonly EffectiveWorkerContext _context;

        public DetailsModel(EffectiveWorkerContext context)
        {
            _context = context;
        }

        public Worker Worker { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Worker = await _context.Workers.FirstOrDefaultAsync(m => m.Id == id);
            Worker = await _context.Workers
                        .Include(s => s.Enrollments)
                            .ThenInclude(e => e.Project)
                        .AsNoTracking()
                        .FirstOrDefaultAsync(m => m.Id == id);

            if (Worker == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
