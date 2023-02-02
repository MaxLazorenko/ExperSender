using ExpertSender.Application.Persons.ViewModels;
using ExpertSender.Domain.Entities.PersonsBoundedContext;

namespace ExpertSender.Application.Persons.Extensions;

public static class PersonExtensions
{
    public static PersonViewModel Map(this Person person)
        => new()
        {
            Name = person.Name,
            Surname = person.Surname,
            EmailAddress = person.EmailAddresses.FirstOrDefault()?.Value,
            Address = person.Addresses.FirstOrDefault()?.Value,
            Description = person.Description,
            EmailAddresses = person.EmailAddresses.Select(c => new EmailAddressViewModel
            {
                Id = c.Id,
                Email = c.Value
            }).ToList(),
            Addresses = person.Addresses.Select(c => new AddressViewModel
            {
                Id = c.Id,
                Address = c.Value
            }).ToList()
        };
}
