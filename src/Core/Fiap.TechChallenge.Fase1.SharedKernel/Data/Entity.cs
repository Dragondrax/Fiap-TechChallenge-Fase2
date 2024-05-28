using System.ComponentModel.DataAnnotations;

namespace Fiap.TechChallenge.Fase1.SharedKernel.Data
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; private set; }
        public bool Excluido { get; private set; }
        public DateTime Dt_Registro { get; private set; }
        public DateTime? Dt_Alteracao { get; private set; }
        public DateTime? Dt_Exclusao { get; private set; }

        protected void AtualizarDtCadastro()
        {
            Dt_Registro = DateTime.Now;
        }

        protected void AtualizarDtAlteracao()
        {
            Dt_Alteracao = DateTime.Now;
        }

        protected void Exclusao()
        {
            Dt_Exclusao = DateTime.Now;
            Excluido = true;
        }
    }
}
