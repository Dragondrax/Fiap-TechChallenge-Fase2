using Fiap.TechChallenge.Fase1.Data.Context;
using Fiap.TechChallenge.Fase1.SharedKernel.Data;
using Microsoft.EntityFrameworkCore;

namespace Fiap.TechChallenge.Fase1.Data
{
    public abstract class Repository<T> : IRepository<T> where T : Entity, new()
    {
        protected readonly ContextTechChallenge Db;
        protected readonly DbSet<T> DbSet;

        protected Repository(ContextTechChallenge db)
        {
            Db = db;
            DbSet = db.Set<T>();
        }

        public async Task AdicionarAsync(T entidade)
        {
            DbSet.Add(entidade);
            await SalvarAsync();
        }

        public async Task AtualizarAsync(T entidade)
        {
            DbSet.Update(entidade);
            await SalvarAsync();
        }

        public async void Dispose()
        {
            Db?.Dispose();
        }

        public async Task<T> ObterPorIdAsync(Guid id)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Id == id && x.Excluido == false);
        }

        public async Task RemoverAsync(T entidade)
        {
            DbSet.Update(entidade);
            await SalvarAsync();
        }

        public async Task<bool> SalvarAsync()
        {
            return await Db.CommitAsync();
        }
    }
}
