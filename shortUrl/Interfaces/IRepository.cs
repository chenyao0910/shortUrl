using shortUrl.Repositories;

namespace shortUrl.Interfaces;

public interface IRepository
{
    public IEnumerable<ShortUrlDto> GetUrl(string key);
    public void InsertUrl(string url);
}