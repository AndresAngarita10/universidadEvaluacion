
using API.Dtos;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class MatriculaController : BaseApiController
{
    private readonly IUnitOfWork unitofwork;
    private readonly  IMapper mapper;

    public MatriculaController(IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MatriculaDto>>> Get()
    {
        var Matricula = await unitofwork.Matriculas.GetAllAsync();
        return mapper.Map<List<MatriculaDto>>(Matricula);
    }
    [HttpGet("consulta9")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> AsignaturasDeXEstudiante()
    {
        var Persona = await unitofwork.Matriculas.AsignaturasDeXEstudiante();
        return mapper.Map<List<object>>(Persona);
    }
    [HttpGet("consulta11")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> AlumnoMatriculadoCurso2018A2019()
    {
        var Persona = await unitofwork.Matriculas.AlumnoMatriculadoCurso2018A2019();
        return mapper.Map<List<object>>(Persona);
    }

    
    [HttpGet("consulta24")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> AlumnosMatriculadosPorCurso()
    {
        var Persona = await unitofwork.Matriculas.AlumnosMatriculadosPorCurso();
        return mapper.Map<List<object>>(Persona);
    }


    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<MatriculaDto>> Get(int id)
    {
        var Matricula = await unitofwork.Matriculas.GetByIdAsync(id);
        if (Matricula == null){
            return NotFound();
        }
        return this.mapper.Map<MatriculaDto>(Matricula);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Matricula>> Post(MatriculaDto MatriculaDto)
    {
        var Matricula = this.mapper.Map<Matricula>(MatriculaDto);
        this.unitofwork.Matriculas.Add(Matricula);
        await unitofwork.SaveAsync();
        if(Matricula == null)
        {
            return BadRequest();
        }
        MatriculaDto.Id = Matricula.Id;
        return CreatedAtAction(nameof(Post), new {id = MatriculaDto.Id}, MatriculaDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<MatriculaDto>> Put(int id, [FromBody]MatriculaDto MatriculaDto){
        if(MatriculaDto == null)
        {
            return NotFound();
        }
        var Matricula = this.mapper.Map<Matricula>(MatriculaDto);
        unitofwork.Matriculas.Update(Matricula);
        await unitofwork.SaveAsync();
        return MatriculaDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<IActionResult> Delete(int id){
        var Matricula = await unitofwork.Matriculas.GetByIdAsync(id);
        if(Matricula == null)
        {
            return NotFound();
        }
        unitofwork.Matriculas.Remove(Matricula);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}