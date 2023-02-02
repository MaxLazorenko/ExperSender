using ExpertSender.Domain.Entities.PersonsBoundedContext;

namespace ExpertSender.Infrastructure.Persistence.PersonsBoundedContext.Repositories;

public interface IPersonsRepository
{
    Task<List<Person>> GetAllAsync(CancellationToken cancellationToken);
    Task<Person> GetOneByIdAsync(int id, CancellationToken cancellationToken);
    Task CommitAsync(CancellationToken cancellationToken);
    Task CreateAsync(Person person, CancellationToken cancellationToken);
    Task DeleteAsync(Person person, CancellationToken cancellationToken);
}
