using shortUrl.Controllers;
using shortUrl.Models;
using shortUrl.Repositories;

namespace shortUrl.Interfaces;

public interface IShortUrlService
{
    public ShortUrlDto Redirect(string s);
    public ShortUrlDto Create(CreateShortUrlRequest createShortUrlRequest);
}