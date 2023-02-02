using Bogus;
using ExpertSender.Domain.Entities.PersonsBoundedContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Person = ExpertSender.Domain.Entities.PersonsBoundedContext.Person;

namespace ExpertSender.Infrastructure.Persistence.PersonsBoundedContext.EntityConfiguration;

public class PersonEntityTypeConfiguration: IEntityTypeConfiguration<Person>
{

    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("Persons");
        builder.HasKey(c => c.Id);
        builder.HasIndex(c => c.Id).IsUnique();
        builder.Property(c => c.Name).HasMaxLength(255);
        builder.Property(c => c.Surname).HasMaxLength(255);
        builder.Property(c => c.Description).HasMaxLength(255);

        builder.HasMany(c => c.Addresses)
            .WithOne(c => c.Person)
            .HasForeignKey(c => c.PersonId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(c => c.EmailAddresses)
            .WithOne(c => c.Person)
            .HasForeignKey(c => c.PersonId)
            .OnDelete(DeleteBehavior.Cascade);
        HasDefaultData(builder);
    }

    private static void HasDefaultData(EntityTypeBuilder<Person> builder)
    {
        var ids = 1;
        var persons = new Faker<Person>()
            .UseSeed(1122)
            .StrictMode(false)
            .RuleFor(c => c.Id, f => ids++)
            .RuleFor(c => c.Name, f => f.Person.FirstName)
            .RuleFor(c => c.Surname, f => f.Person.LastName)
            .RuleFor(c => c.Description, f => $"Awesome description for id: {ids++}")
            .Generate(100);

        builder.HasData(persons);
    }
}
