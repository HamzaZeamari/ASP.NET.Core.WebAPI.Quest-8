using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAWookie.Core.Selfies.Infrastructures.Data
{
    public class SelfieContextFactory : IDesignTimeDbContextFactory<SelfieContext>
    {
        public SelfieContext CreateDbContext(string[] args)
        {
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "Settings", 
                "appSettings.json"));
            IConfigurationRoot configurationRoot = configurationBuilder.Build();
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder();

            optionsBuilder.UseSqlServer(configurationRoot.GetConnectionString("SelfiesDatabase"), b => b.MigrationsAssembly("SelfieAWookie.Core.Selfies.Migration"));
            SelfieContext slfContext = new SelfieContext(optionsBuilder.Options);
            return slfContext;
        }
    }
}
