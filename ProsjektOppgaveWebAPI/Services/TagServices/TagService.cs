using Microsoft.AspNetCore.Identity;
using ProsjektOppgaveWebAPI.Data;
using ProsjektOppgaveWebAPI.Models;

namespace ProsjektOppgaveWebAPI.Services.TagServices;

public class TagService : ITagService
{
    private readonly BlogDbContext _db;
    private readonly UserManager<IdentityUser> _manager;
    
    public TagService(UserManager<IdentityUser> userManager, BlogDbContext db)
    {
        _manager = userManager;
        _db = db;
    }
    
    public async Task Save(Tag tag)
    {
        _db.Tag?.Add(tag);
            await _db.SaveChangesAsync();
        
    }

    public Tag GetTag(string tagContent)
    {
        var existingTag = _db.Tag
            .Where(t => t.content == tagContent)
            .ToList();

        if (existingTag.Count == 0)
        {
            return null;
        }

        return existingTag[0];
    }



}