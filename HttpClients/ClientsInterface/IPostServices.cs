using Domain;
using Domain.DTOs.Post;

namespace HttpClients.ClientsInterface;

public interface IPostServices
{
    Task Create(PostCreationDto dto);
    Task<Post> GetByIdAsync(int id);
    Task<IEnumerable<Post>> GetPosts(string? titleContains = null);
}