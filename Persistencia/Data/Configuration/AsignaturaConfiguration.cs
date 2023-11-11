using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class AsignaturaConfiguration : IEntityTypeConfiguration<Asignatura>
{
    public void Configure(EntityTypeBuilder<Asignatura> builder)
    {
        builder.ToTable("asignatura");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Nombre)
        .HasColumnName("nombre")
        .HasColumnType("varchar")
        .HasMaxLength(50)
        .IsRequired();

        builder.Property(e => e.Creditos)
        .HasColumnName("creditos")
        .HasColumnType("float(7,2)")
        .HasMaxLength(50)
        .IsRequired();

        builder.Property(p => p.Tipo)
        .HasColumnName("tipo")
        .HasColumnType("varchar")
        .IsRequired()
        .HasMaxLength(50)
        .HasConversion<string>();

        builder.Property(e => e.Curso)
        .HasColumnName("curso")
        .HasColumnType("int")
        .HasMaxLength(1)
        .IsRequired();

        builder.Property(e => e.Cuatrimestre)
        .HasColumnName("cuatrimestre")
        .HasColumnType("int")
        .HasMaxLength(1)
        .IsRequired();

        builder.HasOne(p => p.Profesor)
        .WithMany(p => p.Asignaturas)
        .HasForeignKey(p => p.IdProfesorFk)
        .IsRequired(false);

        builder.HasOne(p => p.Grado)
        .WithMany(p => p.Asignaturas)
        .HasForeignKey(p => p.IdGradoFk);
    }
}
