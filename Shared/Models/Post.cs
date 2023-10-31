namespace Shared.Models;

public class Post
{
    public User User { set; get; }
    public string Title { set; get; }
    public string Body { set; get; }
    public int Id { set; get; }

    public Post(User user, string title, string body)
    {
        this.User = user;
        this.Title = title;
        this.Body = body;
    }
}