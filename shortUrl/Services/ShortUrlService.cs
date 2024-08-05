using System.Security.Cryptography;
using Microsoft.AspNetCore.DataProtection.Repositories;
using shortUrl.Interfaces;
using shortUrl.Models;
using shortUrl.Repositories;
using Sqids;

namespace shortUrl.Services;

public class ShortUrlService : IShortUrlService
{
    private readonly IRepository _repo;
    private readonly SqidsEncoder<int> _sqids;
    private int _counter = 0;

    public ShortUrlService(IRepository repo, SqidsEncoder<int> sqids)
    {
        _repo = repo;
        _sqids = sqids;
    }

    public ShortUrlDto Redirect(string s)
    {
        var shortUrlDto = _repo.GetUrl(s);

        return shortUrlDto;
    }

    public ShortUrlDto Create(CreateShortUrlRequest createShortUrlRequest)
    {
        var urlKey = _sqids.Encode(_counter++);

        _repo.InsertUrl(new ShortUrlDto
        {
            UrlKey = urlKey,
            Url = createShortUrlRequest.Url
        });


        return new ShortUrlDto();
    }
}