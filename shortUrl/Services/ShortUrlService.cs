using Microsoft.AspNetCore.DataProtection.Repositories;
using shortUrl.Interfaces;
using shortUrl.Repositories;

namespace shortUrl.Services;

public class ShortUrlService : IShortUrlService
{
    private MysqlRepository _repo;

    public ShortUrlService(MysqlRepository repo)
    {
        _repo = repo;
    }

    public string Redirect(string s)
    {
        _repo.GetUrl(s);
        return s;
    }
}