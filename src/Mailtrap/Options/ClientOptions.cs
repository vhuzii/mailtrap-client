using System.Net.Http.Headers;

namespace Mailtrap.Options;

public class ClientOptions
{
    public const string Host = "https://send.api.mailtrap.io";

    private string _token = string.Empty;
    public required string Token 
    { 
        get => _token; 
        set 
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(nameof(Token));
            }
            _token = value;
            Authentication = new AuthenticationHeaderValue("Bearer", _token);
        }
    }

    public AuthenticationHeaderValue? Authentication { get; set; }
}