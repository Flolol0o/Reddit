using System.Net.Http.Json;
using System.Text.Json;
using HttpClients.ClientsInterface;
using Shared.DTOs.Post;
using Shared.Models;

namespace HttpClients.Implementations;

public class PostHttpClient : IPostServices
{
    private readonly HttpClient Client;

    public PostHttpClient(HttpClient client)
    {
        Client = client;
    }

    public async Task Create(PostCreationDto dto)
    {
        HttpResponseMessage responseMessage = await Client.PostAsJsonAsync("/post", dto);
        if (!responseMessage.IsSuccessStatusCode)
        {
            string content = await responseMessage.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
    }

    public async Task<Post> GetByIdAsync(int id)
    {
        Console.WriteLine("is it good");
        HttpResponseMessage response = await Client.GetAsync($"/Post/{id}");
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        Console.WriteLine("wtff");
        Post post = JsonSerializer.Deserialize<Post>(content,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }
        )!;

        return post;
    }

    public async Task<IEnumerable<Post>> GetPosts(string? titleContains = null)
    {
        string uri = "/post";
        if (!string.IsNullOrEmpty(titleContains))
        {
            uri += $"?title={titleContains}";
        }

        Console.WriteLine("Testing3");
        HttpResponseMessage response = await Client.GetAsync(uri);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        Console.WriteLine("Testing");
        ICollection<Post> posts = JsonSerializer.Deserialize<ICollection<Post>>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return posts;
    }
}