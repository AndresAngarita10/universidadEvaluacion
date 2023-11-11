namespace Dominio.Entities;
public class Asignatura : BaseEntity
{
    public enum EnumValores
    {
        básica,
        obligatoria,
        optativa
    }
    public string Nombre { get; set; }
    public float Creditos { get; set; }
    public EnumValores Tipo {get; set;}
    public int Curso {get; set;}
    public int Cuatrimestre {get; set;}
    public int? IdProfesorFk {get; set;}
    public Profesor Profesor {get; set;}
    public int IdGradoFk {get; set;}
    public Grado Grado {get; set;}

    public ICollection<Matricula> Matriculas {get; set;}
}
