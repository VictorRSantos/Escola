using Escola.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Escola.Infra.Data.EntitiesConfiguration
{
    public class CursoConfiguration : IEntityTypeConfiguration<Curso>
    {
        public void Configure(EntityTypeBuilder<Curso> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(c => c.Descricao)
                .HasMaxLength(200);
        }
    }
}
