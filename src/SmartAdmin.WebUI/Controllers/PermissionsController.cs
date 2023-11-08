using Microsoft.AspNetCore.Mvc;

namespace SmartAdmin.WebUI.Controllers
{
    public class PermissionsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
