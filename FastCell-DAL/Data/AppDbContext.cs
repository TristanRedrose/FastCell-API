using FC_DAL.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FC_DAL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

    
        public DbSet<CellPhone> CellPhones {  get; set; }
        public DbSet<ProductRepair> RepairServices { get; set; }
        public DbSet<ServicePrice> ServicePrices { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

    }
}
