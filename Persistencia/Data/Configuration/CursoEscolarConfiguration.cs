using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class CursoEscolarConfiguration : IEntityTypeConfiguration<CursoEscolar>
        {
            public void Configure(EntityTypeBuilder<CursoEscolar> builder)
            {
                builder.ToTable("cursoEscolar");
    
                builder.HasKey(e => e.Id);

                builder.Property(e => e.AñoInicio)
                .HasColumnName("añoInicio")
                .HasColumnType("int")
                .IsRequired();

                builder.Property(e => e.AñoFin)
                .HasColumnName("añoFin")
                .HasColumnType("int")
                .IsRequired();
            }
        }
