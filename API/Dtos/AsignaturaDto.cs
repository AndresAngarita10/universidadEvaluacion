
using Dominio.Entities;

namespace API.Dtos;

public class AsignaturaDto : BaseEntity
{
    public enum EnumValores
    {
        básica,
        obligatoria,
        optativa
    }
    public string Nombre { get; set; }
    public float Creditos { get; set; }
    public EnumValores Tipo { get; set; }
    public int Curso { get; set; }
    public int Cuatrimestre { get; set; }
    public int IdProfesorFk { get; set; }
    public int IdGradoFk { get; set; }
}
