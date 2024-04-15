using CleanArchBlog_crud.Core.Entities;
using CleanArchBlog_crud.Infrastructure.Data;
using CleanArchBlog_crud.Web.Managers;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchBlog_crud.Web;

[Route("api/[controller]")]
[ApiController]
public class PostsController : ControllerBase
{
    private readonly BlogDbContext _context;
    PostManager postsManager;

    public PostsController(BlogDbContext context)
    {
        _context = context;
        postsManager = new PostManager(_context);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var posts = await postsManager.GetAllPosts();
        return Ok(posts);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var post = await postsManager.GetPostById(id);
            return Ok(post);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post(Post post)
    {
        var postId = await postsManager.CreatePost(post);
        return CreatedAtAction(nameof(Get), new { id = postId }, post);
    }

    [HttpPatch]
    public async Task<IActionResult> Patch(int id, Post updatedPost)
    {
        try
        {
            await postsManager.UpdatePost(id, updatedPost);
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await postsManager.DeletePost(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
