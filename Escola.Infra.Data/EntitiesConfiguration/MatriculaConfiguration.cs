using Escola.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Escola.Infra.Data.EntitiesConfiguration
{
    public class MatriculaConfiguration : IEntityTypeConfiguration<Matricula>
    {
        public void Configure(EntityTypeBuilder<Matricula> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.UsuarioId)
                .IsRequired();
            builder.Property(m => m.TurmaId)
                .IsRequired();

            builder.HasOne(m => m.Usuario)
                .WithMany(u => u.Matriculas)
                .HasForeignKey(m => m.UsuarioId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(m => m.Turma)
                .WithMany(u => u.Matriculas)
                .HasForeignKey(m => m.TurmaId)
                .OnDelete(DeleteBehavior.NoAction);          
        }
    }
}
