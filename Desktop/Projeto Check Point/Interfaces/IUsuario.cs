using System.Collections.Generic;
using Projeto_Check_Point.Models;

namespace Projeto_Check_Point.Interfaces
{
    
    public interface IUsuario
    {
        UsuarioModel Cadastrar(UsuarioModel usuario);

        UsuarioModel BuscarPorEmailESenha(string email, string senha);
    }
}