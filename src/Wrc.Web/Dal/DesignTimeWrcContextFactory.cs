using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Wrc.Web.Dal
{
    public class DesignTimeWrcContextFactory : IDesignTimeDbContextFactory<WrcContext>
    {
        public WrcContext CreateDbContext(string[] args)
        {
            var configurationRoot = new ConfigurationBuilder()
                .AddJsonFile("config.json", optional: false, reloadOnChange: true)
                .Build();
            return new WrcContext(configurationRoot, null);
        }
    }
}