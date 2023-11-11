using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class MatriculaConfiguration : IEntityTypeConfiguration<Matricula>
        {
            public void Configure(EntityTypeBuilder<Matricula> builder)
            {
                builder.ToTable("matricula");
    
                builder.HasKey(e => e.Id);

                builder.HasOne(p => p.Persona)
                .WithMany(p => p.Matriculas)
                .HasForeignKey(p => p.IdAlumnoFk);

                builder.HasOne(p => p.Asignatura)
                .WithMany(p => p.Matriculas)
                .HasForeignKey(p => p.IdAsignaturaFk);

                builder.HasOne(p => p.CursoEscolar)
                .WithMany(p => p.Matriculas)
                .HasForeignKey(p => p.IdCursoEscolarFk);
            }
        }
