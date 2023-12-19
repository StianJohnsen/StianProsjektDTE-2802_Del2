using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProsjektOppgaveWebAPI.Models;
using ProsjektOppgaveWebAPI.Models.ViewModel;
using ProsjektOppgaveWebAPI.Services.PostLikeService;

namespace ProsjektOppgaveWebAPI.Controllers;

[Route("/[controller]")]
[ApiController]
public class PostLikeController : ControllerBase
{
    private readonly IPostLikeService _service;
    
    public PostLikeController (IPostLikeService service)
    {
        _service = service;
    }

    [Authorize]
    [HttpPost("{postId:int}")]
    public async Task<IActionResult> Create([FromRoute] int postId, [FromBody] PostLikeViewModel postLikeViewModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
        var postLike = new PostLike
        {
            PostLikeId = postLikeViewModel.PostLikeId,
            UserId = postLikeViewModel.UserId,
            PostId = postId
        };

        await _service.Save(postLike,userId);
        return CreatedAtAction("GetPostLike", new { id = postId }, postLike);
    }
    
    [Authorize]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var postLike = _service.GetPostLikeById(id);
        
        if (postLike == null)
        {
            return NotFound();
        }
        var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
        if (postLike.UserId != userId)
        {
            return Unauthorized();
        }
        await _service.Delete(id,userId);
        return Ok(postLike);
    }
    
    [HttpGet("{id:int}")]
    public PostLike? GetPostLike([FromRoute] int id)
    {
        return _service.GetPostLikeById(id);
    }
    
    [HttpGet]
    public Task<IEnumerable<PostLike>> GetPostLikeByPostId( int postId)
    {
        return _service.GetPostLikeByPostId(postId);
    }
    
    [HttpGet("/GetByPostNdUserId")]
    public PostLike? GetPostLikeByPostIdAndUserId(int postId,string userId )
    {
        return _service.GetPosLikeByPostIdAndUserId(postId,userId);
    }
    
}