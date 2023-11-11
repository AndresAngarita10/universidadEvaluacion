
using API.Dtos;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class CursoEscolarController : BaseApiController
{
    private readonly IUnitOfWork unitofwork;
    private readonly  IMapper mapper;

    public CursoEscolarController(IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<CursoEscolarDto>>> Get()
    {
        var CursoEscolar = await unitofwork.CursoEscolares.GetAllAsync();
        return mapper.Map<List<CursoEscolarDto>>(CursoEscolar);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<CursoEscolarDto>> Get(int id)
    {
        var CursoEscolar = await unitofwork.CursoEscolares.GetByIdAsync(id);
        if (CursoEscolar == null){
            return NotFound();
        }
        return this.mapper.Map<CursoEscolarDto>(CursoEscolar);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<CursoEscolar>> Post(CursoEscolarDto CursoEscolarDto)
    {
        var CursoEscolar = this.mapper.Map<CursoEscolar>(CursoEscolarDto);
        this.unitofwork.CursoEscolares.Add(CursoEscolar);
        await unitofwork.SaveAsync();
        if(CursoEscolar == null)
        {
            return BadRequest();
        }
        CursoEscolarDto.Id = CursoEscolar.Id;
        return CreatedAtAction(nameof(Post), new {id = CursoEscolarDto.Id}, CursoEscolarDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<CursoEscolarDto>> Put(int id, [FromBody]CursoEscolarDto CursoEscolarDto){
        if(CursoEscolarDto == null)
        {
            return NotFound();
        }
        var CursoEscolar = this.mapper.Map<CursoEscolar>(CursoEscolarDto);
        unitofwork.CursoEscolares.Update(CursoEscolar);
        await unitofwork.SaveAsync();
        return CursoEscolarDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<IActionResult> Delete(int id){
        var CursoEscolar = await unitofwork.CursoEscolares.GetByIdAsync(id);
        if(CursoEscolar == null)
        {
            return NotFound();
        }
        unitofwork.CursoEscolares.Remove(CursoEscolar);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}