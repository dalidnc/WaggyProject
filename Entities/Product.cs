namespace WaggyProject.Entities
{
    public class Product
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public decimal ProductPrice { get; set; }
        public int Review { get; set; }
        public string ProductImageUrl { get; set; }
        public IList<Feature> Features { get; set; }

    }
}
