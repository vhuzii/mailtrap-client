using System.Net;
using Mailtrap;
using Mailtrap.DTOs;
using Moq;
using Moq.Protected;

namespace MailtrapTests;

public class ClientTests
{
    const string Token = "fakeToken";
    private Email TestEmail => new TextEmail
    {
        To =
        [
            new Address
            {
                Email = "test",
            },
        ],
        Subject = "test",
        Text = "test",
        From = new Address
        {
            Email = "test",
            Name = "test",
        },
    }; 

    private Client _client;
    private Mock<HttpMessageHandler> _httpMessageHandlerMock;

    [SetUp]
    public void Setup()
    {
        _httpMessageHandlerMock = new Mock<HttpMessageHandler>();
        _client = new Client(Token, new HttpClient(_httpMessageHandlerMock.Object));
    }

    [Test]
    public void SendEmail_ShoulNotThrow_WhenStatusCodeOk()
    {
        // Arrange
        _httpMessageHandlerMock.Protected().Setup<Task<HttpResponseMessage>>(
            "SendAsync",
            ItExpr.IsAny<HttpRequestMessage>(),
            ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
            });
        
        // Act, Assert
        Assert.DoesNotThrowAsync(async () => await _client.SendEmailAsync(TestEmail));
    }

    [Test]
    [TestCase(HttpStatusCode.BadRequest)]
    [TestCase(HttpStatusCode.InternalServerError)]
    [TestCase(HttpStatusCode.NotFound)]
    [TestCase(HttpStatusCode.Unauthorized)]
    [TestCase(HttpStatusCode.Forbidden)]
    public void SendEmail_ShoulThrowHttpRequestException_WhenStatusCodeNotOk(HttpStatusCode statusCode)
    {
        // Arrange
        _httpMessageHandlerMock.Protected().Setup<Task<HttpResponseMessage>>(
            "SendAsync",
            ItExpr.IsAny<HttpRequestMessage>(),
            ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage()
            {
                StatusCode = statusCode,
            });
        
        // Act, Assert
        var exception = Assert.ThrowsAsync<HttpRequestException>(async () => await _client.SendEmailAsync(TestEmail));
        Assert.That(exception.StatusCode, Is.EqualTo(statusCode));
    }
}