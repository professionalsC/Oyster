using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Oyster.ApplicationCore.Entities;
using Oyster.ApplicationCore.Entities.BasketAggregate;
using Oyster.ApplicationCore.Entities.OrderAggregate;

namespace Oyster.Infrastructure.Data;

public class CatalogContext : DbContext
{
    public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
    {
    }

    public DbSet<Basket> Baskets { get; set; }
    public DbSet<CatalogItem> CatalogItems { get; set; }
    public DbSet<CatalogBrand> CatalogBrands { get; set; }
    public DbSet<CatalogGenderType> CatalogGenderTypes { get; set; }
    public DbSet<CatalogType> CatalogTypes { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<BasketItem> BasketItems { get; set; }
    public DbSet<ResourceModule> ResourceModules { get; set; }
    public DbSet<ResourceModuleConsent> ResourceModuleConsents { get; set; }



    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
