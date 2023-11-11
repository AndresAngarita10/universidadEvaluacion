
using Dominio.Entities;

namespace API.Dtos;

public class PersonaDto : BaseEntity
{
    public enum EnumValoresSexo
    {
        H,
        M,
    }
    public enum EnumValoresTipo
    {
        Profesor,
        Alumno,
    }
    public string Nit { get; set; }
    public string Nombre { get; set; }
    public string Apellido1 { get; set; }
    public string Apellido2 { get; set; }
    public string Ciudad { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public DateOnly FechaNacimiento { get; set; }
    public EnumValoresSexo Sexo { get; set; }
    public EnumValoresTipo Tipo { get; set; }

}
