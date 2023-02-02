using ExpertSender.Application.Persons.ViewModels;
using MediatR;

namespace ExpertSender.Application.Persons.Commands.UpdateExisting;

public class UpdatePersonCommand: IRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Description { get; set; }
    public EmailAddressViewModel[] EmailAddresses { get; set; }
    public AddressViewModel[] Addresses { get; set; }
}
