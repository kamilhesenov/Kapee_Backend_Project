using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kapee.Models.Home
{
    public class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        public float? StarCount { get; set; }

        public byte? RatingCount { get; set; }

        [Required, Column(TypeName = "money")]
        public decimal Price { get; set; }

        [MaxLength(100)]
        public string StarColor { get; set; }

        [MaxLength(100)]
        public string OnSale { get; set; }

        [Required, MaxLength(300)]
        public string Description { get; set; }

        [Required]
        public bool IsFeatured { get; set; }

        [Required]
        public bool IsSale { get; set; }

        public string HoverPhoto { get; set; }

        [NotMapped]
        public IFormFile HoverUpload { get; set; }

        [NotMapped]
        public IFormFile Upload { get; set; }
        public Category Category { get; set; }
        public List<ProductGallery> ProductGalleries { get; set; }
        public List<ProductFeatured> ProductFeatureds { get; set; }
    }
}
