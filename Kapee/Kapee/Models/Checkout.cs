using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Kapee.Models
{
    public class Checkout
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public List<ProductCheckout> ProductCheckouts { get; set; }
    }
}
