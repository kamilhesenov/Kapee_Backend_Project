﻿using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Kapee.Models.Home
{
    public class Category
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public int ProductCount { get; set; }

        [Required, MaxLength(100)]
        public string Photo { get; set; }

        [NotMapped]
        public IFormFile Upload { get; set; }
    }
}