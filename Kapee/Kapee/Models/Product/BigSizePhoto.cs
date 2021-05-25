using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kapee.Models.Product
{
    public class BigSizePhoto
    {
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }
        public string Photo { get; set; }

        [NotMapped]
        public IFormFile Upload { get; set; }
        public Product Product { get; set; }
    }
}
