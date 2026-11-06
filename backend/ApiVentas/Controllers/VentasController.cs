using ApiVentas.DTOs;
using ApiVentas.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiVentas.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class VentasController : ControllerBase
{
    private readonly VentasService _ventasService;

    public VentasController(VentasService ventasService)
    {
        _ventasService = ventasService;
    }

    [HttpGet("pedidos/siguiente-folio")]
    public async Task<IActionResult> ObtenerSiguienteFolio()
    {
        var id = await _ventasService.ObtenerSiguienteFolioAsync();
        return Ok(new { SiguienteId = id });
    }

    [HttpPost("pedidos")]
    public async Task<IActionResult> CrearPedido([FromBody] GenerarPedidoDto dto)
    {
        if (dto.IdCliente <= 0)
        {
            return BadRequest(new { Mensaje = "Debe seleccionar un cliente válido." });
        }
        if (dto.Partidas == null || dto.Partidas.Count == 0)
        {
            return BadRequest(new { Mensaje = "El pedido debe contener al menos un producto." });
        }

        var idUsuarioStr = User.FindFirst("idUsuario")?.Value ?? "1";
        int.TryParse(idUsuarioStr, out int idUsuario);

        try
        {
            var idPedido = await _ventasService.RegistrarPedidoAsync(idUsuario, dto);
            return Ok(new { Exito = true, IdPedido = idPedido, Mensaje = "Pedido generado con éxito." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Mensaje = "Error al generar pedido: " + ex.Message });
        }
    }

    [HttpGet("pedidos")]
    public async Task<IActionResult> ListarPedidos()
    {
        var lista = await _ventasService.ObtenerHistorialPedidosAsync();
        return Ok(lista);
    }

    [HttpGet("pedidos/{id:int}/ticket")]
    public async Task<IActionResult> ObtenerTicket(int id)
    {
        var ticket = await _ventasService.ObtenerDatosTicketAsync(id);
        return Ok(ticket);
    }
}
