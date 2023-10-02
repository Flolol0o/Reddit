namespace Domain.DTOs.Post;

public class PostCreationDto
{
    public int User { get; }
    public string Title { get; }
    public string Body { get; }
    
    
    public PostCreationDto(int user, string title, string body)
    {
        User = user;
        Title = title;
        Body = body;
    }
}