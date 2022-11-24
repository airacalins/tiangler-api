using Microsoft.EntityFrameworkCore;
using Tiangler.Core.Domains.ApplicationUsers;
using Tiangler.Core.Domains.Companies;
using Tiangler.Core.Domains.Products;

namespace Tiangler.Application.Contexts
{
    public interface IAppDbContext
    {
        DbSet<ApplicationUser> ApplicationUsers { get; set; }
        DbSet<Company> Companies { get; set; }
        DbSet<Product> Products { get; set; }
    }
}