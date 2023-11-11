
using API.Dtos;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class PersonaController : BaseApiController
{
    private readonly IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public PersonaController(IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersonaDto>>> Get()
    {
        var Persona = await unitofwork.Personas.GetAllAsync();
        return mapper.Map<List<PersonaDto>>(Persona);
    }


    [HttpGet("consulta1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> PersonasQSonAlunosOrdenado()
    {
        var Persona = await unitofwork.Personas.PersonasQSonAlunosOrdenado();
        return mapper.Map<List<object>>(Persona);
    }
    [HttpGet("consulta2")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> AlumnoSinTelefono()
    {
        var Persona = await unitofwork.Personas.AlumnoSinTelefono();
        return mapper.Map<List<object>>(Persona);
    }

    [HttpGet("consulta3")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> AlumnoNacidoEn1999()
    {
        var Persona = await unitofwork.Personas.AlumnoNacidoEn1999();
        return mapper.Map<List<object>>(Persona);
    }

    [HttpGet("consulta4")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> ProfSinTelYNifEndK()
    {
        var Persona = await unitofwork.Personas.ProfSinTelYNifEndK();
        return mapper.Map<List<object>>(Persona);
    }
    [HttpGet("consulta6")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> AlumnasMatriculadoIngSistemasPlan2015()
    {
        var Persona = await unitofwork.Personas.AlumnasMatriculadoIngSistemasPlan2015();
        return mapper.Map<List<object>>(Persona);
    }
    [HttpGet("consulta8")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> ProfXDepartamento()
    {
        var Persona = await unitofwork.Personas.ProfXDepartamento();
        return mapper.Map<List<object>>(Persona);
    }
    [HttpGet("consulta12")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> ProfConOSinDepartamento()
    {
        var Persona = await unitofwork.Personas.ProfConOSinDepartamento();
        return mapper.Map<List<object>>(Persona);
    }
    [HttpGet("consulta13")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> DepartamentoSinProfesoresAsociados()
    {
        var Persona = await unitofwork.Personas.DepartamentoSinProfesoresAsociados();
        return mapper.Map<List<object>>(Persona);
    }
    [HttpGet("consulta14")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> ProfesoresSinAsignatura()
    {
        var Persona = await unitofwork.Personas.ProfesoresSinAsignatura();
        return mapper.Map<List<object>>(Persona);
    }
    [HttpGet("consulta15")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> AsignaturasSinProfesores()
    {
        var Persona = await unitofwork.Personas.AsignaturasSinProfesores();
        return mapper.Map<List<object>>(Persona);
    }
    [HttpGet("consulta16")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> AsignaturaQueNoSeHayaImpartido()
    {
        var Persona = await unitofwork.Personas.AsignaturaQueNoSeHayaImpartido();
        return mapper.Map<List<object>>(Persona);
    }
    [HttpGet("consulta17")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> TotalAlumnas()
    {
        var personas = await unitofwork.Personas.TotalAlumnas();
        return Ok(personas);
    }
    [HttpGet("consulta18")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> TotalAlumnosHombresNac1999()
    {
        var personas = await unitofwork.Personas.TotalAlumnosHombresNac1999();
        return Ok(personas);
    }

    [HttpGet("consulta19")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> ProfEnCadaDepartamento()
    {
        var Persona = await unitofwork.Personas.ProfEnCadaDepartamento();
        return mapper.Map<List<object>>(Persona);
    }

    [HttpGet("consulta20")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> DepartamentoYProfesor()
    {
        var Persona = await unitofwork.Personas.DepartamentoYProfesor();
        return mapper.Map<List<object>>(Persona);
    }
    
    [HttpGet("consulta25")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> AsignaturaPorProfesor()
    {
        var Persona = await unitofwork.Personas.AsignaturaPorProfesor();
        return mapper.Map<List<object>>(Persona);
    }

    
    [HttpGet("consulta26")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> AlumnoMaJoven()
    {
        var personas = await unitofwork.Personas.AlumnoMaJoven();
        return Ok(personas);
    }

    
    [HttpGet("consulta27")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> ProfesoresSinDepartamentos()
    {
        var personas = await unitofwork.Personas.ProfesoresSinDepartamentos();
        return Ok(personas);
    }
    
    [HttpGet("consulta28")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> DepartamentosSinProfesor()
    {
        var Persona = await unitofwork.Personas.DepartamentosSinProfesor();
        return mapper.Map<List<object>>(Persona);
    }

    
    [HttpGet("consulta29")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> ProfesorConDeptPeroSinAsignatura()
    {
        var Persona = await unitofwork.Personas.ProfesorConDeptPeroSinAsignatura();
        return mapper.Map<List<object>>(Persona);
    }


    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<PersonaDto>> Get(int id)
    {
        var Persona = await unitofwork.Personas.GetByIdAsync(id);
        if (Persona == null)
        {
            return NotFound();
        }
        return this.mapper.Map<PersonaDto>(Persona);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Persona>> Post(PersonaDto PersonaDto)
    {
        var Persona = this.mapper.Map<Persona>(PersonaDto);
        this.unitofwork.Personas.Add(Persona);
        await unitofwork.SaveAsync();
        if (Persona == null)
        {
            return BadRequest();
        }
        PersonaDto.Id = Persona.Id;
        return CreatedAtAction(nameof(Post), new { id = PersonaDto.Id }, PersonaDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<PersonaDto>> Put(int id, [FromBody] PersonaDto PersonaDto)
    {
        if (PersonaDto == null)
        {
            return NotFound();
        }
        var Persona = this.mapper.Map<Persona>(PersonaDto);
        unitofwork.Personas.Update(Persona);
        await unitofwork.SaveAsync();
        return PersonaDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<IActionResult> Delete(int id)
    {
        var Persona = await unitofwork.Personas.GetByIdAsync(id);
        if (Persona == null)
        {
            return NotFound();
        }
        unitofwork.Personas.Remove(Persona);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}