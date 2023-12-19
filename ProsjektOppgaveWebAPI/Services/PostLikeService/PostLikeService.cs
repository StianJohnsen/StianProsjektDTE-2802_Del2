using System.Security.Principal;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProsjektOppgaveWebAPI.Data;
using ProsjektOppgaveWebAPI.Models;

namespace ProsjektOppgaveWebAPI.Services.PostLikeService;

public class PostLikeService : IPostLikeService
{

    private readonly BlogDbContext _db;
    private readonly UserManager<IdentityUser> _manager;
    
    
    public PostLikeService(UserManager<IdentityUser> userManager, BlogDbContext db)
    {
        _manager = userManager;
        _db = db;
    }
    
    
    public async Task Save(PostLike postLike, string userId)
    {
        var existingPostLike = _db.PostLike.Find(postLike.PostLikeId);
        var isLiked = GetPostLikeByPostId(postLike.PostId).Result;
        var isLikedByUser = isLiked.Where(pl => pl.UserId == userId);
        if (existingPostLike == null && isLikedByUser.Count() == 0 && postLike.UserId == userId )
        {
            _db.PostLike.Add(postLike);
            await _db.SaveChangesAsync();
        }
    }

    public async Task Delete(int postLikeId, string userId)
    {
        var currentPostLike = _db.PostLike.Find(postLikeId);
        if (currentPostLike.UserId == userId && currentPostLike != null)
        {
            _db.PostLike.Remove(currentPostLike);
            await _db.SaveChangesAsync();
        }
        else
        {
            throw new UnauthorizedAccessException("You are not the owner of this post.");
        }

    }

    public async Task<IEnumerable<PostLike>> GetPostLikeByPostId(int postId)
    {
        var postLikes = _db.PostLike
            .Where(pl => pl.PostId == postId)
            .ToList();
        return postLikes;
    }

    public PostLike? GetPostLikeById(int postLikeId)
    {
        var currentPostLike = _db.PostLike.Find(postLikeId);
        return currentPostLike;
        
    }

    public PostLike? GetPosLikeByPostIdAndUserId(int postId, string userId)
    {
        var currentPostLike = _db.PostLike
            .Where(pl => pl.PostId == postId)
            .Where(pl => pl.UserId == userId)
            .ToList();
        if (currentPostLike.Count == 0)
        {
            return null;
        }
        return currentPostLike[0];
    }
}