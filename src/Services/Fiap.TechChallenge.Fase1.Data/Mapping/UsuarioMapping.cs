using Fiap.TechChallenge.Fase1.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fiap.TechChallenge.Fase1.Data
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuario");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(x => x.Role).HasColumnType("SMALLINT").IsRequired();
            builder.Property(x => x.Email).HasColumnType("VARCHAR(150)").IsRequired();
            builder.Property(x => x.Senha).HasColumnType("VARCHAR(500)").IsRequired();

            builder.Property(x => x.Dt_Registro).HasColumnType("timestamp").IsRequired();
            builder.Property(x => x.Dt_Alteracao).HasColumnType("timestamp");
            builder.Property(x => x.Dt_Exclusao).HasColumnType("timestamp");
            builder.Property(x => x.Excluido).HasColumnType("BOOL");
        }
    }
}
