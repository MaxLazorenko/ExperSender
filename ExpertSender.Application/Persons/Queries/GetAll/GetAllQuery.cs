using ExpertSender.Application.Persons.Extensions;
using ExpertSender.Infrastructure.Persistence.PersonsBoundedContext.Repositories;
using MediatR;

namespace ExpertSender.Application.Persons.Queries.GetAll;

public record GetAllQuery() : IRequest<GetAllResponse>;

public class GetAllQueryHandler : IRequestHandler<GetAllQuery, GetAllResponse>
{
    private readonly IPersonsRepository _personsRepository;

    public GetAllQueryHandler(IPersonsRepository personsRepository)
    {
        _personsRepository = personsRepository;
    }

    public async Task<GetAllResponse> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _personsRepository.GetAllAsync(cancellationToken);
        var viewModels = result.Select(c => c.Map()).ToList();
        return new GetAllResponse
        {
            Persons = viewModels
        };
    }
}
