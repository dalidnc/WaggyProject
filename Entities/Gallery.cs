using System.ComponentModel.DataAnnotations.Schema;

namespace WaggyProject.Entities
{
    public class Gallery
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }  // Veritabanında resmin URL'sini saklamak için

        [NotMapped]  // Bu özelliğin veritabanında saklanmasını engellemek için
        public IFormFile ImageFile { get; set; }  // Kullanıcıdan dosya yüklemesi almak için
    }
}
