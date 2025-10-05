using System.ComponentModel.DataAnnotations;

namespace TeamAlpha.Models
{
    public class Phase
    {
        public int PhaseId { get; set; }

        [Required]
        public string? Name { get; set; } // e.g., Design, Foundation, Electrical

        public string? Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        public string Status { get; set; } = "Pending"; // Pending, Ongoing, Completed

        [Display(Name = "Progress (%)")]
        public int Progress { get; set; } // Numeric representation

        // Foreign Key
        public int ProjectId { get; set; }
        public Project? Project { get; set; }
    }
}
