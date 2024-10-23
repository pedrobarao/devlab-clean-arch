using Lab.Core.Commons.Data;
using Lab.Customers.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lab.Customers.Infra.Data;

public sealed class CustomerDbContext : DbContext, IUnitOfWork
{
    public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        ChangeTracker.AutoDetectChangesEnabled = false;
    }

    public DbSet<Customer> Customers { get; set; }

    public async Task<bool> Commit()
    {
        var result = await SaveChangesAsync();
        return result > 0;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                     .SelectMany(e => e.GetForeignKeys()))
            relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}