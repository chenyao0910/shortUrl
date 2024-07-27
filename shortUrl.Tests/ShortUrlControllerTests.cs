using FluentAssertions;
using shortUrl.Controllers;

namespace shortUrl.Tests;

[TestFixture]
public class ShortUrlControllerTests
{
    private ShortUrlController _shortUrlController = null!;

    [SetUp]
    public void Setup()
    {
        _shortUrlController = new ShortUrlController();
    }

    [Test]
    public void When_Call_Get_ShortUrl_Should_Return_HelloWorld()
    {
        var result = _shortUrlController.Get("String");
        result.Should().BeEquivalentTo("Hello World");
    }
}