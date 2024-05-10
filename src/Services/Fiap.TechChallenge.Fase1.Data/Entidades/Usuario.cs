using Fiap.TechChallenge.Fase1.SharedKernel.Data;
using System.Data;

namespace Fiap.TechChallenge.Fase1.Data.Entidades
{
    public class Usuario : Entity
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public string Role { get; private set; }

        private Usuario() { }

        public Usuario(string nome, string email, string senha, string role)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Role = role;
            AtualizarDtCadastro();
        }

        public void AlterarUsuario(string nome, string email, string senha, string role) 
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Role = role;
            AtualizarDtAlteracao();
        }

        public void ExcluirUsuario()
        {
            Exclusao();
        }
    }
}
