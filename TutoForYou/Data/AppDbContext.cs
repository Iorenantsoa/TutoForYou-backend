using Microsoft.EntityFrameworkCore;

namespace TutoForYou.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Formation> Formations { get; set; }

        public DbSet<PlayList> PlayList { get; set; }
    }
}
