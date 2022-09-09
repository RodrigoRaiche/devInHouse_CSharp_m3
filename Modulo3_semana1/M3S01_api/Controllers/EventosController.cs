using M3S01_api.DTO;
using Microsoft.AspNetCore.Mvc;
using M3S01_api.Models;
using M3S01_api.Repositories;
using M3S01_api.Services;

namespace M3S01_api.Controllers;

[Route("api/[controller]")]
[ApiController]


public class EventosController : ControllerBase
{
    
    private readonly IEventoService _eventoService;

    public EventosController(IEventoService eventoService)
    {
        _eventoService = eventoService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<IList<BandaModel>> Get()
    {
        try
        {
            return Ok(_eventoService.GetAll());
        }
        catch (Exception ex)
        {
            return NotFound(ex);
        }

    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<EventoModel> GetById(int id)
    {
        try
        {
            return Ok(_eventoService.GetId(id));
        }
        catch (Exception ex)
        {
            return NotFound(ex);
        }

    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<EventoPostDto> Post(EventoPostDto request)

    {
        try
        {
            var returns = _eventoService.Add(request);
            
            if (returns == 0)
            {
                return NotFound();
            } 
            
            return Ok(returns);
        }
        catch (Exception ex)
        {
            return NotFound(ex);
        }

    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<bool> Put(EventoPutDto request)
    {
        try
        {
            return Ok(_eventoService.Update(request));
        }
        catch (Exception ex)
        {
            return NotFound(ex);
        }

    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Delete([FromRoute] int id)
    {
        try
        {
            return Ok(_eventoService.Delete(id));
        }
        catch (Exception ex)
        {
            return NotFound(ex);
        }

    }


    
}