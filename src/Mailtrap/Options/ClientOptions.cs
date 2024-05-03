namespace Mailtrap.Options;

public class ClientOptons
{
    public const string Host = "https://send.api.mailtrap.io";
    public required string Token { get; set; }
    public int InboxId { get; set; }
    public int AccountId { get; set; }
}