
using Mailtrap.Options;
using Microsoft.Extensions.DependencyInjection;


namespace Mailtrap.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMailtrap(this IServiceCollection services, Action<ClientOptions> configureOptions)
    {
        services.AddOptions<ClientOptions>()
            .Configure((options) => configureOptions(options));
        services.AddHttpClient<Client>();
        return services;
    }
}
