using shortUrl.Interfaces;
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
    public ShortUrlDto GetUrl(string key)
    {
        using var conn = new MySqlConnection("Server=localhost;User ID=root;Password=1234@qwer;Database=mysql;Allow User Variables=true");
        var dynamicParameters = new DynamicParameters();
        dynamicParameters.Add("UrlKey", key);
        var shortUrlDto = conn.Query<ShortUrlDto>("SELECT UrlKey, Url FROM shortUrl WHERE UrlKey = @UrlKey", dynamicParameters);
        return shortUrlDto.First();
    }

    public int InsertUrl(ShortUrlDto dto)
    {
        using var conn = new MySqlConnection("Server=localhost;User ID=root;Password=1234@qwer;Database=mysql;Allow User Variables=true");
        var dynamicParameters = new DynamicParameters();
        dynamicParameters.Add("urlKey", dto.UrlKey);
        dynamicParameters.Add("url", dto.Url);

        return conn.Execute("INSERT INTO shortUrl (UrlKey, Url) VALUES (@urlKey, @url)", dynamicParameters);
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