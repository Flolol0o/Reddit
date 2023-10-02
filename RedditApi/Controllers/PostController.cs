using Application.LogicInterfaces;
using Domain;
using Domain.DTOs.Post;
using Microsoft.AspNetCore.Mvc;

namespace Reddit.Controllers;

[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase
{
    private readonly IPostLogic postLogic;
    
    public PostController(IPostLogic logic)
    {
        postLogic = logic;
    }

    [HttpPost]
    public async Task<ActionResult<Post>> CreateAsync([FromBody] PostCreationDto dto)
    {
        try
        {
            Post post = await postLogic.CreateAsync(dto);
            return Created($"/post/{post.Id}", post);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}