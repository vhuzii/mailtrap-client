// See https://aka.ms/new-console-template for more information
using Mailtrap;
using Mailtrap.DTOs;
using Mailtrap.Options;
using Microsoft.Extensions.Options;

Client client = new Client(Options.Create(new ClientOptons
{
    Token = "0eaa24727b41a132faf5eef8db67aeba"
})
);

client.SendEmailAsync(new TextEmail
{
    To = new List<Address>() {
        new Address { Email = @"huziivolodymyr@gmail.com" },
    },
    Subject = "Hello from Mailtrap",
    Text = "This is a test email from Mailtrap",
    From = new Address { Email = "mailtrap@demomailtrap.com", Name = "Mailtrap" },
}).Wait();
