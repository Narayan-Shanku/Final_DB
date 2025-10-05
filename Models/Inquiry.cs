using System.ComponentModel.DataAnnotations;

namespace TeamAlpha.Models
{
    public class Inquiry
    {
        public int InquiryId { get; set; }

        [Required, StringLength(100)]
        public string? Subject { get; set; } // e.g., "Dream Home Inquiry"

        [Required, StringLength(100)]
        public string? Name { get; set; } // Redundant but needed in form submission before login

        [EmailAddress]
        public string? Email { get; set; }

        [Phone]
        public string? Phone { get; set; }

        [Required, StringLength(500)]
        public string? Message { get; set; }

        [Display(Name = "Customer Type")]
        public string? CustomerType { get; set; } // Individual, Business, Corporate

        [Display(Name = "Project Type")]
        public string? ProjectType { get; set; } // Residential, Commercial, Interior, Renovation

        [Display(Name = "Area Size (sqft)")]
        public decimal? AreaSize { get; set; }

        [Display(Name = "Preferred Style / Theme")]
        public string? PreferredStyle { get; set; }

        [Display(Name = "Estimated Budget")]
        public decimal? Budget { get; set; }

        [Display(Name = "Consent Given")]
        public bool Consent { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Now;

        public string Status { get; set; } = "New"; // New, Reviewed, Converted, Closed

        // Foreign Key
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
    }
}
