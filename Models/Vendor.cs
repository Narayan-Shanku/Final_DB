using System.ComponentModel.DataAnnotations;

namespace TeamAlpha.Models
{
    public class Vendor
    {
        public int VendorId { get; set; }

        [Required, StringLength(100)]
        public string? Name { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [Phone]
        public string? Phone { get; set; }

        [Display(Name = "Service / Product Type")]
        public string? ServiceType { get; set; } // e.g., Cement, Electrical Supplies, Glass

        [Display(Name = "Location")]
        public string? Location { get; set; }

        [Display(Name = "Rating (1–5)")]
        public double? Rating { get; set; }

        public ICollection<ProjectVendor>? ProjectVendors { get; set; }
    }
}
