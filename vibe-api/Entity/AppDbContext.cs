using Microsoft.EntityFrameworkCore;
using vibe_api.Entity.Token;

namespace vibe_api.Entity;

public class AppDbContext(IConfiguration configuration) : DbContext
{
    private IConfiguration Configuration { get; } = configuration;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(Configuration.GetConnectionString("VibeVideoConnectionString"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UploadToken>()
            .Property(t => t.Id)
            .ValueGeneratedOnAdd();
    }

    public DbSet<UploadToken> UploadTokens { get; set; }
}