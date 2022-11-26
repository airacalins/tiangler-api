using Tiangler.Application.Commands.Companies.Dtos;

namespace Tiangler.Api.Controllers.Companies.ViewModels
{
    public class CompanyViewModel
    {
        public CompanyViewModel(GetCompanyDto company)
        {
            CompanyId = company.CompanyId;
            CompanyName = company.CompanyName;

        }

        public Guid CompanyId { get; set; }
        public string CompanyName { get; set; }

    }
}
