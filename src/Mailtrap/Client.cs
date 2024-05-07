using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Mailtrap.DTOs;
using Mailtrap.Options;

namespace Mailtrap;

public class Client(string token, HttpClient httpClient)
{
    private const string ContentType = "application/json";
    private const string AuthorizationScheme = "Bearer";
    private const string SendEndpoint = "/api/send";

    private readonly HttpClient _httpClient = httpClient;
    private readonly AuthenticationHeaderValue _authorization = new(AuthorizationScheme, token);
    public Client(string token) : this(token, new HttpClient()) { }
    

    public async Task SendEmailAsync(Email message)
    {
        var request = CreateRequest(message);
        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
    }

    private HttpRequestMessage CreateRequest(Email message)
    {
        var url = ClientOptions.Host + SendEndpoint;
        var request = new HttpRequestMessage(HttpMethod.Post, url)
        {
            Content = new StringContent(JsonSerializer.Serialize(message), Encoding.UTF8, ContentType)
        };

        request.Headers.Authorization = _authorization;
        return request;
    }
}
