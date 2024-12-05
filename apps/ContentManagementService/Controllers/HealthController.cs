using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HealthController : ControllerBase
{
    [HttpGet("[action]")]
    public string Ping() => "CMS Pong";
}
