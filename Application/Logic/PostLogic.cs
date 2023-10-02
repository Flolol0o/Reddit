using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain;
using Domain.DTOs.Post;

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
        Console.WriteLine("Logic before getting user");
        User? user = await userDao.GetByIdAsync(dto.User);
        Console.WriteLine("Logic after getting user");

        if (user == null)
        {
            Console.WriteLine("Logic user doest exist");
            throw new Exception($"User with username: {dto.User}, was not found.");
        }

        Console.WriteLine($"Loging after user: {user.Username}");

        ValidateTodo(dto);
        Post post = new Post(user,dto.Title,dto.Body);
        Console.WriteLine($"Post created : {post.Title}");
        Post created = await postDao.CreateAsync(post);
        Console.WriteLine($"Post created from post dao: {created.Title}");
        return created;
    }

    private void ValidateTodo(PostCreationDto dto)
    {
        if (string.IsNullOrEmpty(dto.Title)) throw new Exception("Title cannot be empty.");
        if (dto.Title.Length > 31) throw new Exception("Title cannot be longer than 32 characters");
        if (dto.Body.Length > 255) throw new Exception("Body of the post cannot be longer than 256 characters");
        // other validation stuff
    }
}