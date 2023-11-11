
using Dominio.Entities;

namespace Dominio.Interfaces;

public interface IMatricula : IGenericRepo<Matricula>
{
    public Task<object> AsignaturasDeXEstudiante();
    public Task<IEnumerable<object>> AlumnoMatriculadoCurso2018A2019();
    public Task<IEnumerable<object>> AlumnosMatriculadosPorCurso(); //consulta 24

}
