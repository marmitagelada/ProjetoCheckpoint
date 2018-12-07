using System;
using System.Collections.Generic;
using System.IO;
using Projeto_Check_Point.Interfaces;
using Projeto_Check_Point.Models;

namespace Projeto_Check_Point.Repositorios {
    public class UsuarioRepositorioCSV : IUsuario {
        public UsuarioModel Cadastrar (UsuarioModel usuarioModel) {
            if (File.Exists ("usuarios.csv")) {
                //Aplicando o ID
                usuarioModel.ID = System.IO.File.ReadAllLines ("usuarios.csv").Length + 1;
            } else {
                usuarioModel.ID = 1;
            }

            bool admin;

            if (usuarioModel.Admin == true)
            {
                admin = true;
            } else {
                admin = false;
            }

            using (StreamWriter sw = new StreamWriter ("usuarios.csv", true)) {
                sw.WriteLine ($"{usuarioModel.ID};{usuarioModel.Nome};{usuarioModel.Email};{usuarioModel.Senha};{usuarioModel.Admin}");
            }

            return usuarioModel;
        }

        public UsuarioModel BuscarPorEmailESenha (string email, string senha) {
            List<UsuarioModel> usuariosCadastrados = CarregarDoCSV ();

            //Percorro cada usuário da lista do CSV...
            foreach (UsuarioModel usuario in usuariosCadastrados) {
                if (usuario.Email == email && usuario.Senha == senha) {
                    return usuario;
                }
            }

            //Caso  sistema não encontre nenhuma combinação de email e senha retorna nulls
            return null;
        }

        private List<UsuarioModel> CarregarDoCSV () {
            List<UsuarioModel> lsUsuarios = new List<UsuarioModel> ();

            //Abre o stream de leitura do arquivo
            string[] linhas = File.ReadAllLines ("usuarios.csv");

            //Lê cada registro no CSV
            foreach (string linha in linhas) {
                //Verificando se é uma linha vazia
                if (string.IsNullOrEmpty (linha)) {
                    continue; //Pula para o próximo registro do laço
                }

                //Separa os dados da linha
                string[] dadosDaLinha = linha.Split (';');

                //Cria o objeto com os dados da linha do CSV
                UsuarioModel usuario = new UsuarioModel (
                    id: int.Parse (dadosDaLinha[0]),
                    nome: dadosDaLinha[1],
                    email: dadosDaLinha[2],
                    senha: dadosDaLinha[3],
                    admin: bool.Parse(dadosDaLinha[4])
                );

                //Adicionando o usuário na lista
                lsUsuarios.Add (usuario);
            }
            return lsUsuarios;
        }
        public UsuarioModel BuscarPorID (int id) {
            string[] linhas = System.IO.File.ReadAllLines ("usuarios.csv");

            for (int i = 0; i < linhas.Length; i++) {
                if (string.IsNullOrEmpty (linhas[i])) {
                    continue;
                }

                string[] dados = linhas[i].Split (';');

                if (dados[0] == id.ToString ()) {
                    UsuarioModel usuario = new UsuarioModel (id: int.Parse (dados[0]), nome: dados[1], email: dados[2], senha: dados[3]);

                    return usuario;
                }
            }
            return null;
        }
    }
}