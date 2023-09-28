using Domain;
using Domain.DTOs;

namespace Application.DaoInterfaces;

public interface IUserDao
{
    Task<User> CreateAsync(User user);
    Task<IEnumerable<User>> GetAsync(UserSearchParametersDto dto);

    Task<User?> GetByUsername(string dtoUsername);
}