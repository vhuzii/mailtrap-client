using Mailtrap;
using Mailtrap.DTOs;

const string token = "<TOKEN>";

Client client = new(token);

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
