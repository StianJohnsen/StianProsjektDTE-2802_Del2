using Microsoft.AspNetCore.SignalR;
using ProsjektOppgaveBlazor.data.Models;

namespace ProsjektOppgaveDTE_2802.Hubs;

public class PostHub : Hub
{
    public async Task SendCreatePost(Post post)
    {
        await Clients.All.SendAsync("ReceiveCreatePost",post);
    }
    
    public async Task SendEditPost(Post post)
    {
        await Clients.All.SendAsync("ReceiveEditPost",post);
    }

    public async Task SendDeletePost(int postId)
    {
        await Clients.All.SendAsync("ReceiveDeletePost",postId);
    }
}