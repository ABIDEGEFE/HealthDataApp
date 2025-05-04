using Microsoft.EntityFrameworkCore;

namespace HealthDataApp.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<HealthData> HealthDataRecords { get; set; }
    }
}