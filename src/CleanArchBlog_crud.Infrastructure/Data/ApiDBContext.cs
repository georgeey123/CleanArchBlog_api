using System.Reflection;
using Ardalis.SharedKernel;
using CleanArchBlog_crud.Core.ContributorAggregate;
using CleanArchBlog_crud.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchBlog_crud.Infrastructure.Data;
public class BlogDbContext : DbContext
{
    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }

    public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Comment>(entity => {
            entity.HasOne(c => c.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PostId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Comment_Post");
        });
    }
}