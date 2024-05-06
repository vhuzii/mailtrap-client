using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Mailtrap.DTOs;
using Mailtrap.Options;

namespace Mailtrap;

public class Client(string token, HttpClient httpClient)
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly AuthenticationHeaderValue _authorization = new("Bearer", token);
    public Client(string token) : this(token, new HttpClient()) { }
    

    public async Task SendEmailAsync(Email message)
    {
        var url = ClientOptions.Host + $"/api/send";

        var request = new HttpRequestMessage(HttpMethod.Post, url) 
        {
            Content = new StringContent(JsonSerializer.Serialize(message), Encoding.UTF8, "application/json")
        };
        
        request.Headers.Authorization = _authorization;

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
    }
}
