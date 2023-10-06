using Mapster;
using MapsterExample.Data;
using MapsterExample.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MapsterExample.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ProductsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get(int productId)
    {
        ProductDto productDto = await _context
            .Products
            .Where(p => p.Id == productId)
            .ProjectToType<ProductDto>()
            .FirstOrDefaultAsync();

        return Ok(productDto);
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _context
            .Products
            .ProjectToType<ProductDto>()
            .ToListAsync();

        return Ok(result);
    }

    [HttpGet("Products")]
    public async Task<IActionResult> Products(int userFavoriteColorId)
    {
        var result = await _context
            .Products
            .ProjectToType<ProductDto>(ProductDto.GetMapsterConfig(userFavoriteColorId))
            .ToListAsync();

        return Ok(result);
    }
}
