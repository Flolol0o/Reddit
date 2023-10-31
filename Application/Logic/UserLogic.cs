using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Shared.DTOs.User;
using Shared.Models;

namespace Application.Logic;

public class UserLogic : IUserLogic
{
    private readonly IUserDao userDao;

    public UserLogic(IUserDao userDao)
    {
        this.userDao = userDao;
    }

    public async Task<User> CreateAsync(UserCreationDto dto)
    {
        User? existing = await userDao.GetByUsername(dto.Username);
        if (existing != null)
            throw new Exception("Username already taken!");

        ValidateData(dto);
        User toCreate = new User
        {
            Username = dto.Username
        };

        toCreate.Password = dto.Password;

        User created = await userDao.CreateAsync(toCreate);

        return created;
    }

    public Task<IEnumerable<User>> GetAsync(UserSearchParametersDto dto)
    {
        return userDao.GetAsync(dto);
    }

    private static void ValidateData(UserCreationDto dto)
    {
        string userName = dto.Username;

        if (userName.Length < 3)
            throw new Exception("Username must be at least 3 characters!");

        if (userName.Length > 15)
            throw new Exception("Username must be less than 16 characters!");
    }
}