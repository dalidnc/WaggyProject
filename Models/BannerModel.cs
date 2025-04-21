namespace WaggyProject.Models
{
    public class BannerModel
    {
        public int BannerId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    
        public IFormFile? BannerImageUrl { get; set; }
        public string? CurrentImageUrl { get; set; }


    }
}
