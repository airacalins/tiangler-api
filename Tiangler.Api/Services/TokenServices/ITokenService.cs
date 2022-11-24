using Tiangler.Core.Domains.ApplicationUsers;

namespace Tiangler.Api.Services.TokenServices
{
    public interface ITokenService
    {
        Task<string> GenerateToken(ApplicationUser user);
    }
}
