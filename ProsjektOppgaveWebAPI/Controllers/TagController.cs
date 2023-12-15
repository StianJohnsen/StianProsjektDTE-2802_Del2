using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProsjektOppgaveWebAPI.Models;
using ProsjektOppgaveWebAPI.Models.ViewModel;
using ProsjektOppgaveWebAPI.Services.TagServices;

namespace ProsjektOppgaveWebAPI.Controllers;

[Route("/[controller]")]
[ApiController]
public class TagController : ControllerBase
{
    private readonly ITagService _service;

    public TagController(ITagService service)
    {
        _service = service;
    }


    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TagViewModel tagViewModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var tag = new Tag
        {
            Id = tagViewModel.Id,
            content = tagViewModel.content,
        };
        await _service.Save(tag);

        return Ok();
    }
}