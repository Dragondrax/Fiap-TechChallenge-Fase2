using Fiap.TechChallenge.Fase1.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Fiap.TechChallenge.Fase1.Data.Repository.Usuario
{
    public class UsuarioRepository : Repository<Entidades.Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ContextTechChallenge db) : base(db)
        {

        }

        public async Task<Entidades.Usuario> ObterPorEmailAsync(string email)
        {
            return await Db.Usuario.FirstOrDefaultAsync(x => x.Email == email && x.Excluido == false);
        }

        public async Task<Entidades.Usuario> ObterPorIdAsync(Guid id)
        {
            return await Db.Usuario.FirstOrDefaultAsync(x => x.Id == id && x.Excluido == false);
        }
    }
}
