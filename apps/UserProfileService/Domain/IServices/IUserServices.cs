using Libs.SK.Domain.Dtos.Reponses;
using Libs.SK.Domain.Dtos.Requests;

namespace UPS.Domain.IServices;

public interface IUserServices
{
    Task<UserCreationResponse> CreateUserAsync(UserCreationRequest user);
}
