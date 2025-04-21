using Microsoft.AspNetCore.Mvc;
using WaggyProject.Context;

namespace WaggyProject.ViewComponents
{
    public class DefaultBannerComponent:ViewComponent
    {
        private readonly WaggyContext _waggyContext;

        public DefaultBannerComponent(WaggyContext waggyContext)
        {
            _waggyContext = waggyContext;
        }

        public IViewComponentResult Invoke()
        {
            var values = _waggyContext.Banners.ToList();
            return View(values);
        }
    }
}
