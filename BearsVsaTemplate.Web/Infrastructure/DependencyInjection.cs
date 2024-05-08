using BearsVsaTemplate.Web.Common.Interfaces;
using BearsVsaTemplate.Web.Infrastructure.Persistence;
using FluentValidation;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace BearsVsaTemplate.Web.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHandlers();
        services.AddBehaviors();
        
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("DbConnection");
            options.UseNpgsql(connectionString);
        });
        
        services.AddMassTransit(busConfigurator =>
        {
            busConfigurator.SetKebabCaseEndpointNameFormatter();
            busConfigurator.AddConsumers(typeof(IAssemblyMarker).Assembly);
            
            busConfigurator.UsingRabbitMq((context, configurator) =>
            {

                configurator.Host(configuration.GetConnectionString("MessageBroker"));
                
                configurator.ConfigureEndpoints(context);
            });
        });
        
        services.AddValidatorsFromAssemblyContaining<IAssemblyMarker>();
    }
}