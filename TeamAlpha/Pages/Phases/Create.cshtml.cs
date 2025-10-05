using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TeamAlpha.Data;
using TeamAlpha.Models;

namespace TeamAlpha.Pages.Phases
{
    public class CreateModel : PageModel
    {
        private readonly TeamAlpha.Data.ApplicationDbContext _context;

        public CreateModel(TeamAlpha.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ProjectId"] = new SelectList(_context.Set<Project>(), "ProjectId", "Title");
            return Page();
        }

        [BindProperty]
        public Phase Phase { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Phase.Add(Phase);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
