using System.ComponentModel.DataAnnotations;


namespace Kapee.Models.Header_Footer
{
    public class Setting
    {
        public int Id { get; set; }

        [Required, MaxLength(200)]
        public string Address { get; set; }

        [Required, MaxLength(100)]
        public string Phone { get; set; }

        [Required, MaxLength(150)]
        public string Email { get; set; }
    }
}
