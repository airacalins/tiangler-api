using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiangler.Core.Domains.Companies;
using Tiangler.Core.Repositories.BaseRepositories;

namespace Tiangler.Core.Repositories.CompanyRepositories
{
    public interface ICompanyRepository : IBaseRepository<Company>
    {
    }
}
