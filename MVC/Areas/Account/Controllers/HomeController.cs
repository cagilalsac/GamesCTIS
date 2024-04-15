using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Areas.Account.Controllers
{
    [Area("Account")]
    public class HomeController : Controller
    {
        // GET: ~/Account/Home/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: ~/Account/Home/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(UserModel user)
        {
            ModelState.Remove(nameof(user.RoleId));
            if (ModelState.IsValid)
            {

            }
            return View(user);
        }
    }
}
