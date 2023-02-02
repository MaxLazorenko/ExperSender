using ExpertSender.Domain.Entities.PersonsBoundedContext;
using Microsoft.EntityFrameworkCore;

namespace ExpertSender.Infrastructure.Persistence.PersonsBoundedContext;

internal class PersonsDbContext: DbContext
{
    public DbSet<Person> Persons { get; set; }
    public DbSet<EmailAddress> EmailAddresses { get; set; }
    public DbSet<Address> Addresses { get; set; }

    public PersonsDbContext(DbContextOptions options): base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersonsDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
