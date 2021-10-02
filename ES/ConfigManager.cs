using Microsoft.Extensions.Configuration;
using System.IO;

namespace ES
{
    public static class ConfigManager
    {
        public static IConfiguration Configuration { get;}
        static ConfigManager()
        {
            Configuration = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json")
                        .Build();
        }
    }
}
