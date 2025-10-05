using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TeamAlpha.Data;
using TeamAlpha.Models;

namespace TeamAlpha.Pages.Phases
{
    public class IndexModel : PageModel
    {
        private readonly TeamAlpha.Data.ApplicationDbContext _context;

        public IndexModel(TeamAlpha.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Phase> Phase { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Phase = await _context.Phase
                .Include(p => p.Project).ToListAsync();
        }
    }
}
