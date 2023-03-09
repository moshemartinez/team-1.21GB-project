using System.Diagnostics;
using Newtonsoft.Json.Linq;
using static System.Net.WebRequestMethods;
using Team121GBCapstoneProject.Services.Abstract;

namespace Team121GBCapstoneProject.Services.Concrete;

public class ReCaptchaV3Service : IReCaptchaV3Service
{
    private readonly string _secretKey;
    private readonly IHttpClientFactory _httpClientFactory;
    public ReCaptchaV3Service(string secretKey, IHttpClientFactory httpClientFactory)
    {
        _secretKey = secretKey;
        _httpClientFactory = httpClientFactory;
    }

    //public Task<ReCaptchaResponse> GetVerifyResponseAsync(string reCaptchaResponse)
    //{
    //    throw new NotImplementedException();
    //}

    //public Task<bool> VerifyAsync(string reCaptchaResponse, string action = null)
    //{
    //    throw new NotImplementedException();
    //}

    public Task<bool> IsValid(string captcha)
    {

        throw new NotImplementedException();
    }
}
