using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SmartAdmin.WebUI.Controllers
{
    public class IntelController : Controller
    {
        [AllowAnonymous]
        public IActionResult AnalyticsDashboard() => View();
        public IActionResult Introduction() => View();
        public IActionResult MarketingDashboard() => View();
        public IActionResult Privacy() => View();
    }
}
