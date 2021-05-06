using System.ComponentModel.DataAnnotations;


namespace Kapee.Models.ViewModel
{
    public class VenderCreateViewModel
    {
        
        [Required(ErrorMessage = "Please enter your Name!"), MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your Surname!"), MaxLength(100)]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Please enter Shop Name!"), MaxLength(100)]
        public string ShopName { get; set; }

        [Required(ErrorMessage = "Please enter Shop URL!"), MaxLength(200)]
        public string ShopLogoUrl { get; set; }
    
    }
}
