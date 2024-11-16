using Adaptive;
using Microsoft.EntityFrameworkCore;
using RT;
using RT.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<RTDBContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));

builder.Services.AddAdaptive<RTDBContext>(new AdaptiveConfig()
{
    AllowedOrigins = ["https://www.adaptivesoftware.io", "http://localhost:4200"],
    JwtSigningKey = "87ede742-3d95-4048-9fc6-2c9ec5de6e98",
    WithOpenApi = true
});

var app = builder.Build();

await app.SeedAdaptiveDb();
await app.SeedRTDBContext();

app.UseAdaptive(enableSwagger: true);

app.MapControllers();

app.Run();