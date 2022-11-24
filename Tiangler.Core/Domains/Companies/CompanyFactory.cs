using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiangler.Core.ResultModels;

namespace Tiangler.Core.Domains.Companies
{
    public class CompanyFactory : Company, ICompanyFactory
    {
        public ResultModel<Company> CreateCompany(string companyName, Guid userId)
        {
            if (string.IsNullOrEmpty(companyName))
                return new ResultModel<Company>(false, "Company name is required");

            var company = Create(companyName, userId);
            return new ResultModel<Company>(company);
        }
    }
}
