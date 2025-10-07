using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TeamAlpha.Data;
using TeamAlpha.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamAlpha.Pages
{
    public class SearchModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public SearchModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public string Query { get; set; } = string.Empty;

        public List<Project> Projects { get; set; } = new();

        public async Task OnGetAsync()
        {
            if (!string.IsNullOrWhiteSpace(Query))
            {
                string loweredQuery = Query.ToLower();

                Projects = await _context.Project
                    .Where(p =>
                        (p.Title != null && p.Title.ToLower().Contains(loweredQuery)) ||
                        (p.Description != null && p.Description.ToLower().Contains(loweredQuery)) ||
                        (p.ProjectType != null && p.ProjectType.ToLower().Contains(loweredQuery)) ||
                        (p.Style != null && p.Style.ToLower().Contains(loweredQuery)) ||
                        (p.Status != null && p.Status.ToLower().Contains(loweredQuery)) ||
                        (p.Location != null && p.Location.ToLower().Contains(loweredQuery))
                    )
                    .OrderBy(p => p.Title)
                    .ToListAsync();
            }
        }
    }
}