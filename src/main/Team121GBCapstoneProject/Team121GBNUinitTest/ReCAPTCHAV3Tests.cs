using Moq;
using Moq.Contrib.HttpClient;
using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team121GBCapstoneProject.Services.Concrete;

namespace Team121GBNUnitTest;

public class ReCAPTCHAV3Tests
{
    [SetUp]
    public void SetUp()
    {

    }

    [Test]
    public void ReCaptchaV3_Success_ShouldReturnTrue()
    {
        // * Arrange
        var handler = new Mock<HttpMessageHandler>();
        handler.SetupAnyRequest()
               .ReturnsResponse(System.Net.HttpStatusCode.OK);
        var reCaptchaV3 = new ReCaptchaV3Service(handler.CreateClientFactory());
        var reCaptchaResponse = "{\"success\": true}";
        var secretKey = "SecretKey";
        // ! Act
        bool result = reCaptchaV3.VerifyAsync(reCaptchaResponse).Result;

        // ? Assert
        Assert.That(result, Is.EqualTo(true));
    }
    [Test]
    public void ReCaptchaV3_Failure_ShouldReturnFalse()
    {
        // * Arrange
        var handler = new Mock<HttpMessageHandler>();
        handler.SetupAnyRequest()
               .ReturnsResponse(System.Net.HttpStatusCode.OK);
        var reCaptchaV3 = new ReCaptchaV3Service(handler.CreateClientFactory());
        var reCaptchaResponse = "{\"success\": false}";
        var secretKey = "SecretKey";
        // ! Act
        bool result = reCaptchaV3.VerifyAsync(reCaptchaResponse).Result;

        // ? Assert
        Assert.That(result, Is.EqualTo(false));
    }
    [Test]
    public void ReCaptchaV3_Invalid_ShouldReturnFalse()
    {
        // * Arrange
        var handler = new Mock<HttpMessageHandler>();
        handler.SetupAnyRequest()
               .ReturnsResponse(System.Net.HttpStatusCode.OK);
        var reCaptchaV3 = new ReCaptchaV3Service(handler.CreateClientFactory());
        var reCaptchaResponse = "{}";
        var secretKey = "SecretKey";
        // ! Act
        bool result = reCaptchaV3.VerifyAsync(reCaptchaResponse).Result;

        // ? Assert
        Assert.That(result, Is.EqualTo(false));
    }
}
