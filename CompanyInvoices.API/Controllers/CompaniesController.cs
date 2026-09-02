using System.Security.Claims;
using CompanyInvoices.Core.Interfaces;
using CompanyInvoices.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CompanyInvoices.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CompaniesController : ControllerBase
{
    private readonly ICompanyRepository _repo;
    private readonly IPermissionService _permissions;

    public CompaniesController(ICompanyRepository repo, IPermissionService permissions)
    {
        _repo = repo;
        _permissions = permissions;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        if (!await CheckAsync(PermissionTypes.View))
        {
            return Forbid();
        }

        return Ok(await _repo.GetAllAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        if (!await CheckAsync(PermissionTypes.View))
        {
            return Forbid();
        }

        var company = await _repo.GetByIdAsync(id);
        return company is null ? NotFound() : Ok(company);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CompanyEdit model)
    {
        if (!await CheckAsync(PermissionTypes.Create))
        {
            return Forbid();
        }

        var id = await _repo.InsertAsync(model);
        return CreatedAtAction(nameof(Get), new { id }, null);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] CompanyEdit model)
    {
        if (!await CheckAsync(PermissionTypes.Edit))
        {
            return Forbid();
        }

        await _repo.UpdateAsync(id, model);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        if (!await CheckAsync(PermissionTypes.Delete))
        {
            return Forbid();
        }

        await _repo.DeleteAsync(id);
        return NoContent();
    }

    private async Task<bool> CheckAsync(string permissionType)
    {
        var userIdValue = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!int.TryParse(userIdValue, out var userId))
        {
            return false;
        }

        return await _permissions.HasPermissionAsync(userId, SecurityObjects.Company, permissionType);
    }
}
