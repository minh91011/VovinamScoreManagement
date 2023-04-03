using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VovinamScoreManagerWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            ViewBag.userName = HttpContext.Session.GetString("accName");
            ViewBag.chucvu = HttpContext.Session.GetString("chucvu");
            ViewBag.accID = HttpContext.Session.GetString("accID");
            return View();
        }
    }
}
