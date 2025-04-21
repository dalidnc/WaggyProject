using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using NuGet.Packaging.Signing;
using WaggyProject.Context;
using WaggyProject.Entities;

namespace WaggyProject.Controllers
{
    public class GalleryController : Controller
    {
        private readonly WaggyContext _waggyContext;

        public GalleryController(WaggyContext waggyContext)
        {
            _waggyContext = waggyContext;
        }

        public IActionResult Index()
        {
            var values = _waggyContext.Galleries.ToList();
            return View(values);
        }
        public IActionResult AddGallery()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult AddGallery(Gallery model)
        {
            if (!ModelState.IsValid)
            {
                var resource = Directory.GetCurrentDirectory();//Mecvut yolu aldık 
                var extansion = Path.GetExtension(model.ImageFile.FileName);//Dosya uzattısın getirdik(.jpg)
                var imageName = Guid.NewGuid().ToString() + extansion;
                var saveLocation = resource + "/wwwroot/clothes_images/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                model.ImageFile.CopyTo(stream);
                model.ImageUrl = "/clothes_images/" + imageName;
            }
            _waggyContext.Galleries.Add(model);
            _waggyContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeletGallery(int id)
        {
            var value = _waggyContext.Galleries.Find(id);
            _waggyContext.Remove(value);
            _waggyContext.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditGallery(int id)
        {
            var value = _waggyContext.Galleries.Find(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult EditGallery(Gallery gallery)
        {
            var value = _waggyContext.Galleries.Find(gallery.Id);
            if (gallery.ImageFile == null)
            {
                gallery.ImageUrl = gallery.ImageUrl;
            }
            else
            {
                var resource = Directory.GetCurrentDirectory();
                var extansion = Path.GetExtension(gallery.ImageFile.FileName);
                var imageName = Guid.NewGuid().ToString() + extansion;
                var saveLocation = resource + "/wwwroot/clothes_images/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                gallery.ImageFile.CopyTo(stream);
                value.ImageUrl = "/clothes_images/" + imageName;
            }

            _waggyContext.Update(value);
            _waggyContext.SaveChanges();
            return RedirectToAction("Index");
            
        }


    }
}
