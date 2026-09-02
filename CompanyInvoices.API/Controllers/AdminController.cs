using System.Security.Claims;
using CompanyInvoices.Core.Interfaces;
using CompanyInvoices.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CompanyInvoices.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class AdminController : ControllerBase
{
    private readonly IPermissionRepository _repo;
    private readonly IPermissionService _service;

    public AdminController(IPermissionRepository repo, IPermissionService service)
    {
        _repo = repo;
        _service = service;
    }

    [HttpGet("users/{userId:int}/permissions")]
    public async Task<IActionResult> GetByUser(int userId)
    {
        if (!await CheckAsync(PermissionTypes.ManagePermissions))
        {
            return Forbid();
        }

        return Ok(await _repo.GetByUserAsync(userId));
    }

    [HttpPost("permissions")]
    public async Task<IActionResult> Add([FromBody] PermissionEdit model)
    {
        if (!await CheckAsync(PermissionTypes.ManagePermissions))
        {
            return Forbid();
        }

        await _repo.AddAsync(model);
        _service.InvalidateCache(model.UserId);
        return NoContent();
    }

    [HttpDelete("permissions/{id:int}")]
    public async Task<IActionResult> Delete(int id, [FromQuery] int userId)
    {
        if (!await CheckAsync(PermissionTypes.ManagePermissions))
        {
            return Forbid();
        }

        await _repo.DeleteAsync(id);
        _service.InvalidateCache(userId);
        return NoContent();
    }

    [HttpGet("security-objects")]
    public async Task<IActionResult> GetSecurityObjects()
    {
        if (!await CheckAsync(PermissionTypes.ManagePermissions))
        {
            return Forbid();
        }

        return Ok(await _repo.GetSecurityObjectsAsync());
    }

    [HttpGet("permission-types")]
    public async Task<IActionResult> GetPermissionTypes()
    {
        if (!await CheckAsync(PermissionTypes.ManagePermissions))
        {
            return Forbid();
        }

        return Ok(await _repo.GetPermissionTypesAsync());
    }

    private async Task<bool> CheckAsync(string permissionType)
    {
        var userIdValue = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!int.TryParse(userIdValue, out var userId))
        {
            return false;
        }

        return await _service.HasPermissionAsync(userId, SecurityObjects.Admin, permissionType);
    }
}
