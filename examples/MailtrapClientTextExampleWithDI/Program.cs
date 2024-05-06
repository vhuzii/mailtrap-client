using Mailtrap;
using Mailtrap.DTOs;
using Mailtrap.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

const string token = "<TOKEN>";

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddMailtrap(options => options.Token = token);        
    })
    .Build();


var client = host.Services.GetRequiredService<Client>();

await client.SendEmailAsync(new TextEmail
{
    To =
    [
        new() 
        { 
            Email = @"huziivolodymyr@gmail.com" 
        },
    ],
    Subject = "Mailtrap Text Example",
    Text = "This is a test email from Mailtrap",
    From = new Address 
    { 
        Email = "mailtrap@demomailtrap.com", Name = "Mailtrap" 
    },
});

await host.RunAsync();