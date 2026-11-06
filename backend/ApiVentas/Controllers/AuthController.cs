using System.Security.Claims;
using ApiVentas.DTOs;
using ApiVentas.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiVentas.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
    {
        var response = await _authService.LoginAsync(request);
        if (!response.Exito)
        {
            return Unauthorized(response);
        }
        return Ok(response);
    }

    [Authorize]
    [HttpGet("menu")]
    public async Task<IActionResult> ObtenerMenu()
    {
        var nomina = User.FindFirst("nomina")?.Value;
        if (string.IsNullOrEmpty(nomina))
        {
            return BadRequest(new { Mensaje = "No se encontró el número de nómina en el token." });
        }

        var jsonMenu = await _authService.ObtenerMenuUsuarioAsync(nomina);
        return Content(jsonMenu, "application/json");
    }

    [Authorize]
    [HttpGet("perfil")]
    public IActionResult ObtenerPerfil()
    {
        return Ok(new
        {
            Usuario = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? User.FindFirst("sub")?.Value,
            Nomina = User.FindFirst("nomina")?.Value,
            Nombre = User.FindFirst("nombre")?.Value,
            Correo = User.FindFirst("correo")?.Value,
            Rol = User.FindFirst(ClaimTypes.Role)?.Value
        });
    }
}
