using Microsoft.AspNetCore.Mvc;

namespace Projeto_Check_Point.Controllers
{
    public class PagesController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Sobre()
        {
            return View();
        }
        [HttpGet]
        public IActionResult FAQ()
        {
            return View();
        }
        [HttpGet]
        public IActionResult SAC()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
    }
}