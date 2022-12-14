using System.Data.Entity;
using Tiangler.Application.Contexts;
using Tiangler.Core.Domains.ApplicationUsers;
using Tiangler.Core.Domains.Companies;
using Tiangler.Core.Domains.Products;

namespace Tiangler.Infrastructure.Contexts
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public AppDbContext(Microsoft.EntityFrameworkCore.DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
