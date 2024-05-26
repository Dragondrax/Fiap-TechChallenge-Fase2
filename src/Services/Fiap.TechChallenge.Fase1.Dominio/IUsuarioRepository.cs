using Fiap.TechChallenge.Fase1.SharedKernel.Data;

namespace Fiap.TechChallenge.Fase1.Data.Repository
{
    public interface IUsuarioRepository : IRepository<Dominio.Entidades.Usuario>
    {
        Task<Dominio.Entidades.Usuario> ObterPorEmailAsync(string email);
    }
}
