using Microsoft.EntityFrameworkCore;

namespace Medifine.Models
{
    public class MedifineContext : DbContext
    {
        public MedifineContext(DbContextOptions<MedifineContext> options) : base(options)
        {
        }
        public DbSet<pharmacy> Pharmacies { get; set; }
        public DbSet<inventory> Inventories { get; set; }
        public DbSet<owner> Owners { get; set; }
    }
}
