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
    public class DetailsModel : PageModel
    {
        private readonly TeamAlpha.Data.ApplicationDbContext _context;

        public DetailsModel(TeamAlpha.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Phase Phase { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phase = await _context.Phase.FirstOrDefaultAsync(m => m.PhaseId == id);
            if (phase == null)
            {
                return NotFound();
            }
            else
            {
                Phase = phase;
            }
            return Page();
        }
    }
}
