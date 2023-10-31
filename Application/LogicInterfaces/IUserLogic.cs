using Shared.DTOs.User;
using Shared.Models;

namespace Application.LogicInterfaces;

public interface IUserLogic
{
    Task<User> CreateAsync(UserCreationDto dto);
    Task<IEnumerable<User>> GetAsync(UserSearchParametersDto dto);
}