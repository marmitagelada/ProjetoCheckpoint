using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_Check_Point.Interfaces;
using Projeto_Check_Point.Models;
using Projeto_Check_Point.Repositorios;

namespace Projeto_Check_Point.Controllers
{
    public class UsuarioController : Controller
    {
        public IUsuario UsuarioRepositorioS { get; set; }
        public UsuarioController () {
            UsuarioRepositorioS = new UsuarioRepositorioS ();
        }
        [HttpGet]
        public ActionResult Cadastro () => View (); 

        [HttpPost]
        public ActionResult Cadastro (IFormCollection form) {

            UsuarioModel usuarioModel = new UsuarioModel (id: int.Parse(form["ID"]), nome: form["nome"], email: form["email"], senha: form["senha"], admin: bool.Parse(form["admin"]));

            UsuarioRepositorioS.Cadastrar (usuarioModel);

            ViewBag.Mensagem = "Usuário Cadastrado";

            return View ();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
    }
}