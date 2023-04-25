using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using LightNovel.Models;

namespace LightNovel.Models
{
    public class LightNovelDBContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public LightNovelDBContext(DbContextOptions<LightNovelDBContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Configuration.GetConnectionString("Lightnovels");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        public DbSet<Novel> Novels { get; set; } = null!;
        public DbSet<Creator> Creators { get; set; } = null!;
        public DbSet<Comic> Comics { get; set; } = null!;
        public DbSet<Raw> Raws { get; set; } = null!;
    }
}
