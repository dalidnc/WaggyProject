using Microsoft.AspNetCore.Mvc;
using WaggyProject.Context;

namespace WaggyProject.ViewComponents
{
    public class DefaultCategories:ViewComponent
    {
        private readonly WaggyContext _waggyContext;

        public DefaultCategories(WaggyContext waggyContext)
        {
            _waggyContext = waggyContext;
        }

        public IViewComponentResult Invoke()
        {
             var values = _waggyContext.Categories.ToList();
            return View(values);
        }
    }
}
