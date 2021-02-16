using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Kapee.Models.Header_Footer
{
    public class FooterLogo
    {
        public int Id { get; set; }

        public string PhotoLogo { get; set; }

        [NotMapped]
        public IFormFile UploadLogo { get; set; }

        public string PhotoCopyright { get; set; }

        [NotMapped]
        public IFormFile UploadCopyright { get; set; }
    }
}
