using ProsjektOppgaveWebAPI.Models;

namespace ProsjektOppgaveWebAPI.Services.TagServices;

public interface ITagService
{
    Task Save(Tag tag);
    Tag GetTag(string tagContent);
}