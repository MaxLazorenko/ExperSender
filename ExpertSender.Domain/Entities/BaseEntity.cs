namespace ExpertSender.Domain.Entities;

public class BaseEntity
{
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset LastModifiedDate { get; set; }
}

public class BaseEntity<T> : BaseEntity
{
    public T Id { get; set; }
}
