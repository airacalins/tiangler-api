using Tiangler.Core.Domains.ApplicationUsers;

namespace Tiangler.Api.Services
{
    public interface ITokenService
    {
        Task<string> GenerateToken(ApplicationUser user);
    }
}
