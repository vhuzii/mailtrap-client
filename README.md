# Installation

```
dotnet add package MailtrapTestTask --version 1.0.1
```

## Set up when using DI

```
services.AddMailtrap(options => options.Token = "<TOKEN>");
```

## Set up with a constructor

```
Client client = new(token: "<TOKEN>");
```

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

### Run preinstalled examples (replace `"<TOKEN>"` const with a real token in Program.cs files)

- Email with text - `dotnet run --project examples/MailtrapClientTextExample` 
- Email with html - `dotnet run --project examples/MailtrapClientHtmlExample`
- Email with attachment - `dotnet run --project examples/MailtrapClientAttachmentExample`
- Email with text when using DI - `dotnet run --project examples/MailtrapClientTextExampleWithDI`

