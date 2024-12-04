using UPS.Domain.Dtos.Requests;
using UPS.Domain.Dtos.Responses;

namespace UPS.Domain.IServices;

public interface IUserServices
{
    Task<UserCreationResponse> CreateUserAsync(UserCreationRequest user);
}
