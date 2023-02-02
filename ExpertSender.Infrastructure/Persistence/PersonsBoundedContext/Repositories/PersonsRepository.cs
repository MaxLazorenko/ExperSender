using ExpertSender.Domain.Entities;
using ExpertSender.Domain.Entities.PersonsBoundedContext;
using Microsoft.EntityFrameworkCore;

namespace ExpertSender.Infrastructure.Persistence.PersonsBoundedContext.Repositories;

internal class PersonsRepository: IPersonsRepository
{
    private readonly PersonsDbContext _personsDbContext;

    public PersonsRepository(PersonsDbContext personsDbContext)
    {
        _personsDbContext = personsDbContext;
    }

    public Task<List<Person>> GetAllAsync(CancellationToken cancellationToken)
    {
        return _personsDbContext.Persons
            .AsNoTracking()
            .Include(c => c.Addresses)
            .Include(c => c.EmailAddresses)
            .ToListAsync(cancellationToken);
    }
    
    public Task<Person> GetOneByIdAsync(int id, CancellationToken cancellationToken)
    {
        return _personsDbContext.Persons
            .Include(c => c.EmailAddresses)
            .Include(c => c.Addresses)
            .FirstAsync(c => c.Id == id, cancellationToken);
    }

    public async Task CommitAsync(CancellationToken cancellationToken)
    {
        var entries = _personsDbContext.ChangeTracker.Entries<BaseEntity>();
        foreach (var entry in entries)
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = DateTimeOffset.Now;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedDate = DateTimeOffset.Now;
                    break;
            }
        }
        await _personsDbContext.SaveChangesAsync(cancellationToken);
    }
    
    public async Task CreateAsync(Person person, CancellationToken cancellationToken)
    {
        await _personsDbContext.Persons.AddAsync(person, cancellationToken);
        await CommitAsync(cancellationToken);
    }
    
    public async Task DeleteAsync(Person person, CancellationToken cancellationToken)
    {
        _personsDbContext.Persons.Remove(person);
        await CommitAsync(cancellationToken);
    }
}
