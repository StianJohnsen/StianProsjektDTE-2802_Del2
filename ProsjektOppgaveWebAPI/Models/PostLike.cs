using Microsoft.AspNetCore.Identity;

namespace ProsjektOppgaveWebAPI.Models;

public class PostLike
{
    public int PostLikeId { get; set; }
    
    public string UserId { get; set; }
    public IdentityUser User { get; set; }

    public int PostId { get; set; }
    public Post Post { get; set; }
    
}