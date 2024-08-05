using Microsoft.AspNetCore.Mvc;
using shortUrl.Interfaces;
using shortUrl.Models;

namespace shortUrl.Controllers;

[ApiController]
[Route("api/[action]")]
public class ShortUrlController
{
    private readonly IShortUrlService _shortUrlService;

    public ShortUrlController(IShortUrlService shortUrlService)
    {
        _shortUrlService = shortUrlService;
    }

    [HttpGet]
    public string Get(string s)
    {
        var redirect = _shortUrlService.Redirect(s);
        return redirect.Url;
    }

    [HttpPost]
    public string Post(CreateShortUrlRequest createShortUrlRequest)
    {
        var redirect = _shortUrlService.Create(createShortUrlRequest);
        return redirect.Url;
    }
}