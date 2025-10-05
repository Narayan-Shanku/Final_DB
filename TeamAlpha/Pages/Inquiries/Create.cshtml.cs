using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TeamAlpha.Data;
using TeamAlpha.Models;

namespace TeamAlpha.Pages.Inquiries
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
        ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "Name");
            return Page();
        }

        [BindProperty]
        public Inquiry Inquiry { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Inquiry.Add(Inquiry);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
