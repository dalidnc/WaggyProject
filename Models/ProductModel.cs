using WaggyProject.Entities;

namespace WaggyProject.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Review { get; set; }
        public decimal ProductPrice { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public IFormFile ProductImageUrl { get; set; }

        public string CurrentImageUrl { get; set; }
    }

}
