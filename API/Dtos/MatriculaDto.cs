
using Dominio.Entities;

namespace API.Dtos;

public class MatriculaDto : BaseEntity
{
    public int IdAlumnoFk { get; set; }
    public int IdCursoEscolarFk { get; set; }
    public int IdAsignaturaFk { get; set; }
    
}
