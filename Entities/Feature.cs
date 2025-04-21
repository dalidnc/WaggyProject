namespace WaggyProject.Entities
{
    public class Feature
    {
        public int Id { get; set; }     
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Review { get; set; }

        public int ProductId { get; set; }  // Foreign Key
        public Product Product { get; set; } // Navigation Property
    }
}
