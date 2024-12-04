namespace UPS.Domain.Dtos.Responses;

public class UserCreationResponse
{
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public UserCreationResponse()
    {
    }

    public UserCreationResponse(string userName, string email)
    {
        UserName = userName;
        Email = email;
    }
}
