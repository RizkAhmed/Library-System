using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF4
{
    public class AppDbContext:DbContext
    {
        public DbSet<Wallet> Wallets { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var consql = @"Data Source=DESKTOP-4RHPT33\SQLEXPRESS;Initial Catalog=DigitalCurrency;Integrated Security=True";
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(consql);
        }
    }
}
