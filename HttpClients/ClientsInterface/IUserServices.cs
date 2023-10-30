using Domain;
using Domain.DTOs;

namespace HttpClients.ClientsInterface;

public interface IUserServices
{
    Task<User> Create(UserCreationDto dto);
    Task<IEnumerable<User>> GetUsers(string? usernameContains = null);

}