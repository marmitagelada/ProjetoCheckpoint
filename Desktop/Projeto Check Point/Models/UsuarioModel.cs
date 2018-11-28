namespace Projeto_Check_Point.Models
{
    public class UsuarioModel
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool Admin { get; set; }
        public UsuarioModel () { }
        public UsuarioModel (string email, string senha) {
            this.Email = email;
            this.Senha = senha;
        }
        public UsuarioModel (int id, string nome, string email, string senha, bool admin) {
            this.ID = id;
            this.Nome = nome;
            this.Email = email;
            this.Senha = senha;
            this.Admin = admin;
        }
    }
}