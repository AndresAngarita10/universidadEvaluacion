namespace Dominio.Entities;
public class Matricula : BaseEntity
{
    public int IdAlumnoFk { get; set; }
    public Persona Persona { get; set; }
    public int IdCursoEscolarFk { get; set; }
    public CursoEscolar CursoEscolar { get; set; }
    public int IdAsignaturaFk { get; set; }
    public Asignatura Asignatura { get; set; }
}
