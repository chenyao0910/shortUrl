using shortUrl.Controllers;
using shortUrl.Models;
using shortUrl.Repositories;
using shortUrl.Services;

namespace shortUrl.Interfaces;

public interface IShortUrlService
{
    public ShortUrlDto Redirect(string s);
    public ShorUrlModel Create(CreateShortUrlRequest createShortUrlRequest);
}