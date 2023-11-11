
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class ProfesorRepository : GenericRepo<Profesor>, IProfesor
{
    protected readonly ApiContext _context;
    
    public ProfesorRepository(ApiContext context) : base (context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Profesor>> GetAllAsync()
    {
        return await _context.Profesores
            .ToListAsync();
    }

    public override async Task<Profesor> GetByIdAsync(int id)
    {
        return await _context.Profesores
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
    public async Task<IEnumerable<object>> NombresDeDepartamentos()
    {
        return await (_context.Profesores
            .Include(p => p.Departamento)
            .Include(p => p.Asignaturas).ThenInclude(p => p.Grado)
            .Where(p => p.Asignaturas.Any(a => a.Grado.Nombre == "Grado en Ingeniería Informática (Plan 2015)"))  // Filtramos por el nombre del grado
            .GroupBy(x => x.Departamento.Nombre)
            .Select(p => new
            {
                DepartamentoNombre = p.Key
            })
            .ToListAsync());
    }
    
}