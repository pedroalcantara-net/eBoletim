using eBoletimServer.Domain.Models;
using eBoletimServer.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace eBoletimServer.API.Controllers;

[Route("Subjects")]
[ApiController]
public class SubjectsController : ControllerBase
{
    private ISubjectsService _subjects;
    public SubjectsController(ISubjectsService Subject)
    {
        _subjects = Subject;
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetSubjectById(int id)
    {
        try
        {
            var subject = await _subjects.GetById(id);
            if (subject != null) return StatusCode(200, subject);
            return StatusCode(404, "Não encontrado");
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("List")]
    public async Task<IActionResult> GetSubject()
    {
        try
        {
            var Subjects = await _subjects.Get();
            if (Subjects != null) return StatusCode(200, Subjects);
            return StatusCode(404, "Não encontrado");
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost("Insert")]
    public async Task<IActionResult> InsertSubject([FromBody] string subject)
    {
        try
        {
            var result = await _subjects.Insert(subject);
            return StatusCode(result.Code, result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPatch("Update")]
    public async Task<IActionResult> UpdateSubject(Subjects subject)
    {
        try
        {
            var result = await _subjects.Update(subject);
            return StatusCode(result.Code, result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> DeleteSubject(Subjects subject)
    {
        try
        {
            var result = await _subjects.Delete(subject);
            return StatusCode(result.Code, result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("{id}/Delete")]
    public async Task<IActionResult> DeleteSubjectById(int id)
    {
        try
        {
            var result = await _subjects.DeleteById(id);
            return StatusCode(result.Code, result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}