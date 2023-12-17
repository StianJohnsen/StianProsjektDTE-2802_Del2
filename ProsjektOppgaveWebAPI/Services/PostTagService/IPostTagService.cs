using ProsjektOppgaveWebAPI.Models;

namespace ProsjektOppgaveWebAPI.Services.PostTagService;

public interface IPostTagService
{
    Task Save(PostTag postTag);
}