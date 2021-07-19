using Microsoft.EntityFrameworkCore;
using Uned.EFBasics.Model;

namespace Uned.EFBasics.DataAccess
{
    public class MusicStoreContext : DbContext
    {
        public DbSet<Guitar> Guitars { get; set; }
        public DbSet<GuitarHistory> GuitarHistory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=;Database=; User Id=; Password=;");

        }
    }
}
