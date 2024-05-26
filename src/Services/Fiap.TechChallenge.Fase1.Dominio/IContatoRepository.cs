using Fiap.TechChallenge.Fase1.SharedKernel.Data;

namespace Fiap.TechChallenge.Fase1.Dominio;

public interface IContatoRepository : IRepository<Dominio.Entidades.Contato>
{
    Task<Dominio.Entidades.Contato> ObterPorEmailAsync(string email);
    Task<List<Dominio.Entidades.Contato>> BuscaContatosPorDDD(int DDD);
}
