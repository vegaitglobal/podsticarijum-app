﻿#nullable disable
using Microsoft.EntityFrameworkCore;
using podsticarijum_backend.Domain.Entities;

namespace podsticarijum_backend.Repository;

public class PodsticarijumContext : DbContext
{
    public PodsticarijumContext()
    {
    }

    public DbSet<MainScreen> MainScreen { get; set; }

    public DbSet<Category> Category { get; set; }

    public DbSet<SubCategory> SubCategory { get; set; }

    public DbSet<Expert> Expert { get; set; }

    public DbSet<SubCategorySpecificContent> SubCategorySpecificContent { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=podsticarijum");
    }
}
