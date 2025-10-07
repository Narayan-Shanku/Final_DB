using System;
using System.ComponentModel.DataAnnotations;

namespace TeamAlpha.Models
{
    public class Testimonial
    {
        public int Id { get; set; }

        [Required, Range(1, 5)]
        public int Rating { get; set; }

        [StringLength(300)]
        public string? Comment { get; set; }

        [StringLength(50)]
        public string? Name { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}