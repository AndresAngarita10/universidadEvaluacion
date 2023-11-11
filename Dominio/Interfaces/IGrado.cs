
using Dominio.Entities;

namespace Dominio.Interfaces;

public interface IGrado : IGenericRepo<Grado>
{
    public Task<IEnumerable<object>> ListadoGradosYNumAsignaturas(); // consulta 21
    public Task<IEnumerable<object>> ListadoGradosYNumAsignaturasMayorA40(); // consulta 22
    public Task<IEnumerable<object>> GradosConSumaCreditos(); // consulta 23
}
