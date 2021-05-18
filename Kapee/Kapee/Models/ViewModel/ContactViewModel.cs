using Kapee.Models.Header_Footer;
using System.ComponentModel.DataAnnotations;


namespace Kapee.Models.ViewModel
{
    public class ContactViewModel
    {

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, MaxLength(600)]
        public string Message { get; set; }

        public Setting Setting { get; set; }
    }
}
