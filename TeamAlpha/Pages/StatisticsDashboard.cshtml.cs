using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using TeamAlpha.Models;
using System;
using System.Linq;

namespace TeamAlpha.Pages
{
    public class StatisticsDashboardModel : PageModel
    {
        // Properties used by the frontend view (StatisticsDashboard.cshtml)
        public int TotalProjectsCount { get; set; }
        public int CompletedProjectsCount { get; set; }
        public int TotalCustomersCount { get; set; }
        public int NewInquiriesCount { get; set; }
        public int TotalContractorsCount { get; set; }
        public int TotalVendorsCount { get; set; }
        public List<Project> MostRecentProjects { get; set; } = new List<Project>();
        public List<Phase> TopActivePhases { get; set; } = new List<Phase>();

        // New property for simulated chart data
        public List<int> MonthlyProjectStarts { get; set; } = new List<int>();
        public double ProjectTrendChange { get; set; } // Simulated percentage change

        public void OnGet()
        {
            // --- HARDCODED STATIC DATA WITH SIMULATED DYNAMICS ---

            // 1. Static Card Counts (Slightly randomized to look like a snapshot)
            TotalProjectsCount = 192; // Slightly changed value
            CompletedProjectsCount = 108; // Slightly changed value
            TotalCustomersCount = 615; // Slightly changed value
            NewInquiriesCount = 27;
            TotalContractorsCount = 158;
            TotalVendorsCount = 78;
            ProjectTrendChange = 4.7; // Simulated positive growth

            // 2. Simulated Monthly Project Starts Data (for Line Chart)
            // Simulating 6 months of data
            MonthlyProjectStarts = new List<int> { 15, 22, 18, 25, 30, 32 };


            // 3. Static Project List
            MostRecentProjects = new List<Project>
            {
                new Project { ProjectId = 201, Title = "The Grand Tower Rebuild", Status = "Ongoing", StartDate = DateTime.Now.AddDays(-14), Location = "Manhattan, NY" },
                new Project { ProjectId = 202, Title = "Silicon Valley Data Center", Status = "Pending", StartDate = DateTime.Now.AddDays(-10), Location = "San Jose, CA" },
                new Project { ProjectId = 203, Title = "Coastal Mansion Completion", Status = "Completed", StartDate = DateTime.Now.AddDays(-365), EndDate = DateTime.Now.AddDays(-5), Location = "Malibu, CA" },
                new Project { ProjectId = 204, Title = "Phoenix Luxury Condos", Status = "Ongoing", StartDate = DateTime.Now.AddDays(-28), Location = "Scottsdale, AZ" },
                new Project { ProjectId = 205, Title = "Rural Winery Expansion", Status = "Pending", StartDate = DateTime.Now.AddDays(-3), Location = "Napa, CA" }
            };

            // 4. Static Active Phases List
            TopActivePhases = new List<Phase>
            {
                new Phase { PhaseId = 1, Name = "Steel Erection (Floor 45)", ProjectId = 201, Status = "Ongoing", Progress = 90 },
                new Phase { PhaseId = 2, Name = "Data Cable Installation", ProjectId = 202, Status = "Ongoing", Progress = 75 },
                new Phase { PhaseId = 3, Name = "Interior Finishing", ProjectId = 203, Status = "Ongoing", Progress = 99 },
                new Phase { PhaseId = 4, Name = "Piping and Plumbing", ProjectId = 204, Status = "Ongoing", Progress = 65 },
                new Phase { PhaseId = 5, Name = "Foundation Curing", ProjectId = 205, Status = "Ongoing", Progress = 50 }
            };

            // --- END HARDCODED STATIC DATA ---
        }
    }
}