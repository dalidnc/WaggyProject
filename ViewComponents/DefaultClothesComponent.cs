using Microsoft.AspNetCore.Mvc;
using WaggyProject.Context;

namespace WaggyProject.ViewComponents
{
    public class DefaultClothesComponent:ViewComponent
    {
        private readonly WaggyContext _waggyContext;

        public DefaultClothesComponent(WaggyContext waggyContext)
        {
            _waggyContext = waggyContext;
        }

        public IViewComponentResult Invoke()
        {
            var values = _waggyContext.Costumes.Take(5).ToList();
            return View(values);
        }
    }
}
