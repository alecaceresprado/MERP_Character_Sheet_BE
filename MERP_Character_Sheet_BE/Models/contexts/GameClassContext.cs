using Microsoft.EntityFrameworkCore;

namespace MERP_Character_Sheet_BE.Models
{
    public class GameClassContext : DbContext
    {
        public GameClassContext(DbContextOptions<GameClassContext> options)
            : base(options)
        {
        }

        public DbSet<GameClass> Classes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameClass>().HasKey(x => x.Id);
        }
    }
}