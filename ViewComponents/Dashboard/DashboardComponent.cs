using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WaggyProject.Context;

namespace WaggyProject.ViewComponents.Dashboard
{
    public class DashboardComponent:ViewComponent
    {
        private readonly WaggyContext _waggyContext;

        public DashboardComponent(WaggyContext waggyContext)
        {
            _waggyContext = waggyContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var products = await _waggyContext.Products.ToListAsync();
            return View(products); 
        }
    }
}
