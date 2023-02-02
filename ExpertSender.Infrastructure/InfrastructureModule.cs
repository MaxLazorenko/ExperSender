using ExpertSender.Infrastructure.Persistence.PersonsBoundedContext;
using ExpertSender.Infrastructure.Persistence.PersonsBoundedContext.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExpertSender.Infrastructure;

public static class InfrastructureModule
{
    public static IServiceCollection AddInfrastructureModule(this IServiceCollection services, IConfiguration configuration)
        => services
            .AddScoped<IPersonsRepository, PersonsRepository>()
            .AddDbContext<PersonsDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });
}
