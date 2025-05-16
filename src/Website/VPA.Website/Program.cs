using System.Reflection;
using VPA.Website.Client;

namespace VPA.Website
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            builder.Services.AddRazorPages();

            builder.Services.AddApiClient(options => options.BaseUrl = builder.Configuration.GetApiBaseUrl());

            WebApplication app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.MapStaticAssets();

            app.MapRazorPages()
               .WithStaticAssets();

            app.Run();
        }

        private static IServiceCollection AddApiClient(this IServiceCollection services, Action<ApiOptions> options)
        {
            ApiOptions o = new ApiOptions();
            services.AddSingleton(o);
            options?.Invoke(o);

            services.AddHttpClient(o.HttpClientName, client => client.BaseAddress = new Uri(o.BaseUrl));

            services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient(o.HttpClientName));

            // Register all api clients
            HashSet<Assembly> assemblies = o.Assemblies.ToHashSet();
            assemblies.Add(typeof(ApiClient).Assembly);
            foreach (Type clientType in assemblies.SelectMany(a => a.GetExportedTypes()).Where(t => !t.IsAbstract && t.IsSubclassOf(typeof(ApiClient))))
                services.AddTransient(clientType);

            return services;
        }

        public static string GetApiBaseUrl(this IConfiguration configuration)
        {
            return configuration["Api:BaseUrl"];
        }
    }
}