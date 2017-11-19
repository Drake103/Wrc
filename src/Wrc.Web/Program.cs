using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Wrc.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(
                    (builderContext, config) =>
                    {
                        config.AddJsonFile("config.json", false, true);
                    })
                .UseStartup<Startup>()
                .Build();
        }
    }
}