using FileData;
using Shared.Models;

namespace Reddit.Services;

public class AuthService : IAuthService
{
    private readonly FileContext context;

    public AuthService(FileContext context)
    {
        this.context = context;
    }


    public Task<User> ValidateUser(string username, string password)
    {
        User? existingUser = context.Users.FirstOrDefault(u =>
            u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

        if (existingUser == null)
        {
            throw new Exception("User not found");
        }

        if (!existingUser.Password.Equals(password))
        {
            throw new Exception("Password mismatch");
        }

        return Task.FromResult(existingUser);
    }
}