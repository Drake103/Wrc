using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Wrc.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }

        public IActionResult Replays()
        {
            return View();
        }
    }
}