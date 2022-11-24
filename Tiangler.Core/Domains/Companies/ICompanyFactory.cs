using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiangler.Core.ResultModels;

namespace Tiangler.Core.Domains.Companies
{
    public interface ICompanyFactory
    {
        ResultModel<Company> CreateCompany(string companyName, Guid userId);
    }
}
