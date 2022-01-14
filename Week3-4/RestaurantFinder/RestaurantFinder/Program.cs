

using Microsoft.EntityFrameworkCore;
using RestaurantFinder.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//Bu kýsýmda bizim veritabaný baðlantýmýzý oluþturan restourantDbContext sýnýfýný dependensies injection ile programýn her yerinde kullanýlabilir hale getirmiþ olduk.Bu Context bize veritabaný iþlemlerini yaptýðýmýz(ekleme, çýkarma vs. yaný controller da) lazým.
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
