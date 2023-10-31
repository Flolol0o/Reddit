using Shared.Models;

namespace Reddit.Services;

public interface IAuthService
{
    Task<User> ValidateUser(string username, string password);
}