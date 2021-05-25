using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kapee.Models.Home
{
    public class News
    {
        public int Id { get; set; }

        [Required, MaxLength(250)]
        public string Title { get; set; }

        [Required, MaxLength(200)]
        public string Content { get; set; }

        [Required, MaxLength(100)]
        public string AddedBy { get; set; }

        [Required, Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }

        [Required, MaxLength(500)]
        public string Description { get; set; }

        [MaxLength(200)]
        public string? Link { get; set; }

        public string Photo { get; set; }

        [NotMapped]
        public IFormFile Upload { get; set; }
    }
}
