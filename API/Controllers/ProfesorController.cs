
using API.Dtos;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ProfesorController : BaseApiController
{
    private readonly IUnitOfWork unitofwork;
    private readonly  IMapper mapper;

    public ProfesorController(IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ProfesorDto>>> Get()
    {
        var Profesor = await unitofwork.Profesores.GetAllAsync();
        return mapper.Map<List<ProfesorDto>>(Profesor);
    }
    
    [HttpGet("consulta10")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> NombresDeDepartamentos()
    {
        var Persona = await unitofwork.Profesores.NombresDeDepartamentos();
        return mapper.Map<List<object>>(Persona);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<ProfesorDto>> Get(int id)
    {
        var Profesor = await unitofwork.Profesores.GetByIdAsync(id);
        if (Profesor == null){
            return NotFound();
        }
        return this.mapper.Map<ProfesorDto>(Profesor);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Profesor>> Post(ProfesorDto ProfesorDto)
    {
        var Profesor = this.mapper.Map<Profesor>(ProfesorDto);
        this.unitofwork.Profesores.Add(Profesor);
        await unitofwork.SaveAsync();
        if(Profesor == null)
        {
            return BadRequest();
        }
        ProfesorDto.Id = Profesor.Id;
        return CreatedAtAction(nameof(Post), new {id = ProfesorDto.Id}, ProfesorDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<ProfesorDto>> Put(int id, [FromBody]ProfesorDto ProfesorDto){
        if(ProfesorDto == null)
        {
            return NotFound();
        }
        var Profesor = this.mapper.Map<Profesor>(ProfesorDto);
        unitofwork.Profesores.Update(Profesor);
        await unitofwork.SaveAsync();
        return ProfesorDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<IActionResult> Delete(int id){
        var Profesor = await unitofwork.Profesores.GetByIdAsync(id);
        if(Profesor == null)
        {
            return NotFound();
        }
        unitofwork.Profesores.Remove(Profesor);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}