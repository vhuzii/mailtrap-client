## Set up when using DI

```
services.AddMailtrap(options => options.Token = "<TOKEN>");
```

## Set up with a constructor

```
Client client = new(Options.Create(new ClientOptions { Token = "<TOKEN>" }));
```

### Run preinstalled examples (replace `"<TOKEN>"` const with a real token in Program.cs files)

- Email with text - `dotnet run --project examples/MailtrapClientTextExample` 
- Email with html - `dotnet run --project examples/MailtrapClientHtmlExample`
- Email with attachment - `dotnet run --project examples/MailtrapClientAttachmentExample`

### Usage example

```

await client.SendEmailAsync(new TextEmail
{
    To =
    [
        new() 
        { 
            Email = @"testmail@gmail.com" 
        },
    ],
    Subject = "Mailtrap Text Example",
    Text = "This is a test email from Mailtrap",
    From = new Address 
    { 
        Email = "mailtrap@demomailtrap.com", Name = "Mailtrap" 
    },
});

```
