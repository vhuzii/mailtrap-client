using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Mailtrap.DTOs;
using Mailtrap.Options;
using Microsoft.Extensions.Options;

namespace Mailtrap;

public class Client(string token, HttpClient httpClient)
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly AuthenticationHeaderValue authorization = new("Bearer", token);
    public Client(string token) : this(token, new HttpClient()) { }
    

    public async Task SendEmailAsync(Email message)
    {
        var url = ClientOptions.Host + $"/api/send";

        var request = new HttpRequestMessage(HttpMethod.Post, url) 
        {
            Content = new StringContent(JsonSerializer.Serialize(message), Encoding.UTF8, "application/json")
        };
        
        request.Headers.Authorization = authorization;

        var response = await _httpClient.SendAsync(request);

        if (!response.IsSuccessStatusCode)
        {   
            Console.WriteLine(response);
            throw new Exception("Failed to send email");
        }
    }
}
