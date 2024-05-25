using Fiap.TechChallenge.Fase1.SharedKernel.Data;

namespace Fiap.TechChallenge.Fase1.Data;

public interface IContatoRepository : IRepository<Dominio.Entidades.Contato>
{
    Task<Dominio.Entidades.Contato> ObterPorEmailAsync(string email);
}
