
using API.Dtos;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class AsignaturaController : BaseApiController
{
    private readonly IUnitOfWork unitofwork;
    private readonly  IMapper mapper;

    public AsignaturaController(IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<AsignaturaDto>>> Get()
    {
        var Asignatura = await unitofwork.Asignaturas.GetAllAsync();
        return mapper.Map<List<AsignaturaDto>>(Asignatura);
    }
    
    [HttpGet("consulta5")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> AsignaturaCuatrimestreYId7()
    {
        var Persona = await unitofwork.Asignaturas.AsignaturaCuatrimestreYId7();
        return mapper.Map<List<object>>(Persona);
    }
    [HttpGet("consulta7")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> AsignaturaDeIngInformatica()
    {
        var Persona = await unitofwork.Asignaturas.AsignaturaDeIngInformatica();
        return mapper.Map<List<object>>(Persona);
    }

    
    [HttpGet("consulta30")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> AsignaturaSinPrfesor()
    {
        var Persona = await unitofwork.Asignaturas.AsignaturaSinPrfesor();
        return mapper.Map<List<object>>(Persona);
    }


    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<AsignaturaDto>> Get(int id)
    {
        var Asignatura = await unitofwork.Asignaturas.GetByIdAsync(id);
        if (Asignatura == null){
            return NotFound();
        }
        return this.mapper.Map<AsignaturaDto>(Asignatura);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Asignatura>> Post(AsignaturaDto AsignaturaDto)
    {
        var Asignatura = this.mapper.Map<Asignatura>(AsignaturaDto);
        this.unitofwork.Asignaturas.Add(Asignatura);
        await unitofwork.SaveAsync();
        if(Asignatura == null)
        {
            return BadRequest();
        }
        AsignaturaDto.Id = Asignatura.Id;
        return CreatedAtAction(nameof(Post), new {id = AsignaturaDto.Id}, AsignaturaDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<AsignaturaDto>> Put(int id, [FromBody]AsignaturaDto AsignaturaDto){
        if(AsignaturaDto == null)
        {
            return NotFound();
        }
        var Asignatura = this.mapper.Map<Asignatura>(AsignaturaDto);
        unitofwork.Asignaturas.Update(Asignatura);
        await unitofwork.SaveAsync();
        return AsignaturaDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<IActionResult> Delete(int id){
        var Asignatura = await unitofwork.Asignaturas.GetByIdAsync(id);
        if(Asignatura == null)
        {
            return NotFound();
        }
        unitofwork.Asignaturas.Remove(Asignatura);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}
