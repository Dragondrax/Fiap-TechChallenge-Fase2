using Fiap.TechChallenge.Fase1.Dominio.Entidades;
using Fiap.TechChallenge.Fase1.SharedKernel.Data;
using Microsoft.EntityFrameworkCore;

namespace Fiap.TechChallenge.Fase1.Data.Context
{
    public class ContextTechChallenge : Microsoft.EntityFrameworkCore.DbContext, IUnitOfWork
    {
        public ContextTechChallenge(DbContextOptions<ContextTechChallenge> options) : base(options) 
        { 
        }

        public DbSet<Contato> Contato { get; set; }
        public DbSet<DDDRegiao> DDDRegiao { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Microsoft.EntityFrameworkCore.DbContext).Assembly);

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ContatoMapping());
            modelBuilder.ApplyConfiguration(new DDDRegiaoMapping());
            modelBuilder.ApplyConfiguration(new UsuarioMapping());
        }

        public async Task<bool> CommitAsync()
        {
            var success = await SaveChangesAsync() > 0;

            if (success)
            {
                await SaveChangesAsync();
            }

            return success;
        }
    }
}
