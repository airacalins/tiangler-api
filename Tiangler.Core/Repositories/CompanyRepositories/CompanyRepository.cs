using Tiangler.Core.Contexts;
using Tiangler.Core.Domains.Companies;
using Tiangler.Core.Repositories.BaseRepositories;

namespace Tiangler.Core.Repositories.CompanyRepositories
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(AppDbContext context) : base(context)
        {
        }
    }
}
