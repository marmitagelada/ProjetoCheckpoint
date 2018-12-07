using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_Check_Point.Interfaces;
using Projeto_Check_Point.Models;
using Projeto_Check_Point.Repositorios;

namespace Projeto_Check_Point.Controllers {
    public class UsuarioController : Controller {
        public IUsuario UsuarioRepositorio { get; set; }
        public UsuarioController () {
            UsuarioRepositorio = new UsuarioRepositorioCSV ();
        }

        [HttpGet]
        public ActionResult Cadastro () => View ();

        [HttpPost]
        public ActionResult Cadastro (IFormCollection form) {

            UsuarioModel usuarioModel = new UsuarioModel (nome: form["nome"], email: form["email"], senha: form["senha"], admin: bool.Parse(form["admin"]));

            UsuarioRepositorio.Cadastrar (usuarioModel);

            return RedirectToAction ("Login", "Usuario");
        }

        [HttpGet]
        public IActionResult Login () {
            return View ();
        }

        [HttpPost]
        public IActionResult Login (IFormCollection form) {
            //Pega os dados do POST
            UsuarioModel usuario = new UsuarioModel (email: form["email"], senha: form["senha"]);
            //Verificar se o usuário possuí acesso para realizazr login
            // UsuarioRepositorioCSV usuarioRep = new UsuarioRepositorioCSV ();
            UsuarioModel usuarioModel = UsuarioRepositorio.BuscarPorEmailESenha (usuario.Email, usuario.Senha);
            if (usuarioModel != null) {
                HttpContext.Session.SetString("IDusuario", usuarioModel.ID.ToString());
                HttpContext.Session.SetString("tipoUsuario", usuarioModel.Admin.ToString());

                return RedirectToAction ("Index" , "Pages");
            }
            return View ();
        }

        [HttpGet]
        public IActionResult Sair () {
            HttpContext.Session.Remove("IDusuario");
            return RedirectToAction ("Index" , "Pages");
        }
    }
}