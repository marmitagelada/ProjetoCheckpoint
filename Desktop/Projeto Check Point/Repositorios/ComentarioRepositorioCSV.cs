using System.IO;
using Projeto_Check_Point.Interfaces;
using Projeto_Check_Point.Models;

namespace Projeto_Check_Point.Repositorios
{
    public class ComentarioRepositorioCSV : IComentario
    {
         public ComentarioModel Cadastrar (ComentarioModel comentarioModel) {
            if (File.Exists ("comentarios.csv")) {
                //Aplicando o ID
                comentarioModel.IDComentario = System.IO.File.ReadAllLines ("comentarios.csv").Length + 1;
            } else {
                comentarioModel.IDComentario = 1;
            }

            using (StreamWriter sw = new StreamWriter ("comentarios.csv", true)) {
                sw.WriteLine ($"{comentarioModel.IDComentario};{comentarioModel.idUsuario};{comentarioModel.Comentario};{comentarioModel.DataComentario};{comentarioModel.Status}");
            }

            return comentarioModel;
        }
    }
}