using FluentAssertions;
using NSubstitute;
using shortUrl.Interfaces;
using shortUrl.Repositories;
using shortUrl.Services;
using Sqids;

namespace shortUrl.Tests;

[TestFixture]
public class ShortUrlServiceTests
{
    [SetUp]
    public void Setup()
    {
        _repository = Substitute.For<IRepository>();
        _sqidsEncoder = Substitute.For<SqidsEncoder<int>>();
        _shortUrlService = new ShortUrlService(_repository, _sqidsEncoder);
    }

    private IShortUrlService _shortUrlService;
    private IRepository _repository;
    private SqidsEncoder<int> _sqidsEncoder;
}