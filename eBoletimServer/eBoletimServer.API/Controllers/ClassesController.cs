using eBoletimServer.Domain.Models;
using eBoletimServer.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace eBoletimServer.API.Controllers;

[Route("Classes")]
[ApiController]
public class ClassesController : ControllerBase
{
    private IClassesService _classes;
    public ClassesController(IClassesService classe)
    {
        _classes = classe;
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetClassesById(int id)
    {
        try
        {
            var classes = await _classes.GetById(id);
            if (classes != null) return StatusCode(200, classes);
            return StatusCode(404, "Não encontrado");
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("List")]
    public async Task<IActionResult> GetClasses()
    {
        try
        {
            var classes = await _classes.Get();
            if (classes != null) return StatusCode(200, classes);
            return StatusCode(404, "Não encontrado");
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost("Insert")]
    public async Task<IActionResult> InsertClass(Classes classe)
    {
        try
        {
            var result = await _classes.Insert(classe);
            return StatusCode(result.Code, result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPatch("Update")]
    public async Task<IActionResult> UpdateClass(Classes classe)
    {
        try
        {
            var result = await _classes.Update(classe);
            return StatusCode(result.Code, result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> DeleteClass(Classes classe)
    {
        try
        {
            var result = await _classes.Delete(classe);
            return StatusCode(result.Code, result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("{id}/Delete")]
    public async Task<IActionResult> DeleteClassById(int id)
    {
        try
        {
            var result = await _classes.DeleteById(id);
            return StatusCode(result.Code, result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}