using shortUrl.Interfaces;

namespace shortUrl.Services;

public class ShortUrlService : IShortUrlService
{
    public string Redirect(string s)
    {
        return s;
    }
}