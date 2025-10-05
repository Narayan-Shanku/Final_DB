using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TeamAlpha.Data;
using TeamAlpha.Models;

namespace TeamAlpha.Pages.Vendors
{
    public class DetailsModel : PageModel
    {
        private readonly TeamAlpha.Data.ApplicationDbContext _context;

        public DetailsModel(TeamAlpha.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Vendor Vendor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendor = await _context.Vendor.FirstOrDefaultAsync(m => m.VendorId == id);
            if (vendor == null)
            {
                return NotFound();
            }
            else
            {
                Vendor = vendor;
            }
            return Page();
        }
    }
}
