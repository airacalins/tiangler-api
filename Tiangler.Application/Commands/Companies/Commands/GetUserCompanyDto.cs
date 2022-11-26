using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiangler.Application.Commands.Companies.Dtos;
using Tiangler.Application.Commands.Companies.Interfaces;
using Tiangler.Core.Repositories.ApplicationUsersRepositories;
using Tiangler.Core.Repositories.CompanyRepositories;
using Tiangler.Core.ResultModels;

namespace Tiangler.Application.Commands.Companies.Commands
{
    public class GetUserCompanyCommand : IGetUserCompanyCommand
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IApplicationUserRepository _applicationUserRepository;

        public GetUserCompanyCommand(ICompanyRepository companyRepository, IApplicationUserRepository applicationUserRepository)
        {
            _companyRepository = companyRepository;
            _applicationUserRepository = applicationUserRepository;
        }
        public async Task<CommandResult<GetCompanyDto>> ExecuteAsync(Guid companyId, Guid userId)
        {
            var user = await _applicationUserRepository.FirstOrDefaultAsync(a => a.Id == userId);

            if (user == null)
                return new CommandResult<GetCompanyDto>("Get_User_Company_Failed", "User not found.");

            var company = await _companyRepository.FirstOrDefaultAsync(i => i.CompanyId == companyId && i.CompanyAdmin == userId);

            if (company == null)
                return new CommandResult<GetCompanyDto>("Get_User_Company_Failed", "Company not found.");

            var result = new GetCompanyDto(company);

            return new CommandResult<GetCompanyDto>(result);
        }
    }
}
