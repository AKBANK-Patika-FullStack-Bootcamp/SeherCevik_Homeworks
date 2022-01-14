

using Microsoft.EntityFrameworkCore;
using RestaurantFinder.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//Bu k�s�mda bizim veritaban� ba�lant�m�z� olu�turan restourantDbContext s�n�f�n� dependensies injection ile program�n her yerinde kullan�labilir hale getirmi� olduk.Bu Context bize veritaban� i�lemlerini yapt���m�z(ekleme, ��karma vs. yan� controller da) laz�m.
builder.Services.AddDbContext<RestaurantDbContext>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
