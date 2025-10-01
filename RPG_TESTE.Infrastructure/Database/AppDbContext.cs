using Microsoft.EntityFrameworkCore;
using RPG_TESTE.Domain.Entity;

namespace RPG_TESTE.Infrastructure.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }
        public DbSet<Character> Characters { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
            configurationBuilder.Properties<string>().HaveMaxLength(255);
        }
    }
}
