using Fiap.TechChallenge.Fase1.SharedKernel.Data;

namespace Fiap.TechChallenge.Fase1.Dominio.Entidades
{
    public class Contato : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }
        public int DDD { get; private set; }
        public string Telefone { get; private set; }
        public string Email { get; private set; }

        public Contato() { }

        public Contato(string nome, int DDD, string telefone, string email)
        {
            Nome = nome;
            this.DDD = DDD;
            Telefone = telefone;
            Email = email;
            AtualizarDtCadastro();
        }

        public void AlterarDDDRegiao(string nome, int DDD, string telefone, string email)
        {
            Nome = nome;
            this.DDD = DDD;
            Telefone = telefone;
            Email = email;
            AtualizarDtAlteracao();
        }

        public void ExcluirDDDRegiao()
        {
            Exclusao();
        }
    }
}
