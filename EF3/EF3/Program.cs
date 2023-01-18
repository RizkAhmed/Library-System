using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.EntityFrameworkCore;
using System;
using EF3.Data;
using Microsoft.Extensions.DependencyInjection;

namespace EF3
{
    class Program
    {
        static void Main(string[] args)
        {
            var configraton = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var constr = configraton.GetSection("constr").Value;
            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseSqlServer(constr);
            var options = optionsBuilder.Options;

            var services = new ServiceCollection();
            services.AddDbContext<AppDbContext>(option=>option.UseSqlServer(constr));

            IServiceProvider servicesprovider = services.BuildServiceProvider();

            using (var context = servicesprovider.GetRequiredService<AppDbContext>() )
            {
                foreach( var wallet in context.Wallets )
                {
                    Console.WriteLine(wallet);
                }
            }
        }
    }
}
