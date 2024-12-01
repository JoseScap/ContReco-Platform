using Libs.SK.Domain.Dtos.Reponses;
using Libs.SK.Domain.Dtos.Requests;
using Microsoft.AspNetCore.Mvc;
using UPS.Domain.IServices;

namespace UPS.Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserServices _userServices;

    public UsersController(IUserServices userServices)
    {
        _userServices = userServices;
    }

    [HttpPost]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UserCreationResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<CreatedAtActionResult> CreateUser([FromBody] UserCreationRequest request)
    {
        var createdUser = await _userServices.CreateUserAsync(request);
        return CreatedAtAction(nameof(CreateUser), createdUser);
    }
}
