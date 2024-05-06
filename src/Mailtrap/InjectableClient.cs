using Mailtrap.Options;
using Microsoft.Extensions.Options;

namespace Mailtrap;

internal class InjectableClient(IOptions<ClientOptions> options, HttpClient httpClient) : Client(options.Value.Token, httpClient)
{
    public InjectableClient(IOptions<ClientOptions> options) 
        : this(options, new HttpClient()) { }
}
