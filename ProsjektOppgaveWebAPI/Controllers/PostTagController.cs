using Microsoft.AspNetCore.Mvc;
using ProsjektOppgaveWebAPI.Models;
using ProsjektOppgaveWebAPI.Models.ViewModel;
using ProsjektOppgaveWebAPI.Services.PostTagService;

namespace ProsjektOppgaveWebAPI.Controllers;

[Route("/[controller]")]
[ApiController]
public class PostTagController : ControllerBase
{
    private readonly IPostTagService _service;
    
    public PostTagController(IPostTagService service)
    {
        _service = service;
    }


    [HttpGet]
    public async Task<PostTag> GetPostTag(int postId, int tagId)
    {
        return _service.GetPostTagById(postId, tagId);
    }


    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PostTagViewModel postTagViewModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var postTag = new PostTag
        {
            Id = postTagViewModel.Id,
            PostId = postTagViewModel.PostId,
            TagId = postTagViewModel.TagId,
        };
        await _service.Save(postTag);

        return Ok();
    }

    [HttpDelete("{postTagId}")]
    public async Task<IActionResult> Delete([FromRoute] int postTagId)
    {
        var postTag = _service.GetPostTag(postTagId);
        if (postTag is null)
        {
            return NotFound();
        }

        await _service.Delete(postTagId);
        return NoContent();
    }
}