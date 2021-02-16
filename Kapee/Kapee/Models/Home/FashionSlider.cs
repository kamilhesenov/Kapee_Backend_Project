using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kapee.Models.Home
{
    public class FashionSlider
    {
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string Title { get; set; }

        [Required, MaxLength(300)]
        public string Content { get; set; }

        [Required, MaxLength(500)]
        public string Description { get; set; }

        [MaxLength(200)]
        public string? Link { get; set; }

        [MaxLength(50)]
        public string? TextStyleLeft { get; set; }

        [MaxLength(50)]
        public string? TextStyleRight { get; set; }

        [Required]
        public bool Status { get; set; }

        public string Photo { get; set; }

        [NotMapped]
        public IFormFile Upload { get; set; }
    }
}
