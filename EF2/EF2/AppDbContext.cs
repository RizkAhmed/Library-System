using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace EF2
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Wallet> Wallets { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var configration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var constr = configration.GetSection("constr").Value;
            optionsBuilder.UseSqlServer(constr);
        }
    }

}
