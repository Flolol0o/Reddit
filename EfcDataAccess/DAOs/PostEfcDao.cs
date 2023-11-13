using Application.DaoInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared.Models;

namespace EfcDataAccess.DAOs;

public class PostEfcDao : IPostDao
{
    
    private readonly DbContext context;

    public PostEfcDao(DbContext context)
    {
        this.context = context;
    }
    public async Task<Post> CreateAsync(Post post)
    {
        EntityEntry<Post> added = await context.Posts.AddAsync(post);
        await context.SaveChangesAsync();
        return added.Entity;
    }

    public async Task<IEnumerable<Post>> GetAsync()
    {
        IQueryable<Post> query = context.Posts.Include(todo => todo.User).AsQueryable();
        List<Post> result = await query.ToListAsync();
        return result;
    }

    public async Task<Post?> GetById(int id)
    {
        Post? found = await context.Posts
            .Include(todo => todo.User)
            .SingleOrDefaultAsync(todo => todo.Id == id);
        return found;
    }
}