namespace shortUrl.Interfaces;

public interface IRepository
{
    public string GetUrl(string key);
    public void InsertUrl(Uri url);
}