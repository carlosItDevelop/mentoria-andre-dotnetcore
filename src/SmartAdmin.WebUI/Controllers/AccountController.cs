using Microsoft.AspNetCore.Mvc;

namespace SmartAdmin.WebUI.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
    }
}
