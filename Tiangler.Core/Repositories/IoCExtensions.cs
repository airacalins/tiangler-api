using Microsoft.Extensions.DependencyInjection;
using Tiangler.Core.Repositories.ApplicationUsersRepositories;
using Tiangler.Core.Repositories.CompanyRepositories;

namespace Tiangler.Core.Repositories
{
    public static class IoCExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
        }
    }
}
