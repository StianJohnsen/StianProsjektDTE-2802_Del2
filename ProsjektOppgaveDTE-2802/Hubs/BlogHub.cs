using Microsoft.AspNetCore.SignalR;
using ProsjektOppgaveBlazor.data.Models;
using ProsjektOppgaveBlazor.data.Models.ViewModel;

namespace ProsjektOppgaveDTE_2802.Hubs;

public class BlogHub: Hub
{
    public async Task SendCreateBlog(Blog blog)
    {
        await Clients.All.SendAsync("ReceiveCreateBlog",blog);
    }
    
    public async Task SendEditBlog(Blog blog)
    {
        await Clients.All.SendAsync("ReceiveEditBlog",blog);
    }

    public async Task SendDeleteBlog(int blogId)
    {
        await Clients.All.SendAsync("ReceiveDeleteBlog",blogId);
    }
    
}