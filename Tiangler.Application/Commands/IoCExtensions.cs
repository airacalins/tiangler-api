using Microsoft.Extensions.DependencyInjection;
using Tiangler.Application.Commands.Companies;

namespace Tiangler.Application.Commands
{
    public static class IoCExtensions
    {
        public static void AddCommands(this IServiceCollection services)
        {
            services.AddCompanyCommands();
        }
    }
}
