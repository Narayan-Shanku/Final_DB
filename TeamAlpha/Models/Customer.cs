using Microsoft.CodeAnalysis;
using System.ComponentModel.DataAnnotations;

namespace TeamAlpha.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required, StringLength(100)]
        public required string Name { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [Phone]
        public string? Phone { get; set; }

        [StringLength(200)]
        public string? Address { get; set; }

        [Display(Name = "Customer Type")]
        public string? Type { get; set; } // Individual, Business, Corporate, Government

        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; } = DateTime.Now;

        // Relationships
        public ICollection<Project>? Projects { get; set; }
        public ICollection<Inquiry>? Inquiries { get; set; }
    }
}
