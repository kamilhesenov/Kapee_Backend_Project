using System.ComponentModel.DataAnnotations;


namespace Kapee.Models.Home
{
    public class Info
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Title { get; set; }

        [Required, MaxLength(150)]
        public string Content { get; set; }

        [Required, MaxLength(50)]
        public string Icon { get; set; }
    }
}
