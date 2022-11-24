using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiangler.Application.Commands.Companies.Dtos;
using Tiangler.Application.Commands.Companies.Interfaces;
using Tiangler.Core.Domains.Companies;
using Tiangler.Core.ResultModels;
using Tiangler.Core.Repositories.ApplicationUsersRepositories;
using Tiangler.Core.Repositories.CompanyRepositories;

namespace Tiangler.Application.Commands.Companies.Commands
{
    public class CreateCompanyCommand : ICreateCompanyCommand
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IApplicationUserRepository _applicationUserRepository;

        public CreateCompanyCommand(ICompanyRepository companyRepository, IApplicationUserRepository applicationUserRepository)
        {
            _companyRepository = companyRepository;
            _applicationUserRepository = applicationUserRepository;
        }
        public async Task<CommandResult<bool>> ExecuteAsync(CreateCompanyDto input, Guid userId)
        {
            var user = await _applicationUserRepository.FirstOrDefaultAsync(a => a.Id == userId);

            if (user == null)
                return new CommandResult<bool>("Create_Company_Failed", "User not found. ");


            var company = new Company
            {
                CompanyName = input.CompanyName,
                CompanyAdmin = userId
            };

            _companyRepository.Add(company);
            await _companyRepository.SaveChangesAsync();

            return new CommandResult<bool>(true);
        }
    }
}
