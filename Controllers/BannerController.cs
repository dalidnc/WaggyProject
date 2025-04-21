using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WaggyProject.Context;
using WaggyProject.Entities;
using WaggyProject.Models;

namespace WaggyProject.Controllers
{
    public class BannerController : Controller
    {
        private readonly WaggyContext _context;

        public BannerController(WaggyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.Banners.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddBanner()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult AddBanner(BannerModel model )
        {
            string imagePath = SaveFile(model.BannerImageUrl);

            var Banner = new Banner()
            {
                Title = model.Title,
                Description = model.Description,
                BannerImageUrl = imagePath,

            };

            _context.Banners.Add(Banner);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        private string SaveFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return null;
            }

            var uploadPath = Path.Combine("wwwroot/uploads");

            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            Random random = new Random();
            int randomNumber = random.Next(1000, 9999);

            var folderName = $"{randomNumber}";
            var numberFolderPath = Path.Combine(uploadPath, folderName);

            if (!Directory.Exists(numberFolderPath))
            {
                Directory.CreateDirectory(numberFolderPath);
            }

            var newFileName = $"-{Path.GetFileNameWithoutExtension(file.FileName)}{Path.GetExtension(file.FileName)}";
            var filePath = Path.Combine(numberFolderPath, newFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            // Dosya yolu yerine URL'yi döndür
            var relativePath = $"/uploads/{folderName}/{newFileName}";
            return relativePath;
        }

        [HttpGet]
        public IActionResult UpdateBanner(int id)
        {
            var values = _context.Banners.FirstOrDefault(p => p.BannerId == id);
            var model = new BannerModel
            {
                Title = values?.Title,
             Description = values?.Description,
               CurrentImageUrl = string.IsNullOrEmpty(values?.BannerImageUrl) ? "/upload/default-image.png" : values.BannerImageUrl
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateBanner(int id, BannerModel model, IFormFile BannerImageUrl)
        {
            var banner = _context.Banners.Find(id);
            if (banner == null)
            {
                return NotFound();
            }
      

         
            string imagePath = banner.BannerImageUrl;

            
            if (BannerImageUrl != null && BannerImageUrl.Length > 0)
            {
                imagePath = SaveFile(BannerImageUrl);
            }

            banner.Title = model.Title;
            banner.Description = model.Description; 
            banner.BannerImageUrl = imagePath; 
           

     
            _context.Update(banner);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult DeleteBanner(int id)
        {
            var values = _context.Banners.Find(id);
            _context.Remove(values);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
