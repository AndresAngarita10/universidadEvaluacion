
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class DepartamentoRepository : GenericRepo<Departamento>, IDepartamento
{
    protected readonly ApiContext _context;
    
    public DepartamentoRepository(ApiContext context) : base (context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Departamento>> GetAllAsync()
    {
        return await _context.Departamentos
            .ToListAsync();
    }

    public override async Task<Departamento> GetByIdAsync(int id)
    {
        return await _context.Departamentos
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }

    public async Task<IEnumerable<object>> DepartamentosSinAsignaturas() // 31
    {
        var departamentosSinAsignaturas = await _context.Departamentos
            .Where(d => !d.Profesores.Any(p => p.Asignaturas.Any()))
            .Select(d => new
            {
                NombreDepartamento = d.Nombre
            })
            .ToListAsync();

        return departamentosSinAsignaturas;
    }
}
