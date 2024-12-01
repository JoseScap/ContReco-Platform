﻿using Libs.SK.Domain.Dtos.Reponses;

namespace Libs.SK.Domain.Entities;

public class User : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime Birthday { get; set; }

    public User()
    {
    }

    public User(string firstName, string lastName, string userName, string email, string password, DateTime birthday)
    {
        FirstName = firstName;
        LastName = lastName;
        UserName = userName;
        Email = email;
        Password = password;
        Birthday = birthday;
    }

    public User(string firstName, string lastName, string userName, string email, string password, DateTime birthday, Guid id, DateTime? createdDate, DateTime? modifiedDate)
        : base (id, createdDate, modifiedDate)
    {
        FirstName = firstName;
        LastName = lastName;
        UserName = userName;
        Email = email;
        Password = password;
        Birthday = birthday;
    }

    public UserCreationResponse AsCreationResponse() => new UserCreationResponse(UserName, Email);
}
