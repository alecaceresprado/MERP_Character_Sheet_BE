using Microsoft.EntityFrameworkCore;

namespace MERP_Character_Sheet_BE.Models
{
    public class CharacterContext : DbContext
    {
        public CharacterContext(DbContextOptions<CharacterContext> options)
            : base(options)
        {
        }

        public DbSet<Character> Characters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>().HasKey(x => x.Id);
        }
    }
}