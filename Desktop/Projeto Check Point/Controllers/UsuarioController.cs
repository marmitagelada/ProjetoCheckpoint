using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_Check_Point.Interfaces;
using Projeto_Check_Point.Models;
using Projeto_Check_Point.Repositorios;

namespace Projeto_Check_Point.Controllers
{
    public class UsuarioController : Controller
    {
        public IUsuario UsuarioRepositorio { get; set; }
        public UsuarioController () {
            UsuarioRepositorio = new UsuarioRepositorioCSV ();
        }
        [HttpGet]
        public ActionResult Cadastro () => View (); 

        [HttpPost]
        public ActionResult Cadastro (IFormCollection form) {

            UsuarioModel usuarioModel = new UsuarioModel( nome: form["nome"], email: form["email"], senha: form["senha"]);

            UsuarioRepositorio.Cadastrar (usuarioModel);

            return RedirectToAction("Index", "Pages");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
    }
}