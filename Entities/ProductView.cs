namespace WaggyProject.Entities
{
    public class ProductView
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public decimal ProductPrice { get; set; }
        public int Review { get; set; }
        public string ProductImageUrl { get; set; }

    }
}
