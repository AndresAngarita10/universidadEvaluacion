
using API.Dtos;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class GradoController : BaseApiController
{
    private readonly IUnitOfWork unitofwork;
    private readonly  IMapper mapper;

    public GradoController(IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<GradoDto>>> Get()
    {
        var Grado = await unitofwork.Grados.GetAllAsync();
        return mapper.Map<List<GradoDto>>(Grado);
    }
    
    [HttpGet("consulta21")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> ListadoGradosYNumAsignaturas()
    {
        var Persona = await unitofwork.Grados.ListadoGradosYNumAsignaturas();
        return mapper.Map<List<object>>(Persona);
    }
    
    [HttpGet("consulta22")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> ListadoGradosYNumAsignaturasMayorA40()
    {
        var Persona = await unitofwork.Grados.ListadoGradosYNumAsignaturasMayorA40();
        return mapper.Map<List<object>>(Persona);
    }
    
    [HttpGet("consulta23")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> GradosConSumaCreditos()
    {
        var Persona = await unitofwork.Grados.GradosConSumaCreditos();
        return mapper.Map<List<object>>(Persona);
    }


    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<GradoDto>> Get(int id)
    {
        var Grado = await unitofwork.Grados.GetByIdAsync(id);
        if (Grado == null){
            return NotFound();
        }
        return this.mapper.Map<GradoDto>(Grado);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Grado>> Post(GradoDto GradoDto)
    {
        var Grado = this.mapper.Map<Grado>(GradoDto);
        this.unitofwork.Grados.Add(Grado);
        await unitofwork.SaveAsync();
        if(Grado == null)
        {
            return BadRequest();
        }
        GradoDto.Id = Grado.Id;
        return CreatedAtAction(nameof(Post), new {id = GradoDto.Id}, GradoDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<GradoDto>> Put(int id, [FromBody]GradoDto GradoDto){
        if(GradoDto == null)
        {
            return NotFound();
        }
        var Grado = this.mapper.Map<Grado>(GradoDto);
        unitofwork.Grados.Update(Grado);
        await unitofwork.SaveAsync();
        return GradoDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<IActionResult> Delete(int id){
        var Grado = await unitofwork.Grados.GetByIdAsync(id);
        if(Grado == null)
        {
            return NotFound();
        }
        unitofwork.Grados.Remove(Grado);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}