using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class ProfesorConfiguration : IEntityTypeConfiguration<Profesor>
        {
            public void Configure(EntityTypeBuilder<Profesor> builder)
            {
                builder.ToTable("profesor");
    
                builder.HasKey(e => e.Id);

                builder.HasOne(p => p.Departamento)
                .WithMany(p => p.Profesores)
                .HasForeignKey(p => p.IdDepartamentoFk);

                builder.HasOne(p => p.Persona)
                .WithMany(p => p.Profesores)
                .HasForeignKey(p => p.IdProfesorFk);
            }
        }
/* dotnet ef migrations add InitialCreate --project .\Persistencia\ --startup-project ./API/ --output-dir ./Data/Migrations
 */