using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

public class Post
{
    [Key]
    public int Id { set; get; }
    public User User {set; get; }
    public int UserId {set; get; }
    public string Title {set; get; }
    public string Body {set; get; }

    public Post(int user, string title, string body)
    {
        this.UserId = user;
        this.Title = title;
        this.Body = body;
    }
    
    public Post(){}
}