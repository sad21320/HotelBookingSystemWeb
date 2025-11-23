using HotelBookingSystem; // Подключаем пространство имен Middleware
using HotelBookingSystemWeb.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Добавляем сервисы
builder.Services.AddControllersWithViews();

// Подключение контекста БД
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<HotelContext>(options => options.UseSqlServer(connection));

// Добавляем сервис кэширования
builder.Services.AddResponseCaching();

var app = builder.Build();

// 2. Настройка конвейера (Pipeline)
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Включаем кэширование ответов
app.UseResponseCaching();

app.UseAuthorization();

// 3. Подключаем наш Middleware для инициализации БД
app.UseDbInitializer();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();