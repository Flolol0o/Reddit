using Shared.Models;

namespace FileData;

public class DataContainer
{
    public ICollection<User> Users { set; get; }
    public ICollection<Post> Posts { set; get; }
}