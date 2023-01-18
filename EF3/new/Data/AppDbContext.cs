using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace EF3.Data
{
    internal class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options)
            :base(options)
        {

        }
        public DbSet<Wallet> Wallets { get; set; } = null!;

    }
}
