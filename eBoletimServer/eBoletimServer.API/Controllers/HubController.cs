using eBoletimServer.API.SignalHub;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace eBoletimServer.API.Controllers;

[Route("hub")]
[ApiController]
public class HubController : ControllerBase
{
    private readonly IHubContext<BaseHub> _hub;

    public HubController(IHubContext<BaseHub> hub)
    {
        _hub = hub;
    }

    [HttpGet]
    public IActionResult Get()
    {
        _hub.Clients.All.SendAsync("aa", "oi");
        return Ok(new { Message = "Request Completed" });
    }
}