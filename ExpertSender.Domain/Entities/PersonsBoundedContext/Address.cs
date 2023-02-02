namespace ExpertSender.Domain.Entities.PersonsBoundedContext;

public class Address: BaseEntity<int>
{
    public string Value { get; private set; }
    public int PersonId { get; }
    public Person Person { get; }

    /// <summary>
    /// Ef required
    /// </summary>
    private Address()
    {
    }
    
    public Address(string value)
    {
        Value = value;
    }

    public void Update(string value)
        => Value = value;
}
