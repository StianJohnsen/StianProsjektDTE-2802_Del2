using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProsjektOppgaveWebAPI.Models;
using ProsjektOppgaveWebAPI.Models.ViewModel;
using ProsjektOppgaveWebAPI.Services.CommentServices;

namespace ProsjektOppgaveWebAPI.Controllers;

[Route("/[controller]")]
[ApiController]
public class CommentController : ControllerBase
{
    private readonly ICommentService _service;

    public CommentController(ICommentService service)
    {
        _service = service;
    }
    
    
    [HttpGet]
    public async Task<IEnumerable<Comment>> GetComments(int postId)
    {
        return await _service.GetCommentsForPost(postId);
    }
    
    
    [HttpGet("{id:int}")]
    public Comment? GetComment([FromRoute] int id)
    {
        return _service.GetComment(id);
    }
    
    
    [Authorize]
    [HttpPost("{postId:int}")]
    public async Task<IActionResult> Create([FromRoute] int postId,[FromBody] CommentViewModel commentViewModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var comment = new Comment
        {
            CommentId = commentViewModel.CommentId,
            Text = commentViewModel.Text,
            OwnerId = commentViewModel.OwnerId,
            PostId = postId
        };
        await _service.Save(comment, User);
        return CreatedAtAction("GetComment", new { id = postId }, commentViewModel);
    }
    
    
    [Authorize]
    [HttpPut("{id:int}")]
    public IActionResult Update([FromRoute] int id, [FromBody] CommentViewModel commentViewModel)
    {
        if (id != commentViewModel.CommentId)
            return BadRequest();

        var existingComment = _service.GetComment(id);
        if (existingComment is null)
            return NotFound();
        
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (existingComment.OwnerId != userId)
        {
            return Unauthorized();
        }
        
        var comment = new Comment
        {
            CommentId = commentViewModel.CommentId,
            Text = commentViewModel.Text,
            OwnerId = commentViewModel.OwnerId,
            PostId = commentViewModel.PostId
        };

        _service.Save(comment, User);

        return NoContent();
    }
    
    
    [Authorize]
    [HttpDelete("{id:int}")]
    public IActionResult Delete([FromRoute] int id)
    {
        var comment = _service.GetComment(id);
        if (comment is null)
            return NotFound();
        
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (comment.OwnerId != userId)
        {
            return Unauthorized();
        }

        _service.Delete(id, User);

        return NoContent();
    }
}