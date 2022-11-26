using Microsoft.Extensions.DependencyInjection;
using Tiangler.Application.Commands.Companies.Commands;
using Tiangler.Application.Commands.Companies.Interfaces;

namespace Tiangler.Application.Commands.Companies
{
    public static class IoCExtensions
    {
        public static void AddCompanyCommands(this IServiceCollection services)
        {
            services.AddScoped<ICreateCompanyCommand, CreateCompanyCommand>();
            services.AddScoped<IGetUserCompaniesCommand, GetUserCompaniesCommand>();
            services.AddScoped<IGetUserCompanyCommand, GetUserCompanyCommand>(); 
        }
    }
}
