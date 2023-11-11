
using Dominio.Entities;

namespace API.Dtos;

public class CursoEscolarDto : BaseEntity
{
    public int AñoInicio { get; set; }
    public int AñoFin { get; set; }
}
