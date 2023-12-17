using Microsoft.AspNetCore.Identity;
using ProsjektOppgaveWebAPI.Data;
using ProsjektOppgaveWebAPI.Models;

namespace ProsjektOppgaveWebAPI.Services.PostTagService;

public class PostTagService: IPostTagService
{
    
    private readonly BlogDbContext _db;
    private readonly UserManager<IdentityUser> _manager;
    
    
    public PostTagService(UserManager<IdentityUser> userManager, BlogDbContext db)
    {
        _manager = userManager;
        _db = db;
    }
    public async Task Save(PostTag postTag)
    {
        Console.WriteLine("hello world!");
        var existingPostTag = _db.PostTag.Find(postTag.Id);
        if (existingPostTag == null)
        {
            _db.PostTag.Add(postTag);
            await _db.SaveChangesAsync();
        }

    }
}