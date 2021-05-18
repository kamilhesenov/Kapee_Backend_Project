using System.ComponentModel.DataAnnotations;


namespace Kapee.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
