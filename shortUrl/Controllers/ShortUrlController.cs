using Microsoft.AspNetCore.Mvc;
using shortUrl.Interfaces;

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
        return redirect;
    }
}