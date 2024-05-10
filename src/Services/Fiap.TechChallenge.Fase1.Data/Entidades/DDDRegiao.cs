using Fiap.TechChallenge.Fase1.SharedKernel.Data;
using System.Data;

namespace Fiap.TechChallenge.Fase1.Data.Entidades
{
    public class DDDRegiao : Entity
    {
        public int DDD { get; private set; }
        public string Estado { get; private set; }
        public string Regiao { get; private set; }

        private DDDRegiao() { } 
        public DDDRegiao(int dDD, string estado, string regiao)
        {
            DDD = dDD;
            Estado = estado;
            Regiao = regiao;
        }

        public void AlterarDDDRegiao(int dDD, string estado, string regiao)
        {
            DDD = dDD;
            Estado = estado;
            Regiao = regiao;
            AtualizarDtAlteracao();
        }

        public void ExcluirDDDRegiao()
        {
            Exclusao();
        }
    }
}
