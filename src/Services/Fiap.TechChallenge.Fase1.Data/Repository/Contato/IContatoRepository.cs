using Fiap.TechChallenge.Fase1.SharedKernel.Data;

namespace Fiap.TechChallenge.Fase1.Data.Repository;

public interface IContatoRepository : IRepository<Entidades.Contato>
{
    Task<Entidades.Contato> ObterPorEmailAsync(string email);
}
