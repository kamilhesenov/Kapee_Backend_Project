using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Kapee.Models.ViewModel
{
    public class CheckoutViewModel
    {
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string Address { get; set; }

        [Required]
        [MaxLength(100)]
        public string Phone { get; set; }

        public IEnumerable<BasketViewModel> BasketViewModels { get; set; }
    }
}
