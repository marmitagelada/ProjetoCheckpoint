using System;
using System.Collections.Generic;
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
                sw.WriteLine ($"{comentarioModel.IDComentario};{comentarioModel.idUsuario};{comentarioModel.NomeUsuario};{comentarioModel.Comentario};{comentarioModel.DataComentario};{comentarioModel.Status}");
            }

            return comentarioModel;
        }
        private List<ComentarioModel> CarregarComentarioCSV () {
            List<ComentarioModel> lsComentario = new List<ComentarioModel> ();
            string[] linhas = File.ReadAllLines ("comentarios.csv");

            foreach (string linha in linhas) {
                string[] dadosDaLinha = linha.Split (';');
                if (string.IsNullOrEmpty (linha)) {
                    continue;
                }

                ComentarioModel comentario = new ComentarioModel {

                    IDComentario = int.Parse(dadosDaLinha[0]),
                    idUsuario = int.Parse(dadosDaLinha[1]),
                    NomeUsuario = (dadosDaLinha[2]),
                    Comentario = (dadosDaLinha[3]),
                    DataComentario = DateTime.Parse(dadosDaLinha[4]),
                    Status = (dadosDaLinha[5]),
                };

                lsComentario.Add (comentario);
            }
            return lsComentario;
        }
        public ComentarioModel BuscarPorID (int id) {
            string[] linhas = System.IO.File.ReadAllLines ("comentarios.csv");
            for (int i = 0; i < linhas.Length; i++) {
                if (string.IsNullOrEmpty (linhas[i])) {
                    continue;
                }

                string[] dados = linhas[i].Split (';');

                if (dados[1] == id.ToString ()) {
                    ComentarioModel comentarioModel = new ComentarioModel ();

                    id = int.Parse (dados[1]);
                    return comentarioModel;
                };
            }

            return null;
        }
        public List<ComentarioModel> Listar () {
            List<ComentarioModel> lsComentarios = CarregarComentarioCSV();
            return lsComentarios;
        }
        public void AprovarComentario (int ID) {
            string[] linhas = System.IO.File.ReadAllLines ("comentarios.csv");
            for (int i = 0; i < linhas.Length; i++) {
                string[] dadosDaLinha = linhas[i].Split (';');

                if (string.IsNullOrEmpty (linhas[i])) {
                    continue;
                }

                if (ID.ToString () == dadosDaLinha[0]) {

                    linhas[i] = ($"{dadosDaLinha[0]};{dadosDaLinha[1]};{dadosDaLinha[2]};{dadosDaLinha[3]};{dadosDaLinha[4]};aprovado");
                }
            }
            File.WriteAllLines ("comentarios.csv", linhas);
        }
    }
}