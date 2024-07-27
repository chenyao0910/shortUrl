using Microsoft.AspNetCore.Mvc;

namespace shortUrl.Controllers;
[ApiController]
[Route("api/[action]")]
public class ShortUrlController
{

    [HttpGet]
    public string Get(string s)
    {
        return "Hello World";
    }
}