using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Task4Web.Models;

namespace Task4Web.Pages.Workers
{
    public class IndexModel : PageModel
    {
        private readonly Task4Web.Models.EffectiveWorkerContext _context;

        public IndexModel(Task4Web.Models.EffectiveWorkerContext context)
        {
            _context = context;
        }

        public IList<Worker> Worker { get;set; }

        public async Task OnGetAsync()
        {
            Worker = await _context.Workers.ToListAsync();
        }
    }
}
