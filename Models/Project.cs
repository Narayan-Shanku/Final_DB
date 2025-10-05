using System.ComponentModel.DataAnnotations;

namespace TeamAlpha.Models
{
    public class Project
    {
        public int ProjectId { get; set; }

        [Required, StringLength(100)]
        public string? Title { get; set; } // e.g., “Dream Home”

        public string? Description { get; set; }

        [Display(Name = "Project Type")]
        public string? ProjectType { get; set; } // From inquiry (Residential, Commercial...)

        [Display(Name = "Area Size (sqft)")]
        public decimal? AreaSize { get; set; }

        [Display(Name = "Style / Theme")]
        public string? Style { get; set; }

        [Display(Name = "Estimated Budget")]
        public decimal? EstimatedBudget { get; set; }

        [Display(Name = "Current Status")]
        public string Status { get; set; } = "Planning"; // Planning, Ongoing, Completed, OnHold

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Location")]
        public string? Location { get; set; }

        // Foreign key (Project belongs to a Customer)
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

        // Relationships
        public ICollection<Phase>? Phases { get; set; }
        public ICollection<ProjectContractor>? ProjectContractors { get; set; }
        public ICollection<ProjectVendor>? ProjectVendors { get; set; }
    }
}
