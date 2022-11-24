using Microsoft.Extensions.DependencyInjection;
using Tiangler.Core.Domains.Companies;

namespace Tiangler.Core.Domains
{
    public static class IoCExtensions
    {
        public static void AddFactories(this IServiceCollection services)
        {
            services.AddScoped<ICompanyFactory, CompanyFactory>();
        }
    }
}
