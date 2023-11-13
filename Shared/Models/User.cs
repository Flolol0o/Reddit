using System.Text.Json.Serialization;

namespace Shared.Models;

public class User
{
    public string Username { set; get; }
    public string Password { set; get; }
    public int Id { set; get; }
    
    [JsonIgnore]
    public ICollection<Post> Posts { get; set; }
}