

using Microsoft.EntityFrameworkCore;
using RestaurantFinder.DataAccess;
using RestaurantFinder.Helpers;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

//Bu k�s�mda bizim veritaban� ba�lant�m�z� olu�turan restourantDbContext s�n�f�n� dependensies injection ile program�n her yerinde kullan�labilir hale getirmi� olduk.Bu Context bize veritaban� i�lemlerini yapt���m�z(ekleme, ��karma vs. yan� controller da) laz�m.
builder.Services.AddDbContext<RestaurantDbContext>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Restorant API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });
});



//LOGLAMA
//builder.Services.AddLogging(i=>
//{
//    i.ClearProviders();
//    i.SetMinimumLevel(LogLevel.Information);
//    //i.AddDebug();
//    i.AddProvider(new MyCustomLoggerFactory());
//});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<JwtMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
