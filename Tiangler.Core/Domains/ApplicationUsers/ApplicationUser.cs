using Microsoft.AspNetCore.Identity;

namespace Tiangler.Core.Domains.ApplicationUsers
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
    }
}
