using Fiap.TechChallenge.Fase1.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fiap.TechChallenge.Fase1.Data
{
    public class DDDRegiaoMapping : IEntityTypeConfiguration<DDDRegiao>
    {
        public void Configure(EntityTypeBuilder<DDDRegiao> builder)
        {
            builder.ToTable("regiao");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Estado).HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(x => x.DDD).HasColumnType("INT").IsRequired();
            builder.Property(x => x.Regiao).HasColumnType("VARCHAR(50)").IsRequired();

            builder.Property(x => x.Dt_Registro).HasColumnType("timestamp").IsRequired();
            builder.Property(x => x.Dt_Alteracao).HasColumnType("timestamp");
            builder.Property(x => x.Dt_Exclusao).HasColumnType("timestamp");
            builder.Property(x => x.Excluido).HasColumnType("BOOL");
        }
    }
}
