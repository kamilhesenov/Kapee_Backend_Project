

namespace Kapee.Models.ViewModel
{
    public class BasketViewModel
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public int DbCount { get; set; }
        public decimal ProductTotalPrice { get; set; }
        public int BasketCount { get; set; } = 1;
    }
}
