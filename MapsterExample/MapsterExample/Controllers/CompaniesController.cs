using Mapster;
using MapsterExample.Data;
using MapsterExample.Dto;
using MapsterExample.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MapsterExample.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompaniesController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public CompaniesController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(int companyId)
    {
        var result = await _context
            .Companies
            .Where(c => c.Id == companyId)
            .ProjectToType<CompanyResultDto>()
            .ToListAsync();

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CompanyDto dto)
    {
        Company company = dto.Adapt<Company>();

        _context.Add(company);

        await _context.SaveChangesAsync();

        return Ok(company);
    }
}
