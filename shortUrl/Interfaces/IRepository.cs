using shortUrl.Repositories;

namespace shortUrl.Interfaces;

public interface IRepository
{
    public ShortUrlDto GetUrl(string key);
    public void InsertUrl(ShortUrlDto shortUrlDto);
}