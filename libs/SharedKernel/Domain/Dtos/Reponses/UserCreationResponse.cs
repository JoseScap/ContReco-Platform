namespace Libs.SK.Domain.Dtos.Reponses;

public class UserCreationResponse
{
    public string UserName { get; set; }
    public string Email { get; set; }

    public UserCreationResponse()
    {
    }

    public UserCreationResponse(string userName, string email)
    {
        UserName = userName;
        Email = email;
    }
}
