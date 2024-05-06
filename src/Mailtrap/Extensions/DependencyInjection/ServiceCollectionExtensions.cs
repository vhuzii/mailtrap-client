
using Mailtrap.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;


namespace Mailtrap.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMailtrap(this IServiceCollection services, Action<ClientOptions> configureOptions)
    {
        services.AddOptions<ClientOptions>()
            .Configure((options) => configureOptions(options));

        services.AddHttpClient<Client, InjectableClient>();
        return services;
    }
}
