using Domain;
using Domain.DTOs.Post;

namespace Application.LogicInterfaces;

public interface IPostLogic
{
    Task<Post> CreateAsync(PostCreationDto dto);
}