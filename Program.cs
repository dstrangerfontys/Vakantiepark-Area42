using Microsoft.EntityFrameworkCore;
using Vakantiepark_Area42.Data;

namespace Vakantiepark_Area42
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthorization();
            builder.Services.AddRazorPages();

            builder.Services.AddContext<HotelContext>(builder.Configuration);

            WebApplication app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapRazorPages();

            app.Run();
        }

        private static IServiceCollection AddContext<T>(this IServiceCollection services, ConfigurationManager configuration)
            where T : DbContext
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            ServerVersion serverVersion = ServerVersion.AutoDetect(connectionString);

            return services.AddDbContext<T>(options => options.UseMySql(connectionString, serverVersion));
        }
    }
}