using Microsoft.AspNetCore.Mvc;
using WaggyProject.Context;

namespace WaggyProject.ViewComponents
{
    public class DefaultTestimonialComponent:ViewComponent
    {
        private readonly WaggyContext _waggyContext;

        public DefaultTestimonialComponent(WaggyContext waggyContext)
        {
            _waggyContext = waggyContext;
        }

        public IViewComponentResult Invoke()
        {
            var values = _waggyContext.Testimonials.ToList();
            return View(values);
        }
    }
}
