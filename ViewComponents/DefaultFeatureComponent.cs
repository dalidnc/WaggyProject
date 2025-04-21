using Microsoft.AspNetCore.Mvc;
using WaggyProject.Context;

namespace WaggyProject.ViewComponents
{
    public class DefaultFeatureComponent:ViewComponent
    {
        private readonly WaggyContext _waggyContext;

        public DefaultFeatureComponent(WaggyContext waggyContext)
        {
            _waggyContext = waggyContext;
        }

        public IViewComponentResult Invoke()
        {
            var values = _waggyContext.Products.Where(x=>x.Review==5).ToList();
            return View(values);
        }
    }
}
