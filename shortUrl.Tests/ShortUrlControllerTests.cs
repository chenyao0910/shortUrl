using FluentAssertions;
using NSubstitute;
using shortUrl.Controllers;
using shortUrl.Interfaces;

namespace shortUrl.Tests;

[TestFixture]
public class ShortUrlControllerTests
{
    [SetUp]
    public void Setup()
    {
        _shortUrlService = Substitute.For<IShortUrlService>();
        _shortUrlController = new ShortUrlController(_shortUrlService);
    }

    private ShortUrlController _shortUrlController = null!;
    private IShortUrlService _shortUrlService = null!;

    [TestCase("helloWorld")]
    [TestCase("Hello")]
    [TestCase("test")]
    public void When_Call_Get_ShortUrl_Should_Return_GivenString(string queryString)
    {
        _shortUrlService.Redirect(queryString).Returns(queryString);

        var result = _shortUrlController.Get(queryString);

        result.Should().BeEquivalentTo(queryString);
    }

    [TestCase("helloWorld")]
    [TestCase("Hello")]
    [TestCase("test")]
    public void When_Call_Get_ShortUrlService_Should_Be_Called(string queryStr)
    {
        _shortUrlController.Get(queryStr);

        _shortUrlService.Received(1).Redirect(Arg.Is<string>(s => s == queryStr));
    }
}