using System.ComponentModel.DataAnnotations;


namespace Kapee.Models.Header_Footer
{
    public class SocialLink
    {
        public int Id { get; set; }

        [Required, MaxLength(300)]
        public string Facebook { get; set; }

        [Required, MaxLength(300)]
        public string Twitter { get; set; }

        [Required, MaxLength(300)]
        public string Linkedin { get; set; }

        [Required, MaxLength(300)]
        public string Instagram { get; set; }

        [Required, MaxLength(300)]
        public string Flickr { get; set; }

        [Required, MaxLength(300)]
        public string Rss { get; set; }

        [Required, MaxLength(300)]
        public string Youtube { get; set; }
    }
}
