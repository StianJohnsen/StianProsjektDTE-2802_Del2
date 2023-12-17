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

    public async Task Delete(int postTagId)
    {
        var currentPostTag = _db.PostTag.Find(postTagId);
        _db.PostTag.Remove(currentPostTag);
        await _db.SaveChangesAsync();
    }

    public PostTag? GetPostTag(int postTagId)
    {
        var currentPostTag = _db.PostTag
            .Where(pt => pt.Id == postTagId)
            .FirstOrDefault();
        return currentPostTag;
    }

    public PostTag? GetPostTagById(int postId, int tagId)
    {
        var currentPostTag = _db.PostTag
            .Where(pt => pt.PostId == postId)
            .Where(pt => pt.TagId == tagId)
            .ToList();

        if (currentPostTag.Count == 0)
        {
            return null;
        }
        return currentPostTag[0];
    }
}