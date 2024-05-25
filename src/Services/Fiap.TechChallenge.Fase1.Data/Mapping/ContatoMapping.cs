using Fiap.TechChallenge.Fase1.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fiap.TechChallenge.Fase1.Data
{
    public class ContatoMapping : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.ToTable("contato");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(x => x.DDD).HasColumnType("INT").IsRequired();
            builder.Property(x => x.Telefone).HasColumnType("VARCHAR(9)").IsRequired();
            builder.Property(x => x.Email).HasColumnType("VARCHAR(100)").IsRequired();

            builder.Property(x => x.Dt_Registro).HasColumnType("timestamp").IsRequired();
            builder.Property(x => x.Dt_Alteracao).HasColumnType("timestamp");
            builder.Property(x => x.Dt_Exclusao).HasColumnType("timestamp");
            builder.Property(x => x.Excluido).HasColumnType("BOOL");
        }
    }
}
