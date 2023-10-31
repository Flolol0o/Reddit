using Shared;
using Shared.DTOs;
using Shared.DTOs.User;
using Shared.Models;

namespace Application.DaoInterfaces;

public interface IUserDao
{
    Task<User> CreateAsync(User user);
    Task<IEnumerable<User>> GetAsync(UserSearchParametersDto dto);

    Task<User?> GetByUsername(string dtoUsername);

    Task<User?> GetByIdAsync(int id);
}