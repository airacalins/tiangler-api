using Tiangler.Core.Contexts;
using Tiangler.Core.Domains.ApplicationUsers;
using Tiangler.Core.Repositories.BaseRepositories;

namespace Tiangler.Core.Repositories.ApplicationUsersRepositories
{
    public class ApplicationUserRepository : BaseRepository<ApplicationUser>, IApplicationUserRepository
    {
        public ApplicationUserRepository(AppDbContext context) : base(context)
        {
        }
    }
}
