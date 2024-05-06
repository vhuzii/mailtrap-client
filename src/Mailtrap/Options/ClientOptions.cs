using System.Net.Http.Headers;

namespace Mailtrap.Options;

public class ClientOptions
{
    public const string Host = "https://send.api.mailtrap.io";
    public required string Token { get; set; }

}