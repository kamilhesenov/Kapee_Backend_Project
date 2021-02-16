using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Kapee.Models.Header_Footer
{
    public class HeaderLogo
    {
        public int Id { get; set; }

        public string MainPhoto { get; set; }

        [NotMapped]
        public IFormFile MainUpload { get; set; }

        public string SecondPhoto { get; set; }

        [NotMapped]
        public IFormFile SecondUpload { get; set; }
    }
}
