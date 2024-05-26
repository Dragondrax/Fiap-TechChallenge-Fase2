using Fiap.TechChallenge.Fase1.SharedKernel.Data;

namespace Fiap.TechChallenge.Fase1.Dominio;

public interface IDDDRegiaoRepository : IRepository<Dominio.Entidades.DDDRegiao>
{
    Task<Dominio.Entidades.DDDRegiao> BuscarRegiaoPorDDD(int DDD);
}
