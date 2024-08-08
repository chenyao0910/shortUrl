using FluentAssertions;
using NSubstitute;
using shortUrl.Interfaces;
using shortUrl.Models;
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
        _shortUrlService = new ShortUrlService(_repository, _sqidsEncoder);
    }

    private IShortUrlService _shortUrlService;
    private IRepository _repository;
    private SqidsEncoder<int> _sqidsEncoder;


    [Test]
    public void When_Get_Url_Has_Data_Should_Return_Success()
    {
        var givenUrlKey = "abcdef";
        _sqidsEncoder.Encode(1).Returns(givenUrlKey);
        _repository.InsertUrl(new ShortUrlDto
        {
            UrlKey = givenUrlKey,
            Url = "www.google.com"
        }).Returns(1);

        var shorUrlModel = _shortUrlService.Create(new CreateShortUrlRequest
        {
            Url = "www.google.com"
        });

        shorUrlModel.Should().BeEquivalentTo(new ShorUrlModel
        {
            IsSuccess = 1,
            UrlKey = givenUrlKey
        });
    }
}
