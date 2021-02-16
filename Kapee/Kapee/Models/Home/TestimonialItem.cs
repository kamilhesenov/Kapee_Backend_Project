using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Kapee.Models.Home
{
    public class TestimonialItem
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Title { get; set; }

        public string Photo { get; set; }

        [NotMapped]
        public IFormFile Upload { get; set; }
    }
}
