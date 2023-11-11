using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class MatriculaRepository : GenericRepo<Matricula>, IMatricula
{
    protected readonly ApiContext _context;

    public MatriculaRepository(ApiContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Matricula>> GetAllAsync()
    {
        return await _context.Matriculas
            .ToListAsync();
    }

    public override async Task<Matricula> GetByIdAsync(int id)
    {
        return await _context.Matriculas
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<object> AsignaturasDeXEstudiante()
    {
        return await (
            from m in _context.Matriculas
            join p in _context.Personas on m.IdAlumnoFk equals p.Id
            join a in _context.Asignaturas on m.IdAsignaturaFk equals a.Id
            join c in _context.CursoEscolares on m.IdCursoEscolarFk equals c.Id
            where p.Nit.Equals("26902806M")
            group a.Nombre by new
            {
                Id = p.Id,
                Nombre = p.Nombre,
                AnioInicio = c.AñoInicio,
                AnioFin = c.AñoFin,
            } into g
            select new
            {
                g.Key.Id,
                g.Key.Nombre,
                g.Key.AnioInicio,
                g.Key.AnioFin,
                Asignaturas = g.ToList()
            }
        ).ToListAsync();
    }
    public async Task<IEnumerable<object>> AlumnoMatriculadoCurso2018A2019()
    {
        return await (_context.Matriculas
            .Include(p => p.Persona)
            .Include(p => p.CursoEscolar)
            .Where(p => p.CursoEscolar.AñoInicio == 2018) 
            .Where(p => p.CursoEscolar.AñoFin == 2019)
            .GroupBy(x => x.Persona.Nombre)
            .Select(p => new
            {
                Alumno = p.Key
            })
            .ToListAsync());
    }

    public async Task<IEnumerable<object>> AlumnosMatriculadosPorCurso() //consulta 24
    {
        var resultado = await _context.Matriculas
            .GroupBy(m => m.CursoEscolar.AñoInicio)
            .Select(g => new
            {
                AnioCursoEscolar = g.Key,
                NumAlumnosMatriculados = g.Count()
            })
            .OrderBy(g => g.AnioCursoEscolar)
            .ToListAsync();

        return resultado;
    }


}
