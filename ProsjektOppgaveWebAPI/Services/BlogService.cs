using System.Security.Principal;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProsjektOppgaveWebAPI.Data;
using ProsjektOppgaveWebAPI.Models;
using ProsjektOppgaveWebAPI.Models.ViewModel;

namespace ProsjektOppgaveWebAPI.Services;

public class BlogService : IBlogService
{
    private readonly BlogDbContext _db;
    private readonly UserManager<IdentityUser> _manager;
    private BlogViewModel _viewModel;
    private PostViewModel _postViewModel;
    private CommentViewModel _commentViewModel;

    public BlogService(UserManager<IdentityUser> userManager, BlogDbContext db)
    {
        _manager = userManager;
        _db = db;
    }
    
    
    // BLOGS
    public async Task<IEnumerable<Blog>> GetAllBlogs()
    {
        try
        {
            var blogs = _db.Blog
                .Include(b => b.Owner)
                .ToList();

            return blogs;
        }
        catch (NullReferenceException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
            
            return new List<Blog>();
        }
    }



    public Task<IdentityUser> howAreYou(string userName)
    {
        return _manager.FindByNameAsync(userName);
    }

    public Blog? GetBlog(int id)
    {
        var b = (from blog in _db.Blog
            where blog.BlogId == id
            select blog)
            .Include(b => b.BlogTags)
            .FirstOrDefault();
        return b;
    }
 
    public async Task Save(Blog blog)
    {


        var existingBlog = _db.Blog.Find(blog.BlogId);
        if (existingBlog != null)
        {
            _db.Entry(existingBlog).State = EntityState.Detached;
        }

        _db.Blog.Update(blog);
        await _db.SaveChangesAsync();
    }
    
    public async Task Delete(int id, IPrincipal principal)
    {
        var user = await _manager.FindByNameAsync(principal.Identity.Name);
        var blog = _db.Blog.Find(id);

        if (blog.Owner == user)
        {
            _db.Blog.Remove(blog);
            await _db.SaveChangesAsync();
        }
        else
        {
            throw new UnauthorizedAccessException("You are not the owner of this blog.");
        }
    }

    public BlogViewModel GetBlogViewModel()
    {
        _viewModel = new BlogViewModel();
        return _viewModel;
    }

    public BlogViewModel GetBlogViewModel(int id)
    {
        var blog = _db.Blog.Find(id);
        if (blog == null) return null;
        
        _viewModel = new BlogViewModel
        {
            BlogId = blog.BlogId,
            Name = blog.Name,
            Status = blog.Status
        };
        return _viewModel;
    }
    
    
    
    // POSTS
    public Post? GetPost(int id)
    {
        var p = (from post in _db.Post
                where post.PostId == id
                select post)
            .FirstOrDefault();
        return p;
    }
    
    public async Task<IEnumerable<Post>> GetPostsForBlog(int blogId)
    {
        try
        {
            var posts = _db.Post
                .Where(p => p.BlogId == blogId)
                .Include(p => p.Owner)
                .ToList();

            return posts;
        }
        catch (NullReferenceException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
        
            return new List<Post>();
        }
    }
    
    public async Task SavePost(Post post, IPrincipal principal)
    {
        var user = await _manager.FindByNameAsync(principal.Identity.Name);

        var existingPost = _db.Post.Find(post.PostId);
        if (existingPost != null)
        {
            if (existingPost.Owner != user)
            {
                throw new UnauthorizedAccessException("You are not the owner of this post.");
            }
            _db.Entry(existingPost).State = EntityState.Detached;
        }

        post.Owner = user;
        _db.Post.Update(post);
        await _db.SaveChangesAsync();
    }

    public async Task DeletePost(int id, IPrincipal principal)
    {
        var user = await _manager.FindByNameAsync(principal.Identity.Name);
        var post = _db.Post.Find(id);
        
        if (post.Owner == user)
        {
            _db.Post.Remove(post);
            await _db.SaveChangesAsync();
        }
        else
        {
            throw new UnauthorizedAccessException("You are not the owner of this post.");
        }
    }
    
    public PostViewModel GetPostViewModel()
    {
        _postViewModel = new PostViewModel();
        return _postViewModel;
    }

    public PostViewModel GetPostViewModel(int id)
    {
        var post = _db.Post.Find(id);
        if (post == null) return null;
    
        _postViewModel = new PostViewModel
        {
            PostId = post.PostId,
            Title = post.Title,
            Content = post.Content,
            BlogId = post.BlogId
        };
        return _postViewModel;
    }
}