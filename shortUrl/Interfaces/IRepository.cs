using shortUrl.Repositories;

namespace shortUrl.Interfaces;

public interface IRepository
{
    public ShortUrlDto GetUrl(string key);
    public int InsertUrl(ShortUrlDto shortUrlDto);
}