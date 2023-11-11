
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class GradoRepository : GenericRepo<Grado>, IGrado
{
    protected readonly ApiContext _context;

    public GradoRepository(ApiContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Grado>> GetAllAsync()
    {
        return await _context.Grados
            .ToListAsync();
    }

    public override async Task<Grado> GetByIdAsync(int id)
    {
        return await _context.Grados
        .FirstOrDefaultAsync(p => p.Id == id);
    }


    public async Task<IEnumerable<object>> ListadoGradosYNumAsignaturas() // consulta 21
    {
        return await (_context.Asignaturas
            .Include(p => p.Grado)
            .GroupBy(p => new
            {
                GradoNombre = p.Grado.Nombre,
            })
            .Select(group => new
            {
                GradoNombre = group.Key.GradoNombre,
                CantidadAsignaturas = group.Count(),
            }).OrderBy(x => x.CantidadAsignaturas)
            .ToListAsync());
    }


    public async Task<IEnumerable<object>> ListadoGradosYNumAsignaturasMayorA40() // consulta 22
    {
        return await (_context.Asignaturas
            .Include(p => p.Grado)
            .GroupBy(p => new
            {
                GradoNombre = p.Grado.Nombre,
            })
            .Select(group => new
            {
                GradoNombre = group.Key.GradoNombre,
                CantidadAsignaturas = group.Count(),
            }).OrderBy(x => x.CantidadAsignaturas)
            .Where(p => p.CantidadAsignaturas > 40)
            .ToListAsync());
    }
    public async Task<IEnumerable<object>> GradosConSumaCreditos() // consulta 23
    {
        return await (
            from asi in _context.Asignaturas
            join gr in _context.Grados on asi.IdGradoFk equals gr.Id
            group asi by new { gr.Nombre, asi.Tipo } into grupo
            select new
            {
                NombreGrado = grupo.Key.Nombre,
                TipoAsignatura = grupo.Key.Tipo.ToString(),
                SumaCreditos = grupo.Sum(x => x.Creditos)
            }
        )
        .ToListAsync();
    }

    /* .Include(p => p.Grado)
            .GroupBy(p => new
            {
                GradoNombre = p.Grado.Nombre,
                TipoAsignatura = p.Tipo
            })
            .Select(group => new
            {
                GradoNombre = group.Key.GradoNombre,
                TipoAsignatura = group.Key.TipoAsignatura,
                SumaCreditos = group.Sum(x => x.Creditos),
            }).OrderBy(x => x.SumaCreditos */

}