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
    public class DeleteModel : PageModel
    {
        private readonly TeamAlpha.Data.ApplicationDbContext _context;

        public DeleteModel(TeamAlpha.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contractor = await _context.Contractor.FindAsync(id);
            if (contractor != null)
            {
                Contractor = contractor;
                _context.Contractor.Remove(Contractor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
