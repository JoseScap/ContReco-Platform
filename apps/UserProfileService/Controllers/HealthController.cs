using Microsoft.AspNetCore.Mvc;

namespace UPS.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HealthController : ControllerBase
{
    [HttpGet("[action]")]
    public string Ping() => "Pong";
}
