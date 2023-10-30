namespace Domain.DTOs.Post;

public class PostBasicDto
{
    public int User { get; }
    public int Id { get; }
    public string Title { get; }
    public string Body { get; }
    
    
    public PostBasicDto(int user,int id, string title, string body)
    {
        Id = id;
        User = user;
        Title = title;
        Body = body;
    }
}