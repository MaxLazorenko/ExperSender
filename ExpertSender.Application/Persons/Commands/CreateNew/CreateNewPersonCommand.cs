using ExpertSender.Application.Persons.ViewModels;
using ExpertSender.Domain.Entities.PersonsBoundedContext;
using FluentValidation;
using MediatR;

namespace ExpertSender.Application.Persons.Commands.CreateNew;

public class CreateNewPersonCommand: IRequest
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Description { get; set; }
    public EmailAddressViewModel[] EmailAddresses { get; set; }
    public AddressViewModel[] Addresses { get; set; }

    public Person CreateNew()
    {
        var emailAddresses = EmailAddresses.Select(c => new EmailAddress(c.Email));
        var addresses = Addresses.Select(c => new Address(c.Address));
        var person = new Person(Name, Surname, Description);
        foreach (var emailAddress in emailAddresses)
        {
            person.AddEmailAddress(emailAddress);
        }
        foreach (var address in addresses)
        {
            person.AddAddress(address);
        }
        return person;
    }
}

public class CreateNewPersonCommandValidator : AbstractValidator<CreateNewPersonCommand>
{
    public CreateNewPersonCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Surname).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
    }
}
