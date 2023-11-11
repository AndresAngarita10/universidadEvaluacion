
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class AsignaturaRepository : GenericRepo<Asignatura>, IAsignatura
{
    protected readonly ApiContext _context;
    
    public AsignaturaRepository(ApiContext context) : base (context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Asignatura>> GetAllAsync()
    {
        return await _context.Asignaturas
            .ToListAsync();
    }

    public override async Task<Asignatura> GetByIdAsync(int id)
    {
        return await _context.Asignaturas
        .FirstOrDefaultAsync(p =>  p.Id == id);
    } 

    public async Task<IEnumerable<object>> AsignaturaCuatrimestreYId7()
    {
        return await (_context.Asignaturas
            .Where(p => p.Cuatrimestre == 1)
            .Where(p => p.Curso == 3 && p.IdGradoFk == 7)
            .Select(p => new
            {
                p.Id,
                p.Nombre,
                p.Cuatrimestre,
                p.Curso,
                NombreGrado = p.Grado.Nombre
            })
            .ToListAsync());
    }
    public async Task<IEnumerable<object>> AsignaturaDeIngInformatica()
    {
        return await (_context.Asignaturas
            .Include(p => p.Grado)
            .Where(p => p.Grado.Nombre.Equals("Grado en Ingeniería Informática (Plan 2015)"))
            .Select(p => new
            {
                /* Grado = p.Grado.Nombre, */
                p.Id,
                p.Nombre
            })
            .ToListAsync());
    }

    public async Task<IEnumerable<object>> AsignaturaSinPrfesor() //30
    {
        var resultado = await _context.Asignaturas
            .Where(d => d.IdProfesorFk == null)
            .Select(d => new
            {
                Id = d.Id,
                Asignatura = d.Nombre
            })
            .OrderBy(dp => dp.Id)
            .ToListAsync();

        return resultado;
    }
}