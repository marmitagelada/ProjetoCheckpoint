using System;

namespace Projeto_Check_Point.Models
{
    public class ComentarioModel
    {
        public int IDComentario { get; set; }
        public string Comentario { get; set; }
        public DateTime DataComentario  { get; set; }
        public string Status { get; set; }

        public int idUsuario { get; set; }

        public ComentarioModel () { }

        public ComentarioModel (int idComentario, string comentario, DateTime dataComentario, string status) {
            this.IDComentario = idComentario;
            this.Comentario = comentario;
            this.DataComentario = dataComentario;
            this.Status = status;
        }
        public ComentarioModel (string comentario, DateTime dataComentario, int idusuario) {
            this.Comentario = comentario;
            this.DataComentario = dataComentario;
            this.idUsuario = idusuario;
        }
    }
}