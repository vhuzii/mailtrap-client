using System.Reflection;
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
    Subject = "Mailtrap Attachment Example",
    Text = "This is a test email from Mailtrap with attachment",
    From = new Address 
    { 
        Email = "mailtrap@demomailtrap.com", Name = "Mailtrap" 
    },
    Attachments =
    [
        new()
        {
            Content = Convert.ToBase64String(await File.ReadAllBytesAsync(
                Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/attachment.png")),
            Filename = "attachment.png",
        }
    ]
});
