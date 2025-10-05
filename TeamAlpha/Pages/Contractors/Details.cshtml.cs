using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TeamAlpha.Data;
using TeamAlpha.Models;

namespace TeamAlpha.Pages.Contractors
{
    public class DetailsModel : PageModel
    {
        private readonly TeamAlpha.Data.ApplicationDbContext _context;

        public DetailsModel(TeamAlpha.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Contractor Contractor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contractor = await _context.Contractor.FirstOrDefaultAsync(m => m.ContractorId == id);
            if (contractor == null)
            {
                return NotFound();
            }
            else
            {
                Contractor = contractor;
            }
            return Page();
        }
    }
}
