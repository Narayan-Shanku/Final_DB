using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TeamAlpha.Data;
using TeamAlpha.Models;

namespace TeamAlpha.Pages.Testimonials
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // Bind directly to the entity for form submission
        [BindProperty]
        public Testimonial NewTestimonial { get; set; } = new();

        // Data to display on the page
        public IList<Testimonial> Testimonials { get; private set; } = new List<Testimonial>();
        public double AverageRating { get; private set; }
        public int TotalReviews { get; private set; }

        // Called when the page first loads
        public async Task OnGetAsync(CancellationToken ct)
        {
            // Fetch all testimonials ordered by newest first
            Testimonials = await _context.Testimonial
                .OrderByDescending(t => t.CreatedOn)
                .ToListAsync(ct);

            // Calculate totals
            TotalReviews = Testimonials.Count;
            AverageRating = TotalReviews > 0
                ? Math.Round(Testimonials.Average(t => t.Rating), 1)
                : 0.0;
        }

        // Called when the form is submitted
        public async Task<IActionResult> OnPostAsync(CancellationToken ct)
        {
            if (!ModelState.IsValid)
            {
                await OnGetAsync(ct);
                return Page();
            }


            NewTestimonial.CreatedOn = DateTime.UtcNow;


            _context.Testimonial.Add(NewTestimonial);
            await _context.SaveChangesAsync(ct);


            TempData["Thanks"] = "1";

            return RedirectToPage("./Index");
        }
    }
}