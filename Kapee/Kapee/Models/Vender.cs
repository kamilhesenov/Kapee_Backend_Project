using System.ComponentModel.DataAnnotations;


namespace Kapee.Models
{
    public class Vender
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required, MaxLength(100)]
        public string Surname { get; set; }

        [Required, MaxLength(150)]
        public string Email { get; set; }

        [Required, MaxLength(100)]
        public string Password { get; set; }

        [Required, MaxLength(100)]
        public string Phone { get; set; }

        [Required, MaxLength(100)]
        public string ShopName { get; set; }

        [Required, MaxLength(500)]
        public string ShopDescription { get; set; }

        [Required, MaxLength(200)]
        public string ShopLogoUrl { get; set; }

        [Required]
        public bool Status { get; set; }
    }
}
