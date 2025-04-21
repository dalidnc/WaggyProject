namespace WaggyProject.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string? Icon { get; set; } // Bu ikon boş geçilebilir
        public IList<Product> Products { get; set; }
        public IList<Costume> Costumes { get; set; }
    }
}
