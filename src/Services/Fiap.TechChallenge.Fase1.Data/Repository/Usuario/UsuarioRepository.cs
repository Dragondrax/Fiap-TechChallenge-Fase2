using Fiap.TechChallenge.Fase1.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Fiap.TechChallenge.Fase1.Data.Repository
{
    public class UsuarioRepository : Repository<Dominio.Entidades.Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ContextTechChallenge db) : base(db)
        {

        }

        public async Task<Dominio.Entidades.Usuario> ObterPorEmailAsync(string email)
        {
            return await Db.Usuario.FirstOrDefaultAsync(x => x.Email == email && x.Excluido == false);
        }
    }
}
