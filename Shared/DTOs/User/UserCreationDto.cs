namespace Shared.DTOs.User;

public class UserCreationDto
{
    public string Username { get;}
    public string Password { get; }
    public int Id { get; }

    public UserCreationDto(string username, string password, int id)
    {
        Username = username;
        Password = password;
        Id = id;
    }
}