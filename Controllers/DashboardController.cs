using Microsoft.AspNetCore.Mvc;
using WaggyProject.Context;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WaggyProject.Controllers
{
    public class DashboardController : Controller
    {
        private readonly WaggyContext _waggyContext;

        public DashboardController(WaggyContext waggyContext)
        {
            _waggyContext = waggyContext;
        }

        public IActionResult Index()
        {
            ViewBag.data1 = _waggyContext.Products.OrderByDescending(x=>x.ProductPrice).Select(x=>x.ProductName).FirstOrDefault();
            ViewBag.dataPrice = _waggyContext.Products.OrderByDescending(x => x.ProductPrice).Select(x => x.ProductPrice).FirstOrDefault();
            ViewBag.data1Category = _waggyContext.Products.OrderByDescending(x => x.ProductPrice).Select(x => x.Category.CategoryName).FirstOrDefault();
            ViewBag.cheapestProduct = _waggyContext.Products.OrderBy(x => x.ProductPrice).Select(x => x.ProductName).FirstOrDefault();
            ViewBag.cheapestProductPrice = _waggyContext.Products.OrderBy(x => x.ProductPrice).Select(x => x.ProductPrice).FirstOrDefault();
            ViewBag.cheapestProductCategory = _waggyContext.Products.OrderBy(x => x.ProductPrice).Select(x => x.Category.CategoryName).FirstOrDefault();
            ViewBag.ProductCount = _waggyContext.Products.Count();
            ViewBag.CommentCount = _waggyContext.Testimonials.Count();
            return View();
        }
     


    }
}
