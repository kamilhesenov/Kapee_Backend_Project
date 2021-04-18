using System.ComponentModel.DataAnnotations;


namespace Kapee.Models
{
    public class Vender
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string ShopName { get; set; }
        public string ShopDescription { get; set; }
        public string ShopLogoUrl { get; set; }
        public bool Status { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
