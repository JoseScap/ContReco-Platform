﻿using Microsoft.AspNetCore.Mvc;

namespace UPS.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HealthController : ControllerBase
{
    [HttpGet("[action]")]
    public string Ping() => "UPS Pong";
}
