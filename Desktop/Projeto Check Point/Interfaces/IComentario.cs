using System.Collections.Generic;
using Projeto_Check_Point.Models;

namespace Projeto_Check_Point.Interfaces
{
    public interface IComentario
    {
        ComentarioModel Cadastrar(ComentarioModel usuario);
        List<ComentarioModel> Listar();
        void AprovarComentario(int id);
        void RecusarComentario(int id);
        ComentarioModel BuscarPorID(int id);
    }
}