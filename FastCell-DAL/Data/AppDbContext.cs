using FastCell_DAL.Models.Entities;
using FastCell_DAL.Models.Entities.Auth;
using FC_DAL.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FC_DAL.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Manufacturer> Manufacturer { get; set; }
        public DbSet<ProductModel> Products { get; set; }
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
