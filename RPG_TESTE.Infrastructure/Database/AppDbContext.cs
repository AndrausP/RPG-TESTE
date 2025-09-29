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
    }
}
