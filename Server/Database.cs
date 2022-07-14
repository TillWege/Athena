using Microsoft.EntityFrameworkCore;

namespace Server
{
    public class Database : DbContext
    {
        public DbSet<AthenaCommon.Task> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(@"Host=XXX:5432;Username=XXX;Password=XXX;Database=athena");

    }
}

