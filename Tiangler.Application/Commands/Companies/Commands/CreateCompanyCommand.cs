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
        private readonly ICompanyFactory _companyFactory;

        public CreateCompanyCommand(ICompanyRepository companyRepository, IApplicationUserRepository applicationUserRepository, ICompanyFactory companyFactory)
        {
            _companyRepository = companyRepository;
            _applicationUserRepository = applicationUserRepository;
            _companyFactory = companyFactory;
        }
        public async Task<CommandResult<bool>> ExecuteAsync(CreateCompanyDto input, Guid userId)
        {
            var user = await _applicationUserRepository.FirstOrDefaultAsync(a => a.Id == userId);

            if (user == null)
                return new CommandResult<bool>("Create_Company_Failed", "User not found.");


            var companyResult = _companyFactory.CreateCompany(input.CompanyName, userId);

            if(!companyResult.IsSuccess)
                return new CommandResult<bool>("Create_Company_Failed", "Company name is required.");

            _companyRepository.Add(companyResult.Result);
            await _companyRepository.SaveChangesAsync();

            return new CommandResult<bool>(true);
        }
    }
}
