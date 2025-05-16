using System.Reflection;
using VPA.Api.Repositories;
using VPA.Api.Services;

namespace VPA.Api
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddServices();
            builder.Services.AddDataContext(options => options.ConnectionString = builder.Configuration.GetConnectionString("Default"));

            builder.Services.AddOpenApi();

            WebApplication app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }

        private static IServiceCollection AddDataContext(this IServiceCollection services, Action<DataContextOptions> options)
        {
            DataContextOptions o = new DataContextOptions();
            services.AddSingleton(o);
            options?.Invoke(o);

            services.AddScoped<DataContext>();

            // Register all repositories
            HashSet<Assembly> assemblies = o.Assemblies.ToHashSet();
            assemblies.Add(typeof(RepositoryBase).Assembly);
            foreach (Type clientType in assemblies.SelectMany(a => a.GetExportedTypes()).Where(t => !t.IsAbstract && t.IsSubclassOf(typeof(RepositoryBase))))
                services.AddScoped(clientType);

            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            // Register all services
            HashSet<Assembly> assemblies = new HashSet<Assembly>();
            assemblies.Add(typeof(IService).Assembly);
            foreach (Type clientType in assemblies.SelectMany(a => a.GetExportedTypes()).Where(t => !t.IsAbstract && t.IsSubclassOf(typeof(IService))))
                services.AddScoped(clientType);
            return services;
        }
    }
}
