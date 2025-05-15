using System.Reflection;
using System.Text.Json;

namespace VPA.Website.Client
{
    public class ApiOptions
    {
        public string HttpClientName { get; set; } = "api";

        /// <summary>
        /// The base addresses of the API
        /// </summary>
        public string BaseUrl { get; set; }

        public bool IgnoreSslErrors { get; set; } = true;

        public JsonSerializerOptions JsonSerializerOptions { get; set; } = JsonSerializerOptions.Default;

        public List<Assembly> Assemblies { get; private set; } = new List<Assembly>();
    }
}
