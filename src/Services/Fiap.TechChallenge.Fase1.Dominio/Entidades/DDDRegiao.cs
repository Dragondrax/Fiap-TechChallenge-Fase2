using Fiap.TechChallenge.Fase1.SharedKernel.Data;

namespace Fiap.TechChallenge.Fase1.Dominio.Entidades
{
    public class DDDRegiao : Entity
    {
        public int DDD { get; set; }
        public string Estado { get; set; }
        public string Regiao { get; set; }

        public DDDRegiao() { } 
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
