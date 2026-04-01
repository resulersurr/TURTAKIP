using Microsoft.EntityFrameworkCore;
using TourTrackingAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// DB Context – appsettings.json'dan connection string okunuyor
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Controllers
builder.Services.AddControllers();

// CORS – frontend'den gelen isteklere izin ver
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

// Veritabanı ve tabloları otomatik oluştur
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

app.UseCors("AllowAll");
app.MapControllers();

app.Run();
