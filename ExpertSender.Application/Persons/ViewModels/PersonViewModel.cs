namespace ExpertSender.Application.Persons.ViewModels;

public class PersonViewModel
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Description { get; set; }
    public string? EmailAddress { get; set; }
    public string? Address { get; set; }
    public List<AddressViewModel> Addresses { get; set; }
    public List<EmailAddressViewModel> EmailAddresses { get; set; }
}

public class EmailAddressViewModel
{
    public int? Id { get; set; }
    public string Email { get; set; }
}

public class AddressViewModel
{
    public int? Id { get; set; }
    public string Address { get; set; }
}
