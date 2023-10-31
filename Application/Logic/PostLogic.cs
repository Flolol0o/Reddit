using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Shared;
using Shared.DTOs.Post;
using Shared.Models;

namespace Application.Logic;

public class PostLogic : IPostLogic
{
    private readonly IPostDao postDao;
    private readonly IUserDao userDao;

    public PostLogic(IPostDao postDao, IUserDao userDao)
    {
        this.postDao = postDao;
        this.userDao = userDao;
    }

    public async Task<Post> CreateAsync(PostCreationDto dto)
    {
        User? user = await userDao.GetByIdAsync(dto.User);

        if (user == null)
        {
            throw new Exception($"User with username: {dto.User}, was not found.");
        }

        ValidateTodo(dto);
        Post post = new Post(user, dto.Title, dto.Body);
        Post created = await postDao.CreateAsync(post);
        return created;
    }

    public async Task<IEnumerable<Post>> GetAsync()
    {
        return await postDao.GetAsync();
    }

    public async Task<Post> GetAsyncById(int id)
    {
        return await postDao.GetById(id);
    }

    private void ValidateTodo(PostCreationDto dto)
    {
        if (string.IsNullOrEmpty(dto.Title)) throw new Exception("Title cannot be empty.");
        if (dto.Title.Length > 31) throw new Exception("Title cannot be longer than 32 characters");
        if (dto.Body.Length > 255) throw new Exception("Body of the post cannot be longer than 256 characters");
        // other validation stuff
    }
}