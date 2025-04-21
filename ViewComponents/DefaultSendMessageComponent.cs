using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using WaggyProject.Context;

namespace WaggyProject.ViewComponents
{
    public class DefaultSendMessageComponent:ViewComponent
    {
        private readonly WaggyContext _context;

        public DefaultSendMessageComponent(WaggyContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            return View();

        }
    }
}
