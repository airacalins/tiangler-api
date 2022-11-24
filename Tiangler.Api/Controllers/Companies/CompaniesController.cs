using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tiangler.Api.Controllers.Companies.InputModels;
using Tiangler.Application.Commands.Companies.Interfaces;

namespace Tiangler.Api.Controllers.Companies
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CompaniesController : BaseController
    {
        private readonly ICreateCompanyCommand _createCompanyCommand;

        public CompaniesController(ICreateCompanyCommand createCompanyCommand)
        {
            _createCompanyCommand = createCompanyCommand;
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
