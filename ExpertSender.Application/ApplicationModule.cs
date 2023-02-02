using ExpertSender.Infrastructure;
using MediatR;
using MediatR.Extensions.FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExpertSender.Application;

public static class ApplicationModule
{
    public static IServiceCollection AddApplicationModule(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddMediatR(typeof(ApplicationModule).Assembly);
        serviceCollection.AddFluentValidation(new []{ typeof(ApplicationModule).Assembly });
        serviceCollection.AddInfrastructureModule(configuration);
        return serviceCollection;
    }
}
