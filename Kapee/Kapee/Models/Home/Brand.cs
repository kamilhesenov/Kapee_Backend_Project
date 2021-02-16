using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Kapee.Models.Home
{
    public class Brand
    {
        public int Id { get; set; }

        public string Photo { get; set; }

        [NotMapped]
        public IFormFile Upload { get; set; }
    }
}
