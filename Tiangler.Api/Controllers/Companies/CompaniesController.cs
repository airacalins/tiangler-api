using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tiangler.Api.Controllers.Companies.InputModels;
using Tiangler.Api.Controllers.Companies.ViewModels;
using Tiangler.Application.Commands.Companies.Interfaces;

namespace Tiangler.Api.Controllers.Companies
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CompaniesController : BaseController
    {
        private readonly ICreateCompanyCommand _createCompanyCommand;
        private readonly IGetUserCompaniesCommand _getUserCompaniesCommand;
        private readonly IGetUserCompanyCommand _getUserCompanyCommand;

        public CompaniesController(ICreateCompanyCommand createCompanyCommand,
            IGetUserCompaniesCommand getUserCompaniesCommand,
            IGetUserCompanyCommand getUserCompanyCommand
            )
        {
            _createCompanyCommand = createCompanyCommand;
            _getUserCompaniesCommand = getUserCompaniesCommand;
            _getUserCompanyCommand = getUserCompanyCommand;
        }

        [HttpGet]
        public async Task<ActionResult<List<CompanyViewModel>>> GetCompanies()
        {
            var userId = GetUserId();
            var commandResult = await _getUserCompaniesCommand.ExecuteAsync(userId);

            if (!commandResult.IsSuccessful)
                return Error(commandResult);

            var result = commandResult.Result.Select(i => new CompanyViewModel(i)).ToList();
            return result;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyViewModel>> GetCompany(Guid id)
        {
            var userId = GetUserId();
            var commandResult = await _getUserCompanyCommand.ExecuteAsync(id, userId);

            if (!commandResult.IsSuccessful)
                return Error(commandResult);

            var result =  new CompanyViewModel(commandResult.Result);
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Create(CreateCompanyInputModel input)
        {
            var userId = GetUserId();
            var commandResult = await _createCompanyCommand.ExecuteAsync(input.ToDto(), userId);

            if (!commandResult.IsSuccessful)
                return Error(commandResult);

            return Ok();
        }
    }
}
