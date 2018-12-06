using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_Check_Point.Models;
using Projeto_Check_Point.Repositorios;

namespace Projeto_Check_Point.Controllers
{
    public class PagesController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            string id = HttpContext.Session.GetString("IDusuario");

            if (id != null)
            {
                int idINT = int.Parse(id);

                UsuarioRepositorioCSV rep = new UsuarioRepositorioCSV();
                UsuarioModel usuarioModel = rep.BuscarPorID(idINT);

            }
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
    }
}