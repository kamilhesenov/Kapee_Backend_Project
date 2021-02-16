using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Kapee.Models.Home
{
    public class Testimonial
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string FullName { get; set; }

        [Required, MaxLength(500)]
        public string Content { get; set; }

        [Required, MaxLength(100)]
        public string Position { get; set; }

        [Required]
        public byte Star { get; set; }

        public string Photo { get; set; }

        [NotMapped]
        public IFormFile Upload { get; set; }
    }
}
