using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiangler.Core.Domains.Companies;

namespace Tiangler.Application.Commands.Companies.Dtos
{
    public class GetCompanyDto
    {
        public GetCompanyDto(Company company)
        {
            CompanyId = company.CompanyId;
            CompanyName = company.CompanyName;

        }

        public Guid CompanyId { get; set; }
        public string CompanyName { get; set; }
    }
}
