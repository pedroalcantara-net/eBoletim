using eBoletimServer.Domain.Models;
using eBoletimServer.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace eBoletimServer.API.Controllers;

[Route("StudentClasses")]
[ApiController]
public class StudentClassesController : ControllerBase
{
    private IStudentClassesService _studentClasses;
    public StudentClassesController(IStudentClassesService studentClass)
    {
        _studentClasses = studentClass;
    }

    //[HttpGet("{id}")]
    //public async Task<IActionResult> GetclasseById(int id)
    //{
    //    try
    //    {
    //        var classe = await _studentClasses.(id);
    //        if (classe != null) return StatusCode(200, classe);
    //        return StatusCode(400, "Não encontrado");
    //    }
    //    catch (Exception ex)
    //    {
    //        return StatusCode(500, ex.Message);
    //    }
    //}

    [HttpPost("Insert")]
    public async Task<IActionResult> InsertClass(StudentClasses studentClass)
    {
        try
        {
            var result = await _studentClasses.Insert(studentClass);
            return StatusCode(result.Code, result.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPatch("Update")]
    public async Task<IActionResult> UpdateClass(StudentClasses studentClass)
    {
        try
        {
            var result = await _studentClasses.Update(studentClass);
            return StatusCode(result.Code, result.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> DeleteClass(StudentClasses studentClass)
    {
        try
        {
            var result = await _studentClasses.Delete(studentClass);
            return StatusCode(result.Code, result.Message);
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
            var result = await _studentClasses.DeleteById(id);
            return StatusCode(result.Code, result.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}