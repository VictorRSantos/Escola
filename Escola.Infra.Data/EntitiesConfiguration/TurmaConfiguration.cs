using Escola.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Escola.Infra.Data.EntitiesConfiguration
{
    public class TurmaConfiguration : IEntityTypeConfiguration<Turma>
    {
        public void Configure(EntityTypeBuilder<Turma> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(t => t.Descricao)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(t => t.CursoId)
                .IsRequired();

            builder.HasOne(t => t.Curso)
                .WithMany(t => t.Turmas)
                .HasForeignKey(t => t.CursoId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
