using ApiVentas.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiVentas.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ReportesController : ControllerBase
{
    private readonly ReportesService _reportesService;

    public ReportesController(ReportesService reportesService)
    {
        _reportesService = reportesService;
    }

    [HttpGet("movimientos")]
    public async Task<IActionResult> ObtenerMovimientos([FromQuery] string? filtro, [FromQuery] int? id)
    {
        var lista = await _reportesService.ObtenerReporteMovimientosAsync(filtro ?? string.Empty, id ?? 0);
        return Ok(lista);
    }

    [HttpGet("resumen-dia")]
    public async Task<IActionResult> ObtenerResumenDia()
    {
        var resumen = await _reportesService.ObtenerResumenDiaAsync();
        return Ok(resumen);
    }
}
