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
}