using ApiVentas.DTOs;
using ApiVentas.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiVentas.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class CatalogosController : ControllerBase
{
    private readonly CatalogosService _catalogosService;

    public CatalogosController(CatalogosService catalogosService)
    {
        _catalogosService = catalogosService;
    }

    [HttpGet("productos")]
    public async Task<IActionResult> ObtenerProductos([FromQuery] string? filtro)
    {
        var lista = await _catalogosService.ObtenerProductosAsync(filtro);
        return Ok(lista);
    }

    [HttpPost("productos")]
    public async Task<IActionResult> GuardarProducto([FromBody] GuardarProductoDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Nombre) || string.IsNullOrWhiteSpace(dto.Clave))
        {
            return BadRequest(new { Mensaje = "La clave y el nombre del producto son requeridos." });
        }

        var res = await _catalogosService.GuardarProductoAsync(dto);
        if (res == 0)
        {
            return Ok(new { Mensaje = "Producto guardado correctamente." });
        }
        if (res == 2)
        {
            return Conflict(new { Mensaje = "El producto con ese nombre o clave ya existe." });
        }
        return StatusCode(500, new { Mensaje = "Ocurrió un error al guardar el producto." });
    }

    [HttpDelete("productos/{id:int}")]
    public async Task<IActionResult> EliminarProducto(int id)
    {
        var res = await _catalogosService.EliminarProductoAsync(id);
        if (res == 0)
        {
            return Ok(new { Mensaje = "Producto eliminado correctamente." });
        }
        return BadRequest(new { Mensaje = "No se pudo eliminar el producto." });
    }

    [HttpGet("clientes")]
    public async Task<IActionResult> ObtenerClientes([FromQuery] string? filtro)
    {
        var lista = await _catalogosService.ObtenerClientesAsync(filtro);
        return Ok(lista);
    }
}
