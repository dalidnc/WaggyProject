using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Linq;
using WaggyProject.Context;
using WaggyProject.Entities;

namespace WaggyProject.Controllers
{
    public class ClothesController : Controller
    {
        private readonly WaggyContext _waggyContext;

        public ClothesController(WaggyContext waggyContext)
        {
            _waggyContext = waggyContext;
        }

        public IActionResult Index()
        {
            var values = _waggyContext.Costumes.Include(x=>x.Category).ToList();
            return View(values);

        }
        public IActionResult AddClothes()
        {
            var categoryList = _waggyContext.Categories.ToList();
            ViewBag.Category = (from x in categoryList
                                select new SelectListItem
                                {
                                    Text = x.CategoryName,
                                    Value = x.CategoryId.ToString()
                                });
            return View();
        }
        [HttpPost]
        public IActionResult AddClothes(Costume costume)
        {
            if(costume.ImageFile != null)
            {
                var currentDirectory = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(costume.ImageFile.FileName);
                var fileName = Guid.NewGuid().ToString();
                var saveLocation = Path.Combine(currentDirectory, "wwwroot/clothes_images",fileName+ extension);

                var stream = new FileStream(saveLocation, FileMode.Create);

                costume.ImageFile.CopyTo(stream);
                costume.ImageUrl = "/clothes_images/" + fileName + extension;


            }

            _waggyContext.Costumes.Add(costume);
            _waggyContext.SaveChanges();
            return RedirectToAction("Index");
        }

        
        public IActionResult UpdateClothes(int id)
        {
            var costume = _waggyContext.Costumes.Find(id);
            if (costume == null)
            {
                return NotFound();
            }

            var categoryList = _waggyContext.Categories.ToList();
            ViewBag.Category = (from x in categoryList
                                select new SelectListItem
                                {
                                    Text = x.CategoryName,
                                    Value = x.CategoryId.ToString()
                                });

            

            return View(costume);
        }


        [HttpPost]
        public IActionResult UpdateClothes(Costume costume)
        {
            var values =_waggyContext.Costumes.Find(costume.Id);


            if (costume.ImageFile == null)
            {
                costume.ImageUrl = values.ImageUrl;
            }
            else
            {
                var resource = Directory.GetCurrentDirectory();
                var extansion = Path.GetExtension(costume.ImageFile.FileName);
                var imageName = Guid.NewGuid().ToString() + extansion;
                var saveLocation = resource + "/wwwroot/clothes_images/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                costume.ImageFile.CopyTo(stream);
                values.ImageUrl = "/clothes_images/" + imageName;
            }

                
            
            

            values.Name = costume.Name;
            values.Price = costume.Price;
            values.Review = costume.Review;
            values.CategoryId = costume.CategoryId;

            

            _waggyContext.Update(values);
            _waggyContext.SaveChanges();

            return RedirectToAction("Index");
        }
      
        public IActionResult DeleteClothes(int id)
        {
            var value = _waggyContext.Costumes.Find(id);
           _waggyContext.Remove(value);
            _waggyContext.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
