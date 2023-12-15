using Microsoft.AspNetCore.SignalR;
using ProsjektOppgaveBlazor.data.Models;

namespace ProsjektOppgaveDTE_2802.Hubs;

public class CommentHub : Hub
{
    public async Task SendCreateComment(Comment comment)
    {
        await Clients.All.SendAsync("ReceiveCreateComment",comment);
    }
    
    public async Task SendEditComment(Comment comment)
    {
        await Clients.All.SendAsync("ReceiveEditComment",comment);
    }

    public async Task SendDeleteComment(int commentId)
    {
        await Clients.All.SendAsync("ReceiveDeleteComment",commentId);
    }
}