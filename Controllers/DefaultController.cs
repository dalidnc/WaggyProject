using Microsoft.AspNetCore.Mvc;
using WaggyProject.Models;
using Microsoft.EntityFrameworkCore;
using WaggyProject.Context;
using WaggyProject.Entities;

namespace WaggyProject.Controllers
{
    public class DefaultController : Controller
    {
        private readonly WaggyContext waggyContext;

        public DefaultController(WaggyContext waggyContext)
        {
            this.waggyContext = waggyContext;
        }

        public IActionResult Index()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult SendMessage(Message model)
        {
            waggyContext.Add(model);
            waggyContext.SaveChanges();
            return NoContent();
        }
     

    }
}

