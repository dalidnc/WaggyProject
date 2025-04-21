using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WaggyProject.Entities;
using WaggyProject.Models;

namespace WaggyProject.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(RegisterViewModel model)
        {
            var user = new AppUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.UserName,
            };
            var result = await _userManager.CreateAsync(user,model.Password);  
            if(!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(model);
            }

            return RedirectToAction("Index","Login");
        }
    }
    //@* //186129.Aa!1 *@
}
