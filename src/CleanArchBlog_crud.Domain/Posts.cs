﻿namespace CleanArchBlog_crud.Domain;

public class Post:BaseDomainEntity
{

    public string Title { get; set; } = "";
    public string Content { get; set; } = "";

    public virtual ICollection<Comment> Comments { get; set; }

    public Post()
    {
        Comments = new HashSet<Comment>();
    }
}
