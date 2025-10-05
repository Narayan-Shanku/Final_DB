using System.ComponentModel.DataAnnotations;

namespace TeamAlpha.Models
{
    public class Contractor
    {
        public int ContractorId { get; set; }

        [Required, StringLength(100)]
        public required string Name { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [Phone]
        public string? Phone { get; set; }

        [StringLength(100)]
        public string? Specialty { get; set; } // e.g., Structural, Electrical, Design

        [StringLength(100)]
        public string? Company { get; set; }

        [Display(Name = "Experience (years)")]
        public int? ExperienceYears { get; set; }

        public ICollection<ProjectContractor>? ProjectContractors { get; set; }
    }
}
