using M3S01_api.DTO;
using M3S01_api.Models;
using M3S01_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace M3S01_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FiltrosController : ControllerBase
{
    
    private readonly IEventoService _eventoService;

    public FiltrosController(IEventoService eventoService)
    {
        _eventoService = eventoService;
    }
    
    [HttpGet("Periodo")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<IList<EventoGetPeriodoDto>> GetByPeriodo(DateTime dateMax, DateTime dateMin)
    {
        try
        {
            return Ok(_eventoService.GetByPeriodo(dateMax, dateMin));
        }
        catch (Exception ex)
        {
            return NotFound(ex);
        }

    }


    
}