using AspNetCore.ReCaptcha;

namespace Team121GBCapstoneProject.Services.Concrete;

public class ReCaptchaV3Service : IReCaptchaService
{
    private readonly string _secretKey;
    private readonly IHttpClientFactory _httpClientFactory;

    public Task<ReCaptchaResponse> GetVerifyResponseAsync(string reCaptchaResponse)
    {
        throw new NotImplementedException();
    }

    public Task<bool> VerifyAsync(string reCaptchaResponse, string action = null)
    {
        throw new NotImplementedException();
    }
}
