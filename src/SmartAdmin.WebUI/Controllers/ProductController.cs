using Microsoft.AspNetCore.Mvc;

namespace SmartAdmin.WebUI.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
