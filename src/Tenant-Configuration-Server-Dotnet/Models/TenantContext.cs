using Microsoft.EntityFrameworkCore;

namespace Tenant_Configuration_Server_Dotnet.Models
{
    public class TenantContext : DbContext
    {
        public TenantContext(DbContextOptions<TenantContext> options) : base(options)
        {
        }

        public DbSet<Tenant> Tenants { get; set; }
    }
}