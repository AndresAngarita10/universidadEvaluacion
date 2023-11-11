namespace Dominio.Entities;
public class CursoEscolar : BaseEntity
{
    public int AñoInicio { get; set; }
    public int AñoFin { get; set; }

    public ICollection<Matricula> Matriculas { get; set; }
}
