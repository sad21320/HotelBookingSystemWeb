using HotelBookingSystemWeb.Models;

namespace HotelBookingSystem
{
    public class DbInitializerMiddleware
    {
        private readonly RequestDelegate _next;

        public DbInitializerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context, IServiceProvider serviceProvider)
        {
            // Получаем контекст базы данных через DI (Scoped сервис)
            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<HotelContext>();
                DbInitializer.Initialize(dbContext);
            }

            // Передаем управление следующему компоненту
            return _next(context);
        }
    }

    // Метод расширения для удобства
    public static class DbInitializerExtensions
    {
        public static IApplicationBuilder UseDbInitializer(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DbInitializerMiddleware>();
        }
    }
}