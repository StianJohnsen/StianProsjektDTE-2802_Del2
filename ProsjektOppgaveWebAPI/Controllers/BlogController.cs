using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProsjektOppgaveWebAPI.Models;
using ProsjektOppgaveWebAPI.Models.ViewModel;
using ProsjektOppgaveWebAPI.Services;

namespace ProsjektOppgaveWebAPI.Controllers;

[Route("/[controller]")]
[ApiController]
public class BlogController : ControllerBase
{
    private readonly IBlogService _service;
    
    public BlogController(IBlogService service)
    {
        _service = service;
    }


    [Authorize]
    [HttpGet]
    public async Task<IEnumerable<Blog>> GetAll()
    {
        return await _service.GetAllBlogs();
    }

    [HttpGet]
    [Route("howAreYou")]
    public Task<IdentityUser> howAre(string userName)
    {
        var user = _service.howAreYou(userName);
        return user;
    }


    [HttpGet("{id:int}")]
    public IActionResult Get([FromRoute] int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var blog = _service.GetBlog(id);
        if (blog == null)
        {
            return NotFound();
        }
        return Ok(blog);
    }


    [HttpPost]
    public async Task<IActionResult> Create([FromBody] BlogViewModel blogViewModel)
    {
        
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var blog = new Blog
        {
            BlogId = blogViewModel.BlogId,
            Name = blogViewModel.Name,
            Status = blogViewModel.Status,
            OwnerId = blogViewModel.OwnerId
        };
        
        await _service.Save(blog);

        return CreatedAtAction("Get", new { id = blog.BlogId }, blog);
    }


    [Authorize]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] BlogViewModel blogViewModel)
    {
        if (id != blogViewModel.BlogId)
            return BadRequest();

        var existingBlogViewModel = _service.GetBlog(id);
        
        if (existingBlogViewModel is null)
            return NotFound();
        
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (existingBlogViewModel.OwnerId != userId)
        {
            return Unauthorized();
        }
        
        var blog = new Blog
        {
            BlogId = blogViewModel.BlogId,
            Name = blogViewModel.Name,
            Status = blogViewModel.Status,
            OwnerId = blogViewModel.OwnerId
        };
        
        await _service.Save(blog);
        return NoContent();
    }

    
    [Authorize]
    [HttpDelete("{id:int}")]
    public IActionResult Delete([FromRoute] int id)
    {
        var blog = _service.GetBlog(id);
        if (blog is null)
            return NotFound();
        
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (blog.OwnerId != userId)
        {
            return Unauthorized();
        }

        _service.Delete(id, User);

        return NoContent();
    }
}