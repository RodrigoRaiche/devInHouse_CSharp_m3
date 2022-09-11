using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace M3S02_4.Controllers;

[ApiController]
[Route("clientes")]
[Authorize]
public class ConsultasController : ControllerBase
{
    [HttpGet("consultas")]
    [AllowAnonymous]
    public IActionResult GetSemAutenticação()
        => Ok(new
        {
            resultado = "Dados que podem ser acessados sem autenticação."
        });
    
    [HttpGet("consultas/privadas")]
    [Authorize]
    public IActionResult GetLogado()
        => Ok(new
        {
            resultado = "Dados que apenas usuários logados podem ver",
            usuarioLogado = User.FindFirstValue(ClaimTypes.Name)
        });
}