using eBoletimServer.API.SignalHub;
using eBoletimServer.API.Timers;
using eBoletimServer.Service.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace eBoletimServer.API.Controllers;

[Route("Results")]
[ApiController]
public class ResultsController : ControllerBase
{
    private readonly TimerManager _timer;

    public ResultsController(IHubContext<ResultsHub> hub, TimerManager timer)
    {
        _timer = timer;
    }

    #region Integração SignalR

    //[HttpGet("{id}")]
    //public async Task<IActionResult> GetResults(int id)
    //{
    //    if (!_timer.IsTimerStarted)
    //        _timer.PrepareTimer(async () =>
    //        {
    //            var results = await ResultsService.GetChartById(id);
    //            await _hub.Clients.All.SendAsync("ReturnResults_" + id, results);
    //        });
    //    return Ok();
    //}
    #endregion

    [HttpGet("List")]
    public async Task<IActionResult> GetAllResults()
    {
        try
        {
            var results = await ResultsService.Get(new Domain.Models.Results());
            if (results != null) return StatusCode(200, results);
            return StatusCode(404, "Não encontrado");
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("{studentId}/list")]
    public async Task<IActionResult> GetResultsByStudentId(int studentId)
    {
        try
        {
            var results = await ResultsService.GetById(studentId);
            if (results != null) return StatusCode(200, results);
            return StatusCode(404, "Não encontrado");
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("{studentId}/chart")]
    public async Task<IActionResult> GetResultsChartByStudentId(int studentId)
    {
        try
        {
            var results = await ResultsService.GetChartById(studentId);
            if (results != null) return StatusCode(200, results);
            return StatusCode(404, "Não encontrado");
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}