using ExpertSender.Infrastructure.Persistence.PersonsBoundedContext.Repositories;
using MediatR;

namespace ExpertSender.Application.Persons.Commands.DeleteExisting;

public record DeletePersonCommand(int Id) : IRequest;

public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand>
{
    private readonly IPersonsRepository _personsRepository;

    public DeletePersonCommandHandler(IPersonsRepository personsRepository)
    {
        _personsRepository = personsRepository;
    }

    public async Task<Unit> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
    {
        var person = await _personsRepository.GetOneByIdAsync(request.Id, cancellationToken);
        await _personsRepository.DeleteAsync(person, cancellationToken);
        
        return Unit.Value;
    }
}
