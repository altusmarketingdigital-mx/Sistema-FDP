using ApiVentas.DTOs;
using ApiVentas.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiVentas.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class SeguridadController : ControllerBase
{
    private readonly SeguridadService _seguridadService;

    public SeguridadController(SeguridadService seguridadService)
    {
        _seguridadService = seguridadService;
    }

    [HttpGet("usuarios")]
    public async Task<IActionResult> ObtenerUsuarios()
    {
        var lista = await _seguridadService.ObtenerUsuariosAsync();
        return Ok(lista);
    }

    [HttpPost("bitacora")]
    public async Task<IActionResult> RegistrarEvento([FromBody] RegistrarBitacoraDto dto)
    {
        var idUsuarioStr = User.FindFirst("idUsuario")?.Value ?? "1";
        int.TryParse(idUsuarioStr, out int idUsuario);

        var ok = await _seguridadService.RegistrarBitacoraAsync(idUsuario, dto);
        return Ok(new { Exito = ok });
    }
}
