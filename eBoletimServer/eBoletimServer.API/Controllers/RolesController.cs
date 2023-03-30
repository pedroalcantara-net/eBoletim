using eBoletimServer.Domain.Models;
using eBoletimServer.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace eBoletimServer.API.Controllers;

[Route("Roles")]
[ApiController]
public class RolesController : ControllerBase
{

    private IRolesService _roles;
    public RolesController(IRolesService roles)
    {
        _roles = roles;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRolesById(int id)
    {
        try
        {
            var Roles = await _roles.GetById(id);
            if (Roles != null) return StatusCode(200, Roles);
            return StatusCode(404, "Não encontrado");
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost("Insert")]
    public async Task<IActionResult> InsertRole(string role)
    {
        try
        {
            var result = await _roles.Insert(role);
            return StatusCode(result.Code, result.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPatch("Update")]
    public async Task<IActionResult> UpdateRole(Roles roles)
    {
        try
        {
            var result = await _roles.Update(roles);
            return StatusCode(result.Code, result.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> DeleteRole(Roles roles)
    {
        try
        {
            var result = await _roles.Delete(roles);
            return StatusCode(result.Code, result.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("{id}/Delete")]
    public async Task<IActionResult> DeleteRoleById(int id)
    {
        try
        {
            var result = await _roles.DeleteById(id);
            return StatusCode(result.Code, result.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}