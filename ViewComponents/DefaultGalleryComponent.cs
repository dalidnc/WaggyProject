using Microsoft.AspNetCore.Mvc;
using WaggyProject.Context;

namespace WaggyProject.ViewComponents
{
    public class DefaultGalleryComponent:ViewComponent
    {
        private readonly WaggyContext _waggyContext;

        public DefaultGalleryComponent(WaggyContext waggyContext)
        {
            _waggyContext = waggyContext;
        }

        public IViewComponentResult Invoke()
        {
            var values = _waggyContext.Galleries.Take(4).ToList();
            return View(values);
        }
    }
}
