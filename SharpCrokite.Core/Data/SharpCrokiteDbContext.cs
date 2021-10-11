﻿using Microsoft.EntityFrameworkCore;
using MyEveToolset.Data.Models;

namespace MyEveToolset.Data
{
    public class SharpCrokiteDbContext : DbContext
    {
        public DbSet<Harvestable> Harvestables { get; set; }
        public DbSet<MaterialContent> MaterialContents { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Price> Prices { get; set; }

        public string DbPath { get; set; }

        public SharpCrokiteDbContext()
        {
            DbPath = @"C:\Projects\sharp-crokite\SharpCrokite.Core\Data\myevetool.db";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Harvestable>().HasMany(m => m.Prices).WithOne(p => p.Harvestable).OnDelete(DeleteBehavior.Cascade).IsRequired(false);
            modelBuilder.Entity<Material>().HasMany(m => m.Prices).WithOne(p => p.Material).OnDelete(DeleteBehavior.Cascade).IsRequired(false);
        }
    }
}