using M3S01_api.DTO;
using Microsoft.AspNetCore.Mvc;
using M3S01_api.Models;
using M3S01_api.Services;

namespace M3S01_api.Controllers;

[Route("api/[controller]")]
[ApiController]

public class BandasController : ControllerBase
{
    
    private readonly IBandaService _bandaService;

    public BandasController(IBandaService bandaService)
    {
        _bandaService = bandaService;
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<IList<BandaModel>> Get()
    {
        try
        {
            return Ok(_bandaService.GetAll());
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
    public ActionResult<BandaModel> GetById(int id)
    {
        try
        {
            return Ok(_bandaService.GetId(id));
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
    public ActionResult<BandaPostDto> Post(BandaPostDto request)

    {
        try
        {
            var returns = _bandaService.Add(request);
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
    public ActionResult<bool> Put(BandaPutDto request)
    {
        try
        {
            return Ok(_bandaService.Update(request));
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
            return Ok(_bandaService.Delete(id));
        }
        catch (Exception ex)
        {
            return NotFound(ex);
        }

    }

    
}

