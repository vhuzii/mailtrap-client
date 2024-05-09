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
    private const string Host = "https://send.api.mailtrap.io";
    private const string SendEndpoint = "/api/send";

    private readonly HttpClient _httpClient = httpClient;
    private readonly AuthenticationHeaderValue _authorization = new(AuthorizationScheme, token);
    public Client(string token) : this(token, new HttpClient()) { }
    

    public async Task SendEmailAsync(Email email)
    {
        var request = CreateRequest(email);
        var response = await _httpClient.SendAsync(request).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();
    }

    private HttpRequestMessage CreateRequest(Email email)
    {
        var url = Host + SendEndpoint;
        var request = new HttpRequestMessage(HttpMethod.Post, url)
        {
            Content = new StringContent(JsonSerializer.Serialize(email), Encoding.UTF8, ContentType)
        };

        request.Headers.Authorization = _authorization;
        return request;
    }
}
