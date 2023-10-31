using System.Threading.Channels;
using Application.DaoInterfaces;
using Shared;
using Shared.DTOs;
using Shared.DTOs.User;
using Shared.Models;

namespace FileData.DAOs;

public class UserFileDao : IUserDao
{
    private readonly FileContext context;

    public UserFileDao(FileContext context)
    {
        this.context = context;
    }

    public Task<User> CreateAsync(User user)
    {
        int userId = 1;
        if (context.Users.Any())
        {
            userId = context.Users.Max(u => u.Id);
            userId++;
        }

        user.Id = userId;

        context.Users.Add(user);
        context.SaveChanges();

        return Task.FromResult(user);
    }

    public Task<IEnumerable<User>> GetAsync(UserSearchParametersDto dto)
    {
        IEnumerable<User> users = context.Users.AsEnumerable();
        if (dto.UsernameContains != null)
        {
            users = context.Users.Where(u => u.Username.Contains(dto.UsernameContains, StringComparison.OrdinalIgnoreCase));
        }

        return Task.FromResult(users);
    }


    public Task<User?> GetByUsername(string userName)
    {
        User? existing = context.Users.FirstOrDefault(u =>
            u.Username.Equals(userName, StringComparison.OrdinalIgnoreCase)
        );
        return Task.FromResult(existing);
    }

    public Task<User?> GetByIdAsync(int id)
    {
        Console.WriteLine("User file dao Get by id async");
        User? existing = context.Users.FirstOrDefault(u =>
            u.Id == id
        );
        Console.WriteLine($"User file dao after getting user: {existing.Username}");
        return Task.FromResult(existing);
    }
}