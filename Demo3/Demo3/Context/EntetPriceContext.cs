using Demo3.Entitis;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo3.Context
{
    class EntetPriceContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source = .\\SQLEXPRESS; Initial Catalog = EnterPrice ; Integrated security = true ");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode();

            modelBuilder.Entity<Employee>(EB =>
            {
                EB.Property(e => e.YearOfHired).HasDefaultValue(DateTime.Now.Year);
                EB.Property(e => e.Name).IsRequired();
                EB.Property(e => e.Salary).IsRequired();
            }
            );
            modelBuilder.Entity<TrainingCource>(EB =>
            {
                EB.HasKey(e => e.CourceID);
                EB.Property(e => e.Title).IsRequired();
                EB.Property(e => e.BeginDate).HasDefaultValue(DateTime.Now.Year);

            });
                

            base.OnModelCreating(modelBuilder); 
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<TrainingCource> trainingCources { get; set; }

    }
}
