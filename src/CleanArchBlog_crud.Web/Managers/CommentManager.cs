using CleanArchBlog_crud.Core.Entities;
using CleanArchBlog_crud.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanArchBlog_crud.Web.Managers;

public class CommentManager
{
    private readonly BlogDbContext _context;

    public CommentManager(BlogDbContext context)
    {
        _context = context;
    }

    public async Task<int> CreateComment(Comment comment)
    {
        var post = await _context.Posts.FirstOrDefaultAsync(x => x.PostId == comment.PostId);

        if (post == null)
            throw new Exception("Invalid Post Id");
        
        post.Comments.Add(comment);
        
        await _context.Comments.AddAsync(comment);
        await _context.SaveChangesAsync();

        return comment.CommentId;
    }

    public async Task DeleteComment(int id)
    {
        var comment = await _context.Comments.FirstOrDefaultAsync(x => x.CommentId == id);

        if (comment == null)
            throw new Exception("Invalid Id");
        
        _context.Comments.Remove(comment);
        await _context.SaveChangesAsync();
    }

    public async Task<Comment?> GetCommentById(int id)
    {
        var comment = await _context.Comments.FirstOrDefaultAsync(x => x.CommentId == id);

        if (comment == null)
            throw new Exception("Invalid Id");

        return comment;
    }

    public async Task<List<Comment>> GetAllComments()
    {
        var comments = await _context.Comments.ToListAsync();
        return comments;
    }

    public async Task UpdateComment(int id, Comment updatedComment)
    {
        var comment = await _context.Comments.FirstOrDefaultAsync(x => x.CommentId == id);

        if (comment == null)
            throw new Exception("Invalid Id");

        comment.Text = updatedComment.Text;
        await _context.SaveChangesAsync();
    }

}