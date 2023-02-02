using ExpertSender.Domain.Entities.PersonsBoundedContext;
using ExpertSender.Infrastructure.Persistence.PersonsBoundedContext.Repositories;
using MediatR;

namespace ExpertSender.Application.Persons.Commands.UpdateExisting;

public class UpdatePersonCommandHandler: IRequestHandler<UpdatePersonCommand>
{
    private readonly IPersonsRepository _personsRepository;

    public UpdatePersonCommandHandler(IPersonsRepository personsRepository)
    {
        _personsRepository = personsRepository;
    }

    public async Task<Unit> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
    {
        var person = await _personsRepository.GetOneByIdAsync(request.Id, cancellationToken);
        person.Update(request.Name, request.Surname, request.Description);
        CreateOrUpdateAddresses(request, person);
        CreateOrUpdateEmailAddresses(request, person);
        await _personsRepository.CommitAsync(cancellationToken);
        
        return Unit.Value;
    }
    
    private static void CreateOrUpdateEmailAddresses(UpdatePersonCommand request, Person person)
    {

        foreach (var emailAddress in request.EmailAddresses)
        {
            if (emailAddress.Id.HasValue)
            {
                var existingAddress = person.EmailAddresses.FirstOrDefault(c => c.Id == emailAddress.Id.Value);
                if (existingAddress is null)
                    throw new Exception($"Can't found an Address with id: {emailAddress.Id.Value}");

                existingAddress.Update(emailAddress.Email);
            }
            else
            {
                person.AddEmailAddress(new EmailAddress(emailAddress.Email));
            }
        }
    }
    
    private static void CreateOrUpdateAddresses(UpdatePersonCommand request, Person person)
    {

        foreach (var address in request.Addresses)
        {
            if (address.Id.HasValue)
            {
                var existingAddress = person.Addresses.FirstOrDefault(c => c.Id == address.Id.Value);
                if (existingAddress is null)
                    throw new Exception($"Can't found an Address with id: {address.Id.Value}");

                existingAddress.Update(address.Address);
            }
            else
            {
                person.AddAddress(new Address(address.Address));
            }
        }
    }
}
