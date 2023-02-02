namespace ExpertSender.Domain.Entities.PersonsBoundedContext;

public class EmailAddress: BaseEntity<int>
{
    public string Value { get; private set; }
    public int PersonId { get; }
    public Person Person { get; }

    /// <summary>
    /// Ef required
    /// </summary>
    private EmailAddress()
    {
    }
    
    public EmailAddress(string value)
    {
        Value = value;
    }

    public void Update(string value)
        => Value = value;
}
