using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Mailtrap.DTOs;
using Mailtrap.Options;
using Microsoft.Extensions.Options;

namespace Mailtrap;

public class Client(IOptions<ClientOptons> options)
{
    private readonly HttpClient _httpClient = new HttpClient();
    private readonly ClientOptons _options = options.Value;

    public async Task SendEmailAsync(Email message)
    {
        var url = ClientOptons.Host + $"/api/send";

        var request = new HttpRequestMessage(HttpMethod.Post, url) 
        {
            Content = new StringContent(JsonSerializer.Serialize(message), Encoding.UTF8, "application/json")
        };
        
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _options.Token);

        var response = await _httpClient.SendAsync(request);

        if (!response.IsSuccessStatusCode)
        {   
            Console.WriteLine(response);
            throw new Exception("Failed to send email");
        }
    }
}
