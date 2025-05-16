using System.Reflection;

namespace VPA.Api.Repositories
{
    public class DataContextOptions
    {
        /// <summary>
        /// The connection string to the database.
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Defines the assemblies to scan for Repositories to inject.
        /// </summary>
        public List<Assembly> Assemblies { get; private set; } = new List<Assembly>();
    }
}
