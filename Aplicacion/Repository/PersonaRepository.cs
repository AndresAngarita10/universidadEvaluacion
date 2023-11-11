
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class PersonaRepository : GenericRepo<Persona>, IPersona
{
    protected readonly ApiContext _context;

    public PersonaRepository(ApiContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Persona>> GetAllAsync()
    {
        return await _context.Personas
            .ToListAsync();
    }

    public override async Task<Persona> GetByIdAsync(int id)
    {
        return await _context.Personas
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<object>> PersonasQSonAlunosOrdenado()
    {
        return await (_context.Personas
            .Where(p => p.Tipo == Persona.EnumValoresTipo.Alumno)
            .OrderBy(p => p.Apellido1)
            .ThenBy(p => p.Apellido2)
            .ThenBy(p => p.Nombre)
            .Select(p => new
            {
                p.Apellido1,
                p.Apellido2,
                p.Nombre
            })
            .ToListAsync());
    }

    public async Task<IEnumerable<object>> AlumnoSinTelefono()
    {
        return await (_context.Personas
            .Where(p => p.Tipo == Persona.EnumValoresTipo.Alumno)
            .Where(p => p.Telefono.Equals(null))
            .Select(p => new
            {
                p.Id,
                p.Apellido1,
                p.Apellido2,
                p.Nombre,
                p.Telefono
            })
            .ToListAsync());
    }

    public async Task<IEnumerable<object>> AlumnoNacidoEn1999()
    {
        return await (_context.Personas
        .Where(p => p.Tipo == Persona.EnumValoresTipo.Alumno && p.FechaNacimiento.Year == 1999)
        .Select(p => new
        {
            p.Id,
            p.Nombre,
            p.Apellido1,
            p.Apellido2
        })
        .ToListAsync());
    }


    public async Task<IEnumerable<object>> ProfSinTelYNifEndK()
    {
        return await (_context.Personas
            .Where(p => p.Tipo == Persona.EnumValoresTipo.Profesor)
            .Where(p => p.Telefono.Equals(null) && p.Nit.EndsWith("K"))
            .Select(p => new
            {
                p.Id,
                p.Apellido1,
                p.Apellido2,
                p.Nombre,
                p.Telefono
            })
            .ToListAsync());
    }


    /* public async Task<IEnumerable<object>> AlumnasMatriculadoIngSistemasPlan2015()
    {
        return await (_context.Personas
            .Include(p => p.Matriculas)
            .Select(p => new
            {
                p.Id,
                p.Nombre,
                p.Cuatrimestre,
                p.Curso,
                NombreGrado = p.Grado.Nombre
            })
            .ToListAsync());
    } */

    public async Task<IEnumerable<object>> AlumnasMatriculadoIngSistemasPlan2015()
    {
        return await (
            from p in _context.Personas
            join m in _context.Matriculas on p.Id equals m.IdAlumnoFk
            join asi in _context.Asignaturas on m.IdAsignaturaFk equals asi.Id
            join grado in _context.Grados on asi.IdGradoFk equals grado.Id
            where grado.Nombre.Equals("Grado en Ingeniería Informática (Plan 2015)")
            where p.Tipo == Persona.EnumValoresTipo.Alumno
            where p.Sexo == Persona.EnumValoresSexo.M
            group p by new { p.Id, p.Nombre, p.Apellido1, p.Apellido2, NombreGrado = grado.Nombre } into grupo
            select new
            {
                Id = grupo.Key.Id,
                Nombre = grupo.Key.Nombre,
                Apellidos = grupo.Key.Apellido1 + " " + grupo.Key.Apellido2,
                Grado = grupo.Key.NombreGrado
            }
        ).ToListAsync();
    }

    public async Task<IEnumerable<object>> ProfXDepartamento()
    {
        return await (_context.Personas
            .Include(p => p.Profesores).ThenInclude(p => p.Departamento)
            .Where(p => p.Profesores.Any())
            .OrderBy(p => p.Apellido1)
            .ThenBy(p => p.Apellido2)
            .ThenBy(p => p.Nombre)
            .Select(p => new
            {
                /* Grado = p.Grado.Nombre, */
                p.Id,
                p.Nombre,
                p.Apellido1,
                p.Apellido2,
                Departamento = p.Profesores.Select(pf => new
                {
                    pf.Departamento.Nombre
                }).ToList()
            })
            .ToListAsync());
    }
    public async Task<object> ProfConOSinDepartamento()
    {
        var profesores = await (
             from pr in _context.Profesores
             join p in _context.Personas on pr.IdProfesorFk equals p.Id into personaGroup
             from persona in personaGroup.DefaultIfEmpty()
             join d in _context.Departamentos on pr.IdDepartamentoFk equals d.Id into departamentoGroup
             from departamento in departamentoGroup.DefaultIfEmpty()
             where persona.Tipo == Persona.EnumValoresTipo.Profesor
             orderby departamento != null ? departamento.Nombre : "Sin departamento", persona.Apellido1, persona.Apellido2, persona.Nombre
             select new
             {
                 NombreDepartamento = departamento != null ? departamento.Nombre : "Sin departamento",
                 PrimerApellido = persona.Apellido1,
                 SegundoApellido = persona.Apellido2,
                 Nombre = persona.Nombre
             })
             .ToListAsync();

        return profesores;
    }

    public async Task<IEnumerable<object>> DepartamentoSinProfesoresAsociados()
    {
        var departamentos = await (
            from d in _context.Departamentos
            where !d.Profesores.Any()
            select new
            {
                Nombre = d.Nombre
            })
            .ToListAsync();

        return departamentos;
    }
    public async Task<IEnumerable<object>> AsignaturaQueNoSeHayaImpartido()
    {
        var departamentos = await (
            from a in _context.Asignaturas
            join p in _context.Profesores on a.IdProfesorFk equals p.Id
            join d in _context.Departamentos on p.IdDepartamentoFk equals d.Id
            select new
            {
                Departamento = d.Nombre,
                AsignaturasNoImpartidas = (
                    from a in _context.Asignaturas
                    where a.IdProfesorFk.HasValue
                    where !_context.Matriculas.Any(m => m.IdAsignaturaFk == a.Id)
                    select a.Nombre
                ).ToList()
            })
            .Where(depto => depto.AsignaturasNoImpartidas.Any())
            .ToListAsync();

        return departamentos;
    }

    public async Task<IEnumerable<object>> ProfesoresSinAsignatura()
    {
        var profesores = await (
            from p in _context.Personas
            where p.Tipo == Persona.EnumValoresTipo.Profesor
            where !_context.Asignaturas.Any(a => a.IdProfesorFk == p.Id)
            select new
            {
                Nombre = p.Nombre,
                PrimerApellido = p.Apellido1,
                SegundoApellido = p.Apellido2
            })
            .ToListAsync();

        return profesores;
    }
    public async Task<IEnumerable<object>> DepartamentoYProfesor()
    {
        var resultado = await _context.Departamentos
            .Where(d => d.Profesores == d.Profesores)
            .Select(d => new
            {
                NombreDepartamento = d.Nombre,
                CantidadProfesores = d.Profesores.Count
            })
            .OrderByDescending(dp => dp.CantidadProfesores)
            .ToListAsync();

        return resultado;
    }
    public async Task<IEnumerable<object>> AsignaturasSinProfesores()
    {
        var asignaturas = await (
            from a in _context.Asignaturas
            where a.IdProfesorFk == null
            select new
            {
                IdAsignatura = a.Id,
                Asignatura = a.Nombre
            })
            .ToListAsync();

        return asignaturas;
    }
    public async Task<object> TotalAlumnas()
    {
        int totalAlumnas = await _context.Personas
            .CountAsync(p => p.Tipo == Persona.EnumValoresTipo.Alumno && p.Sexo == Persona.EnumValoresSexo.M);
        var retorno = new
        {
            totalAlumnas = totalAlumnas
        };
        return retorno;
    }


    public async Task<object> TotalAlumnosHombresNac1999()
    {
        int totalAlumnos = await _context.Personas
            .CountAsync(p => p.Tipo == Persona.EnumValoresTipo.Alumno && p.Sexo == Persona.EnumValoresSexo.H && p.FechaNacimiento.Year == 1999);
        var retorno = new
        {
            totalAlumnos = totalAlumnos
        };
        return retorno;
    }

    public async Task<IEnumerable<object>> ProfEnCadaDepartamento()
    {
        return await (_context.Profesores
            .Include(p => p.Departamento)
            .GroupBy(p => new
            {
                DepartamentoNombre = p.Departamento.Nombre,
            })
            .Select(group => new
            {
                DepartamentoNombre = group.Key.DepartamentoNombre,
                CantidadProf = group.Count(),
            }).OrderByDescending(x => x.CantidadProf)
            .ToListAsync());
    }

    public async Task<IEnumerable<object>> AsignaturaPorProfesor() //consulta 25
    {
        var resultado = await _context.Profesores
            .Where(d => d.Asignaturas == d.Asignaturas)
            .Select(d => new
            {
                Id = d.IdProfesorFk,
                Nombre = d.Persona.Nombre,
                PrimerApellido = d.Persona.Apellido1,
                SegundoApellido = d.Persona.Apellido2,
                CantidadAsignaturas = d.Asignaturas.Count
            })
            .OrderByDescending(dp => dp.CantidadAsignaturas)
            .ToListAsync();
        return resultado;
    }

    public async Task<object> AlumnoMaJoven() //consulta 26
    {
        return await (
            _context.Personas
            .OrderByDescending(x => x.FechaNacimiento)
            .Select(p => new
            {
                p.Nombre,
                p.Apellido1,
                p.Apellido2,
                p.Telefono,
                p.FechaNacimiento
            })
        ).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<object>> ProfesoresSinDepartamentos() // 27
    {
        var profesoresSinDepartamento = await _context.Personas
            .Where(p => p.Tipo == Persona.EnumValoresTipo.Profesor && p.Profesores.All(pf => pf.Departamento == null))
            .Select(p => new
            {
                NombreProfesor = $"{p.Nombre} {p.Apellido1} {p.Apellido2}",
                Departamento = "Sin asignar"
            })
            .ToListAsync();

        return profesoresSinDepartamento;
    }

    public async Task<IEnumerable<object>> DepartamentosSinProfesor() //28
    {
        var resultado = await _context.Departamentos
            .Where(d => !d.Profesores.Any())
            .Select(d => new
            {
                Id = d.Id,
                NombreDepartamento = d.Nombre,
                CantidadProfesores = d.Profesores.Count
            })
            .OrderByDescending(dp => dp.CantidadProfesores)
            .ToListAsync();

        return resultado;
    }

    
    public async Task<IEnumerable<object>> ProfesorConDeptPeroSinAsignatura() //29
    {
        var resultado = await _context.Profesores
            .Where(d => d.Departamento != null)
            .Where(d => !d.Asignaturas.Any())
            .Select(d => new
            {
                Id = d.Id,
                NombreProfesor = d.Persona.Nombre
            })
            .OrderByDescending(dp => dp.NombreProfesor)
            .ToListAsync();

        return resultado;
    }



    /* .Where(d => d.Profesores == null || !d.Profesores.Any())
            .Select(d => new
            {
                NombreDepartamento = d.Nombre,
                CantidadProfesores = d.Profesores != null ? d.Profesores.Count : 0
            })
            .OrderByDescending(dp => dp.CantidadProfesores) */


}