using Microsoft.AspNetCore.SignalR;
using ProsjektOppgaveBlazor.data.Models;
using ProsjektOppgaveBlazor.data.Models.ViewModel;

namespace ProsjektOppgaveDTE_2802.Hubs;

public class ChatHub: Hub
{
    public async Task SendMessage(BlogViewModel blogViewModel, string username)
    {
        await Clients.All.SendAsync("ReceiveMessage",blogViewModel, username);
    }
    
}