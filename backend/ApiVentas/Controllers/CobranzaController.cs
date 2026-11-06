using ApiVentas.DTOs;
using ApiVentas.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiVentas.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class CobranzaController : ControllerBase
{
    private readonly CobranzaService _cobranzaService;

    public CobranzaController(CobranzaService cobranzaService)
    {
        _cobranzaService = cobranzaService;
    }

    [HttpGet("notas-sin-pago")]
    public async Task<IActionResult> ObtenerNotasSinPago()
    {
        var lista = await _cobranzaService.ObtenerNotasSinPagoAsync();
        return Ok(lista);
    }

    [HttpPost("pagos")]
    public async Task<IActionResult> RegistrarPago([FromBody] RegistrarPagoDto dto)
    {
        if (dto.IdCliente <= 0 || dto.IdNotaRemision <= 0 || dto.PagoAplicar <= 0)
        {
            return BadRequest(new { Mensaje = "Datos del pago incompletos o importe no válido." });
        }

        try
        {
            var idPago = await _cobranzaService.RegistrarPagoClienteAsync(dto);
            return Ok(new { Exito = true, IdPago = idPago, Mensaje = "Pago registrado exitosamente." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Mensaje = "Error al procesar cobro: " + ex.Message });
        }
    }

    [HttpGet("pagos")]
    public async Task<IActionResult> HistorialPagos()
    {
        var historial = await _cobranzaService.ObtenerHistorialPagosAsync();
        return Ok(historial);
    }

    [HttpPost("cancelar-remision")]
    public async Task<IActionResult> CancelarRemision([FromBody] CancelarRemisionDto dto)
    {
        if (dto.IdNotaRemision <= 0)
        {
            return BadRequest(new { Mensaje = "Id de nota de remisión no válido." });
        }

        var idCajeroStr = User.FindFirst("idUsuario")?.Value ?? "1";
        int.TryParse(idCajeroStr, out int idCajero);

        try
        {
            var resultado = await _cobranzaService.CancelarNotaRemisionAsync(idCajero, dto);
            return Ok(new { Exito = resultado, Mensaje = "Nota de remisión cancelada correctamente." });
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { Mensaje = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Mensaje = "Error al cancelar la nota: " + ex.Message });
        }
    }
}
