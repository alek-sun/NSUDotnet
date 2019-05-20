using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Task4Web.Models;

namespace Task4Web.Pages.Projects
{
    public class IndexModel : PageModel
    {
        private readonly Task4Web.Models.EffectiveWorkerContext _context;

        public IndexModel(Task4Web.Models.EffectiveWorkerContext context)
        {
            _context = context;
        }

        public IList<Project> Project { get;set; }

        public async Task OnGetAsync()
        {
            Project = await _context.Projects.ToListAsync();
        }
    }
}
