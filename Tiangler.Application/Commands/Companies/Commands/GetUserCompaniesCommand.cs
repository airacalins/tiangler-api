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
    public class GetUserCompaniesCommand : IGetUserCompaniesCommand
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IApplicationUserRepository _applicationUserRepository;

        public GetUserCompaniesCommand(ICompanyRepository companyRepository, IApplicationUserRepository applicationUserRepository)
        {
            _companyRepository = companyRepository;
            _applicationUserRepository = applicationUserRepository;
        }
        public async Task<CommandResult<List<GetCompanyDto>>> ExecuteAsync(Guid userId)
        {
            var user = await _applicationUserRepository.FirstOrDefaultAsync(a => a.Id == userId);

            if (user == null)
                return new CommandResult<List<GetCompanyDto>>("Get_User_Companies_Failed", "User not found.");

            var companies = await _companyRepository.GetAsync(i => i.CompanyAdmin == userId);
            var result = companies.Select(i => new GetCompanyDto(i)).ToList();

            return new CommandResult<List<GetCompanyDto>>(result);
        }
    }
}
