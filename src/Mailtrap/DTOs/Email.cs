using System.Text.Json.Serialization;

namespace Mailtrap.DTOs;

[JsonDerivedType(typeof(TextEmail))]
[JsonDerivedType(typeof(HtmlEmail))]
public abstract class Email
{
    public required Address From { get; set; }
    public required List<Address> To { get; set; }
    public List<Address>? Cc { get; set; }
    public List<Address>? Bcc { get; set; }
    public required string Subject { get; set; }

}