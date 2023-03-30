using eBoletimServer.API.SignalHub;
using eBoletimServer.Domain.Models;
using eBoletimServer.Service.Interface;
using eBoletimServer.Service.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace eBoletimServer.API.Controllers;

[Route("Grade")]
[ApiController]
public class GradesController : ControllerBase
{
    private IGradesService _grades;
    private readonly IHubContext<ResultsHub> _hub;

    public GradesController(IGradesService grades, IHubContext<ResultsHub> hub)
    {
        _hub = hub;
        _grades = grades;
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetGradeById(int id)
    {
        try
        {
            var grade = await _grades.GetById(id);
            if (grade != null) return StatusCode(200, grade);
            return StatusCode(404, "Não encontrado");
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("List")]
    public async Task<IActionResult> GetGrades()
    {
        try
        {
            var grades = await _grades.Get();
            if (grades != null) return StatusCode(200, grades);
            return StatusCode(404, "Não encontrado");
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost("Insert")]
    public async Task<IActionResult> InsertGrade(Grades grade)
    {
        try
        {
            var result = await _grades.Insert(grade);
            if (result.Status)
            {
                await _hub.Clients.All.SendAsync("NewResults_" + grade.StudentId, await ResultsService.GetChartById(grade.StudentId));
            }
            return StatusCode(result.Code, result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPatch("Update")]
    public async Task<IActionResult> UpdateGrade(Grades grade)
    {
        try
        {
            var result = await _grades.Update(grade);
            if (result.Status)
            {
                await _hub.Clients.All.SendAsync("NewResults_" + grade.StudentId, await ResultsService.GetChartById(grade.StudentId));
            }
            return StatusCode(result.Code, result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> DeleteGrade(Grades grade)
    {
        try
        {
            var result = await _grades.Delete(grade);
            return StatusCode(result.Code, result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("{id}/Delete")]
    public async Task<IActionResult> DeleteGradeById(int id)
    {
        try
        {
            var result = await _grades.DeleteById(id);
            return StatusCode(result.Code, result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("Alert/{id}")]
    public async void Alert(int id)
    {
        await _hub.Clients.All.SendAsync("NewResults_" + id, await ResultsService.GetChartById(id));
    }
}