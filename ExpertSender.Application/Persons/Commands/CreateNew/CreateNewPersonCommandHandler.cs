using ExpertSender.Infrastructure.Persistence.PersonsBoundedContext.Repositories;
using MediatR;

namespace ExpertSender.Application.Persons.Commands.CreateNew;

public class CreateNewPersonCommandHandler: IRequestHandler<CreateNewPersonCommand>
{
    private readonly IPersonsRepository _personsRepository;

    public CreateNewPersonCommandHandler(IPersonsRepository personsRepository)
    {
        _personsRepository = personsRepository;
    }
    
    public async Task<Unit> Handle(CreateNewPersonCommand request, CancellationToken cancellationToken)
    {
        var person = request.CreateNew();
        await _personsRepository.CreateAsync(person, cancellationToken);
        return Unit.Value;
    }
}
