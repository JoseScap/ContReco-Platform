using System.ComponentModel.DataAnnotations;
using UPS.Domain.Entities;

namespace UPS.Domain.Dtos.Requests;

public class UserCreationRequest
{
    [Required]
    [StringLength(maximumLength: 50, MinimumLength = 2)]
    public string FirstName { get; set; }
    [Required]
    [StringLength(maximumLength: 50, MinimumLength = 2)]
    public string LastName { get; set; }
    [Required]
    [StringLength(maximumLength: 50, MinimumLength = 8)]
    public string UserName { get; set; }
    [Required]
    [StringLength(maximumLength: 50, MinimumLength = 10)]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public DateTime Birthday { get; set; }

    public UserCreationRequest()
    {
    }

    public UserCreationRequest(string firstName, string lastName, string userName, string email, string password, DateTime birthday)
    {
        FirstName = firstName;
        LastName = lastName;
        UserName = userName;
        Email = email;
        Password = password;
        Birthday = birthday;
    }

    public User AsUserEntity() => new User(FirstName, LastName, UserName, Email, Password, Birthday);
}
