using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WaggyProject.Context;
using WaggyProject.Models;

namespace WaggyProject.Controllers
{
    public class FishProductController : Controller
    {
        private readonly WaggyContext _waggyContext;

        public FishProductController(WaggyContext waggyContext)
        {
            _waggyContext = waggyContext;
        }

        public IActionResult Index()
        {
            var values = _waggyContext.ProductView.Where(x => x.CategoryId == 4).ToList();
            return View(values);
        }

        public IActionResult AddFishProduct()
        {
            var values = _waggyContext.Categories.Where(x => x.CategoryId == 4).ToList();
            ViewBag.Fishegory = (from x in values
                                select new SelectListItem
                                {
                                    Text = x.CategoryName,
                                    Value = x.CategoryId.ToString()
                                });
            return View();
        }
        [HttpPost]
        public IActionResult AddFishProduct(ProductModel model)
        {
            string imagePath = SaveFile(model.ProductImageUrl);

            var Product = new Entities.Product()
            {
                ProductName = model.ProductName,
                CategoryId = model.CategoryId,
                ProductPrice = model.ProductPrice,
                Review = model.Review,
                ProductImageUrl = imagePath
            };

            _waggyContext.Products.Add(Product);
            _waggyContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateFishProduct(int id)
        {
            var product = _waggyContext.ProductView.FirstOrDefault(p => p.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }

            // Kategori seçimini sağlamak için
            ViewBag.Category = new SelectList(
      _waggyContext.Categories.Where(x => x.CategoryId == 4),
      "CategoryId",
      "CategoryName"
  );

            // Modeli oluştururken, eğer mevcut görsel yolu null ise, varsayılan bir yol atıyoruz.
            var model = new ProductModel
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Review = product.Review,
                ProductPrice = product.ProductPrice,
                CategoryId = product.CategoryId,
                CurrentImageUrl = string.IsNullOrEmpty(product.ProductImageUrl) ? "/upload/default-image.png" : product.ProductImageUrl
            };

            return View(model);
        }
        public IActionResult UpdateFishProduct(int id, ProductModel model, IFormFile ProductImageUrl)
        {
            var product = _waggyContext.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            //Bu veriler Baibü staj sitesinden alındı(MKS)

            // Yeni resim yüklenmediyse mevcut görseli kullan
            string imagePath = product.ProductImageUrl;

            // Eğer yeni bir görsel yüklenmişse, dosyayı kaydediyoruz
            if (ProductImageUrl != null && ProductImageUrl.Length > 0)
            {
                imagePath = SaveFile(ProductImageUrl);
            }

            // Ürün bilgilerini güncelle
            product.ProductName = model.ProductName;
            product.Review = model.Review;
            product.ProductPrice = model.ProductPrice;
            product.ProductImageUrl = imagePath; // Yüklenen yeni görseli kullan


            // Veritabanında güncellemeyi yapıyoruz
            _waggyContext.Update(product);
            _waggyContext.SaveChanges();

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

        public IActionResult DeleteFishProduct(int id)
        {
            var values = _waggyContext.Products.Find(id);
            _waggyContext.Remove(values);
            _waggyContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteDogProduct(int id)
        {
            var value = _waggyContext.Products.Find(id);
            _waggyContext.Remove(value);
            _waggyContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
