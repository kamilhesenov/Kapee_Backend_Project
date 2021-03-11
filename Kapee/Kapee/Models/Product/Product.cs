using Kapee.Models.Category;
using Kapee.Models.Home;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kapee.Models.Product
{
    public class Product
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public int? BrandId { get; set; }

       [Required, MaxLength(200)]
        public string Name { get; set; }

        public float? StarCount { get; set; }

        public byte? RatingCount { get; set; }

        [Required, Column(TypeName = "money")]
        public decimal Price { get; set; }

        [MaxLength(100)]
        public string StarColor { get; set; }

        [MaxLength(100)]
        public string ProgressColor { get; set; }

        [MaxLength(100)]
        public string OnSale { get; set; }

        [Required, Column(TypeName = "ntext")]
        public string Detail { get; set; }

        [Required, Column(TypeName = "ntext")]
        public string Description { get; set; }

        [Required]
        public bool IsFeatured { get; set; }

        [Required]
        public bool IsSale { get; set; }

        [Required]
        public bool IsPrize { get; set; }

        public string HoverPhoto { get; set; }

        [NotMapped]
        public IFormFile HoverUpload { get; set; }

        [NotMapped]
        public IFormFile Upload { get; set; }

        [NotMapped]
        public IFormFile BigSizePhotoUpload { get; set; }

        [NotMapped]
        public IFormFile SmallSizePhotoUpload { get; set; }
        public Category.Category Category { get; set; }
        public Brand Brand { get; set; }
        public List<ProductGallery> ProductGalleries { get; set; }
        public List<ProductFeatured> ProductFeatureds { get; set; }
        public List<BigSizePhoto> BigSizePhotos { get; set; }
        public List<SmallSizePhoto> SmallSizePhotos { get; set; }
        public List<ProductPrize> Prizes { get; set; }
        public List<SubCategory> SubCategories { get; set; }
        public List<ProductColor> ProductColors { get; set; }
        public List<ProductSize> ProductSizes { get; set; }
    }
}
