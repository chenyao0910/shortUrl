using shortUrl.Interfaces;
using shortUrl.Repositories;
using shortUrl.Services;
using Sqids;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddTransient<IShortUrlService, ShortUrlService>();
builder.Services.AddTransient<IRepository, MysqlRepository>();
builder.Services.AddSingleton(new SqidsEncoder<int>(new()
{
    Alphabet = "mTHivO7hx3RAbr1f586SwjNnK2lgpcUVuG09BCtekZdJ4DYFPaWoMLQEsXIqyz",
    MinLength = 6,
}));
var app = builder.Build();

app.MapControllers();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();


app.Run();

