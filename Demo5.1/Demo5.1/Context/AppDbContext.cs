using Demo5._1.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo5._1.Context
{
    class AppDbContext:DbContext
    {
        string ConStr = "Data Source =.\\SQLEXPRESS;Initial Catalog = School;Integrated Security = true";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(ConStr);
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>().HasBaseType<Person>();
            modelBuilder.Entity<Student>().HasBaseType<Person>();
        }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
    }

    
}
