
using Dominio.Entities;

namespace Dominio.Interfaces;

public interface IAsignatura : IGenericRepo<Asignatura>
{
    public Task<IEnumerable<object>> AsignaturaCuatrimestreYId7();
    public Task<IEnumerable<object>> AsignaturaDeIngInformatica();
    public Task<IEnumerable<object>> AsignaturaSinPrfesor(); //30
}
