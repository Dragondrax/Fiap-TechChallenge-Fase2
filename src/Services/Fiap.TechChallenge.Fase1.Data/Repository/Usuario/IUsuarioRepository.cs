using Fiap.TechChallenge.Fase1.SharedKernel.Data;

namespace Fiap.TechChallenge.Fase1.Data.Repository
{
    public interface IUsuarioRepository : IRepository<Entidades.Usuario>
    {
        Task<Entidades.Usuario> ObterPorEmail(string email);
    }
}
