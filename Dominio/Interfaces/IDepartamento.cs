
using Dominio.Entities;

namespace Dominio.Interfaces;

public interface IDepartamento : IGenericRepo<Departamento>
{
    public Task<IEnumerable<object>> DepartamentosSinAsignaturas(); // 31

}
