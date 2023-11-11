using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class GradoConfiguration : IEntityTypeConfiguration<Grado>
        {
            public void Configure(EntityTypeBuilder<Grado> builder)
            {
                builder.ToTable("grado");
    
                builder.HasKey(e => e.Id);

                builder.Property(e => e.Nombre)
                .HasColumnName("nombre")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();
            }
        }
