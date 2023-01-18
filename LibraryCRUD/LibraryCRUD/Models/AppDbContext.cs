using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryCRUD.Models
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Category> categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> books { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<FavoriteBook> FavoriteBooks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FavoriteBook>().HasKey(fb => new { fb.UserAccountId, fb.BookId });
            modelBuilder.Entity<FavoriteBook>()
                        .HasOne(fb => fb.Book)
                        .WithMany(b => b.FavoriteBooks)
                        .HasForeignKey(fb => fb.BookId);

            modelBuilder.Entity<FavoriteBook>()
                        .HasOne(fb => fb.UserAccount)
                        .WithMany(u => u.FavoriteBooks)
                        .HasForeignKey(fb => fb.UserAccountId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
