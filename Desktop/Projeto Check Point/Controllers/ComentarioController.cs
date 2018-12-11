using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_Check_Point.Interfaces;
using Projeto_Check_Point.Models;
using Projeto_Check_Point.Repositorios;

namespace Projeto_Check_Point.Controllers
{
    public class ComentarioController : Controller
    {
        public IComentario ComentarioRepositorio { get; set; }
        public ComentarioController () {
            ComentarioRepositorio = new ComentarioRepositorioCSV ();
        }

        [HttpPost]
        public ActionResult Cadastro (IFormCollection form) {
            
            UsuarioRepositorioCSV usuarioRep = new UsuarioRepositorioCSV();

         
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("IDusuario")))
            {
                return RedirectToAction("Login","Usuario");
            }

            int id = int.Parse(HttpContext.Session.GetString("IDusuario"));

            UsuarioModel usuarioModel = usuarioRep.BuscarPorID(id);

            ComentarioModel comentarioModel = new ComentarioModel (idusuario: id, nomeUsuario: usuarioModel.Nome,comentario: form["mensagem"], dataComentario: DateTime.Now, status: "em espera");

            ComentarioRepositorioCSV rep = new ComentarioRepositorioCSV();

            rep.Cadastrar (comentarioModel);

            return RedirectToAction ("Index","Pages");
        }

        [HttpGet]
        public IActionResult Gerenciar () {
            ViewData["Comentarios"] = ComentarioRepositorio.Listar ();
            return View();
        }

        [HttpGet]
        public ActionResult AprovarComentario (int id) {
            ComentarioRepositorio.AprovarComentario (id);
            TempData["Mensagem"] = "Comentário Aprovado";
            return RedirectToAction ("Gerenciar" , "Comentario");
        }
        [HttpGet]
        public ActionResult RecusarComentario (int id) {
            ComentarioRepositorio.RecusarComentario (id);
            TempData["Mensagem"] = "Comentário Recusado";
            return RedirectToAction ("Gerenciar" , "Comentario");
        }
        public ActionResult ListarComentariosAprovados () {
            ViewData["ComentariosAprovados"] = ComentarioRepositorio.Listar ();
            return View ();
        }
    }
}