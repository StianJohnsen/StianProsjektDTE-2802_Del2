using System.Security.Principal;
using ProsjektOppgaveWebAPI.Models;

namespace ProsjektOppgaveWebAPI.Services.PostLikeService;

public interface IPostLikeService
{
    Task Save(PostLike postLike, string userId);
    Task Delete(int postLikeId, string userId);
    Task<IEnumerable<PostLike>> GetPostLikeByPostId(int postId);
    PostLike GetPostLikeById(int postLikeId);
    
    PostLike? GetPosLikeByPostIdAndUserId(int postId, string userId);
}