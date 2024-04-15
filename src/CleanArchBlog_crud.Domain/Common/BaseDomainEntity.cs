namespace CleanArchBlog_crud.Domain;

public abstract class BaseDomainEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
}
