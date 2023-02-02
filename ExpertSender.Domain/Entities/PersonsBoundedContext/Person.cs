namespace ExpertSender.Domain.Entities.PersonsBoundedContext;

public class Person: BaseEntity<int>
{
    public string Name { get; private set; }
    public string Surname { get; private set; }
    public string Description { get; private set; }
    public List<Address> Addresses { get; private set; }
    public List<EmailAddress> EmailAddresses { get; private set; }

    /// <summary>
    /// Ef required
    /// </summary>
    public Person()
    {
    }
    
    public Person(string name, string surname, string description)
    {
        Name = name;
        Surname = surname;
        Description = description;
    }

    public void Update(string name, string surname, string description)
    {
        Name = name;
        Surname = surname;
        Description = description;
    }
    
    public void AddAddress(Address address)
    {
        Addresses ??= new List<Address>();
        Addresses.Add(address);
    }

    public void AddEmailAddress(EmailAddress emailAddress)
    {
        EmailAddresses ??= new List<EmailAddress>();
        EmailAddresses.Add(emailAddress);
    }
}
