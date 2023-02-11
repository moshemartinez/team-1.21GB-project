using Team121GBCapstoneProject.Services;
using Moq;
using Moq.Protected;
using System.Net;
namespace Team121GBNUinitTests;


public class AccountRegistrationCAPTCHATests
{
    [SetUp]
    public void SetUp()
    {
    }

    [Test]
    public void reCAPTCHAisPassed()
    {
        // Arrange
        var secretKey = "secret_key";
        var captcha = "captcha_response";
        var responseJson = "{\"success\": true}";
        var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
        mockHttpMessageHandler.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(responseJson),
            });
        var httpClient = new HttpClient(mockHttpMessageHandler.Object)
        {
            BaseAddress = new Uri("http://test.com")
        };
        var reCaptchaService = new ReCaptchaService(secretKey, httpClient);

        // Act
        var result = reCaptchaService.IsValid(captcha).Result;

        // Assert
        Assert.AreEqual(true, result);
    }

    [Test]
    public void reCAPTCHAisNOTPassed()
    {
        //setup
         // Arrange
        var secretKey = "secret_key";
        var captcha = "captcha_response";
        var responseJson = "{\"success\": false}";
        var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
        mockHttpMessageHandler.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(responseJson),
            });
        var httpClient = new HttpClient(mockHttpMessageHandler.Object)
        {
            BaseAddress = new Uri("http://test.com")
        };
        var reCaptchaService = new ReCaptchaService(secretKey, httpClient);

        // Act
        var result = reCaptchaService.IsValid(captcha).Result;

        // Assert
        Assert.AreEqual(false, result);
    }
}
