using ProsjektOppgaveWebAPI.Models;

namespace ProsjektOppgaveWebAPI.Services.PostTagService;

public interface IPostTagService
{
    Task Save(PostTag postTag);

    Task Delete(int postTagId);

    PostTag GetPostTag(int postTagId);

    PostTag GetPostTagById(int postId, int tagId);
}