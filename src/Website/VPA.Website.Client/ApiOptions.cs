using System.Reflection;
using System.Text.Json;

namespace VPA.Website.Client
{
    public class ApiOptions
    {
        /// <summary>
        /// The name of the HttpClient to use for the Api client.
        /// </summary>
        public string HttpClientName { get; set; } = "api";

        /// <summary>
        /// The base addresses of the API
        /// </summary>
        public string BaseUrl { get; set; }

        /// <summary>
        /// Options for the JSON serializer.
        /// </summary>
        public JsonSerializerOptions JsonSerializerOptions { get; set; } = JsonSerializerOptions.Default;

        /// <summary>
        /// Defines the assemblies to scan for Api clients to inject.
        /// </summary>
        public List<Assembly> Assemblies { get; private set; } = new List<Assembly>();
    }
}
