using Shared;
using Shared.DTOs;
using Shared.DTOs.User;
using Shared.Models;

namespace HttpClients.ClientsInterface;

public interface IUserServices
{
    Task<User> Create(UserCreationDto dto);
    Task<IEnumerable<User>> GetUsers(string? usernameContains = null);

}