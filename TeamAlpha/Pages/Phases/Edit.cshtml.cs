using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TeamAlpha.Data;
using TeamAlpha.Models;

namespace TeamAlpha.Pages.Phases
{
    public class EditModel : PageModel
    {
        private readonly TeamAlpha.Data.ApplicationDbContext _context;

        public EditModel(TeamAlpha.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Phase Phase { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phase =  await _context.Phase.FirstOrDefaultAsync(m => m.PhaseId == id);
            if (phase == null)
            {
                return NotFound();
            }
            Phase = phase;
           ViewData["ProjectId"] = new SelectList(_context.Set<Project>(), "ProjectId", "Title");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Phase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhaseExists(Phase.PhaseId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PhaseExists(int id)
        {
            return _context.Phase.Any(e => e.PhaseId == id);
        }
    }
}
