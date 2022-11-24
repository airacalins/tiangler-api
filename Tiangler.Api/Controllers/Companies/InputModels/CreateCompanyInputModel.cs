using Tiangler.Application.Commands.Companies.Dtos;

namespace Tiangler.Api.Controllers.Companies.InputModels
{
    public class CreateCompanyInputModel
    {
        public string CompanyName { get; set; }

        public CreateCompanyDto ToDto()
        {
            return new CreateCompanyDto
            {
                CompanyName = CompanyName
            };
        }
    }
}
