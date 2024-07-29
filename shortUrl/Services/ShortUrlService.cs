using Microsoft.AspNetCore.DataProtection.Repositories;
using shortUrl.Interfaces;
using shortUrl.Repositories;

namespace shortUrl.Services;

public class ShortUrlService : IShortUrlService
{
    private readonly IRepository _repo;

    public ShortUrlService(IRepository repo)
    {
        _repo = repo;
    }

    public string Redirect(string s)
    {
        _repo.InsertUrl(s);
        return s;
    }
}