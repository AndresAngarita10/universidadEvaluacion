using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
{
    public void Configure(EntityTypeBuilder<Persona> builder)
    {
        builder.ToTable("persona");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Nombre)
        .HasColumnName("nombre")
        .HasColumnType("varchar")
        .HasMaxLength(50)
        .IsRequired();

        builder.Property(e => e.Apellido1)
        .HasColumnName("apellido1")
        .HasColumnType("varchar")
        .HasMaxLength(50)
        .IsRequired();

        builder.Property(e => e.Apellido2)
        .HasColumnName("apellido2")
        .HasColumnType("varchar")
        .HasMaxLength(50)
        .IsRequired();

        builder.Property(e => e.Ciudad)
        .HasColumnName("ciudad")
        .HasColumnType("varchar")
        .HasMaxLength(100)
        .IsRequired();

        builder.Property(e => e.Direccion)
        .HasColumnName("direccion")
        .HasColumnType("varchar")
        .HasMaxLength(255)
        .IsRequired();

        builder.Property(e => e.Telefono)
        .HasColumnName("telefono")
        .HasColumnType("varchar")
        .HasMaxLength(100);

        builder.Property(e => e.FechaNacimiento)
        .HasColumnName("fechaNacimiento")
        .HasColumnType("Date")
        .IsRequired();

        builder.Property(p => p.Sexo)
        .HasColumnName("sexo")
        .HasColumnType("varchar")
        .HasMaxLength(50)
        .IsRequired()
        .HasConversion<string>();

        builder.Property(p => p.Tipo)
        .HasColumnName("tipo")
        .HasColumnType("varchar")
        .HasMaxLength(50)
        .IsRequired()
        .HasConversion<string>();
    }
}
/*dotnet ef database update --project ./Persistencia/ --startup-project ./API/
 */