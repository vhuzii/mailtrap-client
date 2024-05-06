using Mailtrap;
using Mailtrap.DTOs;
using Mailtrap.Options;
using Microsoft.Extensions.Options;
const string token = "<TOKEN>";

Client client = new(token);

await client.SendEmailAsync(new HtmlEmail
{
    To =
    [
        new() 
        { 
            Email = @"huziivolodymyr@gmail.com" 
        },
    ],
    Subject = "Mailtrap Html Example",
    Html = @"
 <!doctype html>
<html>
  <body style=3D""font-family: sans-serif;"">
    <h1>Test Html Email</h1>
  </body>
</html>   
    ",
    From = new Address 
    { 
        Email = "mailtrap@demomailtrap.com", Name = "Mailtrap" 
    },
});
