#nullable disable
using Microsoft.EntityFrameworkCore;
using podsticarijum_backend.Domain.Entities;

namespace podsticarijum_backend.Repository;

public class PodsticarijumContext : DbContext
{
    public PodsticarijumContext(DbContextOptions<PodsticarijumContext> dbContextOptions)
    : base(dbContextOptions)
    {
    }

    public DbSet<Content> Content { get; set; }

    public DbSet<Category> Category { get; set; }

    public DbSet<SubCategory> SubCategory { get; set; }

    public DbSet<Expert> Expert { get; set; }

    public DbSet<Faq> Faq { get; set; }

    public DbSet<SubCategorySpecificContent> SubCategorySpecificContent { get; set; }

    public DbSet<User> User { get; set; }
}
