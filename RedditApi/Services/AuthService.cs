
using EfcDataAccess;
using Shared.Models;

namespace Reddit.Services;

public class AuthService : IAuthService
{
    private readonly DbContext context;

    public AuthService(DbContext context)
    {
        this.context = context;
    }


    public Task<User> ValidateUser(string username, string password)
    {
        User? existingUser = context.Users.FirstOrDefault(u =>
            u.Username.Equals(username));

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