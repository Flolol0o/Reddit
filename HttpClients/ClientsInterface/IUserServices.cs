using Shared.Models;

namespace HttpClients.ClientsInterface;

public interface IUserServices
{
    Task<IEnumerable<User>> GetUsers(string? usernameContains = null);
}