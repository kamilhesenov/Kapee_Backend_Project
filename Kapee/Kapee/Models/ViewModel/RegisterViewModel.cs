using System.ComponentModel.DataAnnotations;


namespace Kapee.Models.ViewModel
{
    public class RegisterViewModel
    {
        

        [Required(ErrorMessage ="Please enter your UserName!")]
        [MaxLength(100)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter your Email!")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your Password!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        
    }
}
