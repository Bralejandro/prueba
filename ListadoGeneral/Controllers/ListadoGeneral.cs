using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

[Route("api/[controller]")]
[ApiController]
public class ListadoGeneralController : ControllerBase
{
    private readonly AppDbContext _context;

    public ListadoGeneralController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetListadoGeneral()
    {
        var listado = await _context.Tabla1
            .Select(t1 => new
            {
                t1.Id,
                t1.Apellido,
                t1.FechaCreacion,
                // Otras propiedades de Tabla1
            })
            .Union(_context.Tabla2.Select(t2 => new
            {
                t2.Id,
                t2.Apellido,
                t2.FechaCreacion,
                // Otras propiedades de Tabla2
            }))
            .OrderBy(x => x.FechaCreacion)
            .ThenBy(x => x.Apellido)
            .ToListAsync();

        return Ok(listado);
    }
}
