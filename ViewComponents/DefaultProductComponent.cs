using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WaggyProject.Context;

namespace WaggyProject.ViewComponents
{
    public class DefaultProductComponent:ViewComponent
    {
        private readonly WaggyContext _context;

        public DefaultProductComponent(WaggyContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var values = _context.Categories.Include(c=>c.Products).ToList();
            return View(values);
        }

    }
}
