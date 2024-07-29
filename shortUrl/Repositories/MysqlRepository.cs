using System.Data.SqlClient;
using shortUrl.Interfaces;
using shortUrl.Models;
using Dapper;
using MySqlConnector;

namespace shortUrl.Repositories;

public class MysqlRepository : IRepository
{
    private IConfiguration _configuration;

    public MysqlRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public IEnumerable<ShortUrlDto> GetUrl(string key)
    {
        using var conn = new MySqlConnection("Server=localhost;User ID=root;Password=1234@qwer;Database=mysql");
        var shortUrlDto = conn.Query<ShortUrlDto>("SELECT * FROM shortUrl");
        return shortUrlDto;
    }

    public void InsertUrl(string url)
    {
        var sql = "INSERT INTO shortUrl (UrlKey, Url) VALUES ('chenyao091', 'chwjewq1231')";
        using var conn = new MySqlConnection("Server=localhost;User ID=root;Password=1234@qwer;Database=mysql");
        var row = conn.Execute(sql);
        Console.WriteLine(row);
    }
}

public class ShortUrlDto
{
    public string UrlKey { get; set; }
    public string Url { get; set; }

    public override string ToString()
    {
        return $"{nameof(UrlKey)}: {UrlKey}, {nameof(Url)}: {Url}";
    }
}